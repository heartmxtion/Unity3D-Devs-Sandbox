using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTheRamp : MonoBehaviour
{
    public GameObject objects;
    public Transform rampPosition;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
          Instantiate(objects, rampPosition.transform.position, Quaternion.identity);
        }
    }
}
