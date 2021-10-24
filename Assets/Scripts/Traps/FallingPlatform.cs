using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            StartCoroutine(ColliderDisable());
        }
    }

    IEnumerator ColliderDisable()
    {
        yield return new WaitForSeconds(0.75f);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
