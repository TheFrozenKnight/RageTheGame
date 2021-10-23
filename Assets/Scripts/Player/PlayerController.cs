using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask GroundLayerMask;
    [SerializeField] private GameObject World1;
    [SerializeField] private GameObject World2;


    private Rigidbody2D Rigidbody;
    private Animator animator;
    private SpriteRenderer SpriteRenderer;
    private BoxCollider2D BoxCollider2D;
    private PauseMenu pauseMenu;
    
    public float moveSpeed, jumpForce;
    private float inputx;
    int lvlUnlocked;
    bool hasDoubleJump = false;
    bool worldChanged = false;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        lvlUnlocked = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = new Vector2(inputx * moveSpeed, Rigidbody.velocity.y);

        if (Rigidbody.velocity.x > 0f)
        {
            SpriteRenderer.flipX = false;
        }
        else if (Rigidbody.velocity.x < 0f)
        {
            SpriteRenderer.flipX = true;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputx = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jumpForce);
        }
        else if(hasDoubleJump && context.performed)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jumpForce);
            hasDoubleJump = false;
        }
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(PauseMenu.IsGamePaused)
            {
                pauseMenu.Resume();
            }
            else
            {
                pauseMenu.Pause();
            }
        }
    }
    public void Switch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeWorld();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("win"))
        {

            if (lvlUnlocked >= PlayerPrefs.GetInt("LevelsUnlocked"))
            {
                PlayerPrefs.SetInt("LevelsUnlocked", lvlUnlocked + 1);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(collision.CompareTag("PowerUp"))
        {
            hasDoubleJump = true;
            collision.gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private bool IsGrounded()
    {
        float extraheight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0f, Vector2.down, extraheight, GroundLayerMask);
        return raycastHit.collider != null;
    }   

    private void ChangeWorld()
    {
        if(!worldChanged)
        {
            World1.SetActive(false);
            World2.SetActive(true);
            worldChanged = true;
        }
        else
        {
            World1.SetActive(true);
            World2.SetActive(false);
            worldChanged = false;
        }
    }

}
