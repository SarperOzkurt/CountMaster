using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tide : AObstacle
{
    [Header("References")]
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;

    private Transform saw;
    void Start()
    {
        saw = transform.GetChild(0);
        Debug.Log(saw.name);
    }
    void Update()
    {
        if(saw.localPosition.x >= pos1.localPosition.x || saw.localPosition.x<=pos2.localPosition.x)
        {
            saw.GetComponent<AObstacle>().direction.x *=-1 ;
        }
    }
}