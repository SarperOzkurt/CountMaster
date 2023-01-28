using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEnemyPool : APool
{
    [SerializeField] GameObject enemy;
    [SerializeField] int amount;

    [SerializeField] float DistanceFactor;
    [SerializeField] float radius;

    [SerializeField] Transform target;
    void Start()
    {
        CreatePool(enemy, transform, amount);

        Transform enemyGroup = transform.GetChild(0);

        if (enemyGroup.childCount > 0)
        {
            for(int i = 0; i < enemyGroup.childCount; i++)
            {
                Enemies enemies = enemyGroup.GetChild(i).GetComponent<Enemies>();
                for(int j = 0; j < enemies.amount; j++)
                {
                    GameObject enemy =  Out(pool[i]);
                    enemy.transform.parent = enemyGroup.GetChild(i);
                 //   enemy.GetComponent<Enemy>().target = target;
                    enemy.GetComponent<EnemyTrigger>().enemyPool = this;
                    FormatStickMan(enemy.transform, j);

                }
            }
        }
    }

    private void FormatStickMan(Transform enemy,int index)
    {
        float x = DistanceFactor * Mathf.Sqrt(index) * Mathf.Cos(index * radius);
        float z = DistanceFactor * Mathf.Sqrt(index) * Mathf.Sin(index * radius);

        enemy.localPosition = new Vector3(x, 0, z);
    }

}
