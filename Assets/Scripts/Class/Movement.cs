using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : IMovement
{
    public void Move(Transform transform, Vector3 direction, float speed,Space space)
    {
        transform.Translate(direction * speed * Time.deltaTime,space);
        
    }

}
