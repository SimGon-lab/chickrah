using UnityEngine;
using System.Collections;

public class baddieChick : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;

    private bool isChaserVisible = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ToggleVisibility());
    }

    void Update()
    {
        if (isChaserVisible)
        {
            Move(1);
            CheckGround();
        }
        // If you want to implement additional behaviors, you can do so here
    }

    void Move(float direction)
    {
        rb.velocity = new Vector2(moveSpeed * direction, rb.velocity.y);
    }

    void CheckGround()
    {
        // Check if there is ground in front of the chaser
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, groundCheckDistance, groundLayer);
        if (!hit.collider)
        {
            // Change direction if there's no ground ahead
            moveSpeed *= -1;
        }
    }

    IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            isChaserVisible = !isChaserVisible;
            gameObject.SetActive(isChaserVisible);

            if (!isChaserVisible)
            {
                yield return new WaitForSeconds(2f); // Chaser is invisible for 2 seconds
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isChaserVisible)
        {
            // Player collided with the chaser
            collision.gameObject.GetComponent<Chickrahscript>().Die();
        }
    }
}
