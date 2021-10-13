using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 10f;
    private Rigidbody playerRb;
    private float xBound = 20f;
    private float zBound = 20f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Added to included physics in the future
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayer();
        ConstrainPlayerPosition();
        
    }

    //Player moves based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move with Translate
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        // Move with Forces
        //playerRb.AddForce(Vector3.forward * speed * verticalInput * Time.deltaTime);
        //playerRb.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    // Player's movement is constrained to invisible walls
    void ConstrainPlayerPosition()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    private void EatBall(float damage, float pollution, float score)
    {
        gameManager.health -= damage;
        gameManager.DrainRate += pollution;
        gameManager.score += score;
    }


    private void OnTriggerEnter(Collider collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy.CompareTag("Low Damage"))
        {
            EatBall(0.5f, -1, 1);
        }
        else if (enemy.CompareTag("Low Health"))
        {
            EatBall(-1, 0, 0);
        }
        else if (enemy.CompareTag("Medium Pollution"))
        {
            EatBall(0, 1, 4);
        }
        else if (enemy.CompareTag("High Pollution"))
        {
            EatBall(0, 2, 10);
        }
        else if (enemy.CompareTag("High Damage"))
        {
            EatBall(5, -1, 5);
        }
        else if (enemy.CompareTag("Medium Damage"))
        {
            EatBall(2.5f, 1, 3);
        }
        else if (enemy.CompareTag("High Health"))
        {
            EatBall(-5, 1, -5);
        }
        Destroy(enemy);

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
