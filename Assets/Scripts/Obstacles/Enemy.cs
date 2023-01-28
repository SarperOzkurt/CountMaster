using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AObstacle
{
    public Transform target;
    public bool trigger;

    public Animator anim;

    private Enemies enemies;
    //
    public Transform playerM;
    void Start()
    {
        transform.rotation = Quaternion.Euler(startRotation);

        anim = GetComponent<Animator>();
        enemies = transform.parent.GetComponent<Enemies>();
        ChooseMovement();
    }

    void Update()
    {
        if (enemies.trigger && playerM.GetComponent<PlayerManager>().outPool.Count>0)
        {
            target = playerM.GetComponent<PlayerManager>().outPool[0].transform;

            direction = target.position - transform.position;//target.position - transform.position;

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            transform.forward = direction;

            anim.Play("run");
        }

    }

    

}
