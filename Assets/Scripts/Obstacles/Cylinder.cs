using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : AObstacle
{

    void Start()
    {
        transform.rotation = Quaternion.Euler(startRotation);
        ChooseMovement();
    }

    void Update()
    {
        movement.Move(transform, direction , speed,worldSpace);    
    }

}
