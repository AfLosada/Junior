using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderRandomly : MonoBehaviour
{
    private Rigidbody enemyRb;
    public float speed;
    public bool changeLocation;
    private Vector3 moveLocation;

    private float xBound = 20f;
    private float zBound = 20f;

    public float spawnRange = 15; 

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        moveLocation = GenerateRandomLocation();
        StartCoroutine(LocationCooldownRoutine());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!changeLocation)
        {
            changeLocation = true;
            StartCoroutine(LocationCooldownRoutine());
        }
        MoveToLocation();
        ConstrainPlayerPosition();
    }


    private void MoveToLocation()
    {
        enemyRb.AddForce((moveLocation).normalized * speed * Time.deltaTime);
        Debug.Log(moveLocation);
    }

    IEnumerator LocationCooldownRoutine()
    {
        yield return new WaitForSeconds(5);
        changeLocation = false;
        moveLocation = GenerateRandomLocation();
    }

    private Vector3 GenerateRandomLocation()
    {
        float spawnPostX = Random.Range(-spawnRange, spawnRange);
        float spawnPostZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPostX, 0, spawnPostZ);
        return randomPos;
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
