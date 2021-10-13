using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private GameObject player;
    private Rigidbody enemyRb;
    public float speed;

    private float xBound = 20f;
    private float zBound = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pointTowardsPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(pointTowardsPlayer * speed * Time.deltaTime);
        ConstrainPlayerPosition();
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.x < -xBound)
        {
            //transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            enemyRb.AddForce(Vector3.right * Mathf.Abs(speed) * Time.deltaTime, ForceMode.Impulse);
        }
        if (transform.position.x > xBound)
        {
            //transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            enemyRb.AddForce(Vector3.left * Mathf.Abs(speed) * Time.deltaTime, ForceMode.Impulse);
        }
        if (transform.position.z < -zBound)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            enemyRb.AddForce(Vector3.forward * Mathf.Abs(speed) * Time.deltaTime, ForceMode.Impulse);
        }
        if (transform.position.z > zBound)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            enemyRb.AddForce(Vector3.back * Mathf.Abs(speed) * Time.deltaTime, ForceMode.Impulse);
        }
    }

}
