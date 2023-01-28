using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement 
{
    public void Move(Transform transform, Vector3 direction, float speed,Space space);
}
