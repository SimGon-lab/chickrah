using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveDistance = 5.0f;

    private Vector3 initialPosition;
    private bool movingRight = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        // Calculate the new position based on the direction and speed
        Vector3 newPosition = movingRight ? initialPosition + Vector3.right * moveDistance : initialPosition - Vector3.right * moveDistance;

        // Move the platform towards the new position
        transform.Translate((newPosition - transform.position).normalized * moveSpeed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, newPosition) < 0.1f)
        {
            // Change direction
            movingRight = !movingRight;
        }
    }
}
