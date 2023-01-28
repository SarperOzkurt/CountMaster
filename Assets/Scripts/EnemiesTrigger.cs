using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Stickman>()/*other.GetComponent<PlayerManager>()*/)
        {
            Rigidbody rb;
            other.transform.parent.GetComponent<PlayerManager>().roadSpeed = 5.0f;                            
            transform.GetComponent<Enemies>().trigger = true;
            transform.GetComponent<Enemies>().state = true;
            for(int i = 0; i < transform.childCount; i++)
            {
                rb = transform.GetChild(i).GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;
                transform.GetChild(i).GetComponent<Enemy>().playerM = other.transform.parent;
                //transform.GetChild(i).GetComponent<Enemy>().target = other.transform.parent.GetComponent<PlayerManager>().outPool[0].transform;//bir kere triggerleniyor sürekli calismasi lazim.
            }
        }    
    }

}
