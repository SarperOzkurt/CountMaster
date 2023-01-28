using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : AObstacle
{
    void Start()
    {
        ChooseMovement();        
    }

    void Update()
    {
        movement.Move(transform, direction, speed,worldSpace);
    }
}
