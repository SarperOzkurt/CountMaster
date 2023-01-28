using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : IMovement
{
    public void Move(Transform transform, Vector3 direction, float speed,Space space)
    {
        transform.Rotate(direction * speed * Time.deltaTime,space);
    }
}
