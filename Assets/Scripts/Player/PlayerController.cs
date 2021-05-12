using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private Animator animator;
    private SpriteRenderer SpriteRenderer;
    

    public float moveSpeed, jumpForce;
    public bool isGrounded;
    private float inputx;



    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

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
        if(context.performed && isGrounded)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jumpForce);
        }

    }
}
