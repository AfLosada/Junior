using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 10f;
    private Rigidbody playerRb;
    private float xBound = 20f;
    private float zBound = 20f;

    // Start is called before the first frame update
    void Start()
    {
        // Added to included physics in the future
        playerRb = GetComponent<Rigidbody>();
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("BallOfLight"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
