using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderRandomly : Enemy
{
    [SerializeField]
    private bool changeLocation;
    private Vector3 moveLocation;

    public float spawnRange = 15; 

    // Start is called before the first frame update
    protected override void Start()
    {
        StartRoutine();
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        if (!changeLocation)
        {
            changeLocation = true;
            StartCoroutine(LocationCooldownRoutine());
        }
        /*
         This is an example of Abstraction, making it easier to read and understand
         */
        Move();
        ConstrainPlayerPosition();
    }
    /*
     ABSTRACTION
     */
    protected override void StartRoutine()
    {
        enemyRb = GetComponent<Rigidbody>();
        moveLocation = GenerateRandomLocation();
        StartCoroutine(LocationCooldownRoutine());
    }

    /*
     Another example of Polymorphism, where the enemy moves randomly
     */
    protected override void Move()
    {
        enemyRb.AddForce((moveLocation).normalized * m_Speed * Time.deltaTime);
        Debug.Log(moveLocation);
    }

    IEnumerator LocationCooldownRoutine()
    {
        yield return new WaitForSeconds(3);
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
    
}
