using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : Enemy
{
    /*
     This is an example of Polymorphism, for an Enemy that follows a player should have different from one that moves randomly
     */
    protected override void Move()
    {
        Vector3 pointTowardsPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(pointTowardsPlayer * m_Speed * Time.deltaTime);
    }


}
