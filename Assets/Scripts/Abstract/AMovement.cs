using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMovement : IMovement
{
    protected Movement movement = new Movement();
    protected Rotation rotation = new Rotation();
    // IMovementden inherit etmeyecek.

    public abstract void Move(Transform transform, Vector3 direction, float speed,Space space);

}
