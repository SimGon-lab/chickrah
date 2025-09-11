using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chickrahscript : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public AudioClip jumpSound;
    public AudioClip pointsSound;
    public AudioClip scene1Music;
    public AudioClip scene2Music;
    public AudioClip scene3Music;
    public float timeLeft = 60;
    private Rigidbody2D rb;
    private AudioSource src;
    private bool jump = false;
    private int score = 0;
    //private int requiredCoffeeCount = 4;
    public Vector2 movement;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public string GameOverScene;

    
    public LayerMask ground;

    
    public float jumpOnHeadThreshold = 0.5f;
    int lives = 3;
    public Transform chaser; // Reference to the chasing object
    public float chaserMoveSpeed = 2f;

    Vector3 startPOS;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        src = GetComponent<AudioSource>();
        startPOS = transform.position;
        chaser = GameObject.FindGameObjectWithTag("Chaser").transform; // Find the chasing object by tag
    }

    void Update()
    {
        if (transform.position.y < -8)
        {
            transform.position = startPOS;
        }

        timeLeft -= Time.deltaTime;   

        timeText.text = "Time: " + timeLeft.ToString("0.0");

        var feet = new Vector2(transform.position.x, transform.position.y - 0.5f);
        var dimensions = new Vector2(0.0f, 0.1f);
        var grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);
        movement.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        if (timeLeft < 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("lose");
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * 8);

        if (jump)
        {
            jump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            src.PlayOneShot(jumpSound);
        }

        // Move the chaser
        if (chaser != null)
        {
            Vector3 chaserDirection = (transform.position - chaser.position).normalized;
            chaser.Translate(chaserDirection * chaserMoveSpeed * Time.deltaTime);
        }
    }
    public void Die()
    {
            
           // livesText.text = "Lives" + lives.ToString();
           // UpdateLives();
            if (lives == 0)
            {
                lives--;
                UnityEngine.SceneManagement.SceneManager.LoadScene("lose");
            } else 
            {
                var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
                UnityEngine.SceneManagement.SceneManager.LoadScene("Chickrah");
            }
    }
 
  public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coffee"))
        {
            score++;
            scoreText.text = "Score" + score.ToString();
            Destroy(collision.gameObject);
            src.PlayOneShot(pointsSound);
            UpdateScore();
        } 
       if (collision.CompareTag("Chaser"))
    {
        // Check if the player is above the chaser and within a certain vertical range
        float playerY = transform.position.y;
        float chaserY = collision.transform.position.y;

        if (playerY > chaserY && playerY - chaserY < jumpOnHeadThreshold)
        {
            Die();
            // Player jumped on the chaser's head
            //Destroy(collision.gameObject); // or any other logic to handle chaser death
            // Add score, play sound, etc.
        }
        else
        {
            // Player collided with the chaser, but not on the head
           // Die();
           Destroy(collision.gameObject);
            lives--;
        }
       
    }
}

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
