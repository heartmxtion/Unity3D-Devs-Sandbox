using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOpenDoor : MonoBehaviour
{
    public Renderer rend;
    public BoxCollider bColl;
    public HingeJoint hj;
    public GameObject stolb;
    void Start()
    {
        //rend = GetComponent<Renderer>();
        bColl = GetComponent<BoxCollider>();
        hj = stolb.GetComponent<HingeJoint>();
    }


    void Update()
    {
                
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
    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            OpenDoor();
        }
    }
}
