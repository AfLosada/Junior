using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // INHERITANCE
    /*
     All the variables that are declared as protected because they should be able to be used by the inherited classes
    This is an example of Inheritance
     */

    protected GameObject player;
    protected Rigidbody enemyRb;
    [SerializeField]
    protected float m_Speed;
    [SerializeField]
    protected float m_MaxSpeed;

    protected float xBound = 20f;
    protected float zBound = 20f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        StartRoutine();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        Move();
    }



    protected virtual void StartRoutine()
    {

        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    public void ConstrainPlayerPosition()
    {
        if (transform.position.x < -xBound)
        {
            //transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            enemyRb.AddForce(Vector3.right * Mathf.Abs(m_Speed) * Time.deltaTime, ForceMode.Impulse);
            CheckVelocity(enemyRb);
        }
        if (transform.position.x > xBound)
        {
            //transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            enemyRb.AddForce(Vector3.left * Mathf.Abs(m_Speed) * Time.deltaTime, ForceMode.Impulse);
            CheckVelocity(enemyRb);
        }
        if (transform.position.z < -zBound)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            enemyRb.AddForce(Vector3.forward * Mathf.Abs(m_Speed) * Time.deltaTime, ForceMode.Impulse);
            CheckVelocity(enemyRb);
        }
        if (transform.position.z > zBound)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            enemyRb.AddForce(Vector3.back * Mathf.Abs(m_Speed) * Time.deltaTime, ForceMode.Impulse);
            CheckVelocity(enemyRb);
        }
    }
    
    private void CheckVelocity(Rigidbody rb)
    {
        float magnitude = rb.velocity.magnitude;
        if (magnitude > m_MaxSpeed)
        {
            float brakeSpeed = m_Speed - m_MaxSpeed;
            Vector3 normalizedVelocity = rb.velocity.normalized;
            Vector3 brakeVelocity = normalizedVelocity * brakeSpeed;
            rb.AddForce(-brakeVelocity);
        }
    }

    /*
     This is an example of Polymorphism, for different types of Balls of Light have different types of Moving
     */
    protected abstract void Move();


}
