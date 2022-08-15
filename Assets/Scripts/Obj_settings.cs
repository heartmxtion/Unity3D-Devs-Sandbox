using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_settings : MonoBehaviour
{
    public Renderer rend;
    public BoxCollider bColl;
    public HingeJoint hj;
    public GameObject stolb;
    bool mouseEntered;

    //public GameObject fonari;
    void Start()
    {
        rend = GetComponent<Renderer>();
        bColl = GetComponent<BoxCollider>();
        hj = stolb.GetComponent<HingeJoint>();
        
    }

    void Update()
    {
       // if (Input.GetKey(KeyCode.K))
       // {
       //     rend.material.color = Color.red;
       // }
       // else rend.material.color = Color.white;
        if (Input.GetKey(KeyCode.J))
        {
            bColl.isTrigger = true;
        }
        else bColl.isTrigger = false;
        //if (Input.GetKey(KeyCode.H))
        //{
        //    for (var i = 0; i == fonari.transform.childCount; i++)
        //        fonari.transform.GetChild(i).GetComponent<Renderer>();
        //        // fonari.lig


        //}
        //else
        //{
        //    for (var i = 0; i == fonari.transform.childCount; i++)
        //        fonari.transform.GetChild(i).GetComponent<Renderer>();
        //        //fonari.enabled = true;
        //}
        //OpenDoor();
    }
    void OnMouseEnter()
    {
        mouseEntered = true;
        rend.material.color = Color.red;
        
    }
    void OnMouseExit() 
    {
        mouseEntered = false;
        rend.material.color = Color.white;
    }
    void OpenDoor()
    {
        if (Input.GetKey(KeyCode.H))
        {
            var motor = hj.motor;
            motor.targetVelocity = -10f;
            hj.motor = motor;
        }
        else
        {
            var motor = hj.motor;
            motor.targetVelocity = 10f;
            hj.motor = motor;
        }
    }
  // private void OnTriggerStay(Collider other)
  //  {

    //        OpenDoor();
    //}
}
