using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AObstacle>() && StickManTrigger.getInstance().IsTrigger)
        {
            transform.parent.GetComponent<PlayerManager>().ResetStickMan();
            StickManTrigger.getInstance().IsTrigger = false;            
        }
    }
}
