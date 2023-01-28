using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APool : MonoBehaviour
{
    public List<GameObject> pool = new List<GameObject>();
    public List<GameObject> outPool = new List<GameObject>();    
    
    protected void CreatePool(GameObject obj, Transform transform, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject a = Instantiate(obj, transform.position, transform.rotation, transform);
            In(a);
        }
    }

    public GameObject In(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = Vector3.zero;
        pool.Add(obj);
        if (outPool.Count > 0) outPool.Remove(obj);
   
        return obj;
    }
    public GameObject Out(GameObject obj)
    {
        obj.SetActive(true);
        outPool.Add(obj);
        pool.Remove(obj);

        return obj;
    }

}
