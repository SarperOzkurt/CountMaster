using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AObstacle :MonoBehaviour
{
    protected IMovement movement;
    protected enum MovementType { Move, Rotate,CircularMotion };

    [SerializeField] protected Space worldSpace;
    [SerializeField]protected float speed;
    [SerializeField]public Vector3 direction;
    [SerializeField] protected Vector3 startRotation;
    

    [SerializeField] MovementType movementType;


    public IMovement ChooseMovement()
    {
        switch (movementType)
        {
            case MovementType.Move:
                movement = new Movement();
                return movement;
            case MovementType.Rotate:
                movement = new Rotation();
                return movement;
            default:
                return movement;
        }

    }

}
