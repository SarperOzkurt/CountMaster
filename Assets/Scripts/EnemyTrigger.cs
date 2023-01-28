using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public AEnemyPool enemyPool;
    void OnTriggerEnter(Collider other)
    {
        Transform enemy;
        Rigidbody rb;
        if (other.GetComponent<Stickman>())
        {
            enemy = enemyPool.In(gameObject).transform;
            enemy.parent = enemyPool.transform;
            rb = enemy.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
            
        }
    }
}
