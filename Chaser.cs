using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    public float moveSpeed = 0.0f;
    public Transform player; 

    void Update()
    {
        //  direction from the chaser to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move chaser towards the player
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
