using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : AObstacle
{
    void Start()
    {
        ChooseMovement();

        if(transform.parent.GetComponent<AObstacle>())
            transform.rotation = Quaternion.Euler(transform.parent.eulerAngles);
    }

    void Update()
    {
        movement.Move(transform, direction, speed, worldSpace);
    }
}
