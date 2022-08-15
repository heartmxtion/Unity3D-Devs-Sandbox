using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampCollisionEnter : MonoBehaviour
{
    //public GameObject objects;
    public Transform rampPosition;
    
    public void Start()
    {

    }
    public void OnTriggerEnter(Collider other)
    {

        GameObject newObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newObj.transform.position = rampPosition.transform.position;
        newObj.transform.localScale = new Vector3(10.0f, 100.0f, 100.0f);
        //Instantiate(objects, rampPosition.transform.position, Quaternion.identity);
    }
}
