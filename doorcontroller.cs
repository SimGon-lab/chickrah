using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string nextScene;
    public int requiredCoffeeCount = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chickling"))
        {
            Chickrahscript chicklingScript = collision.GetComponent<Chickrahscript>();

            if (chicklingScript != null && chicklingScript.GetScore() >= requiredCoffeeCount)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }
        }
    }
}
