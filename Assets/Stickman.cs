using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    public GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stair"))
        {
            transform.parent.parent = null;
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = GetComponent<Collider>().isTrigger = false;
            GetComponent<Animator>().SetBool("Run", false);

          
        }
        else if( other.GetComponent<AObstacle>() )
        {
            transform.parent.GetComponent<PlayerManager>().In(gameObject);
            if (other.transform.CompareTag("Obstacle")) StickManTrigger.getInstance().IsTrigger = true;

        }
    }
}
