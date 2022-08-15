using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mayatnik : MonoBehaviour
{
    HingeJoint hj;
    bool motorUsing = true;
    float nextActionTime = 0.1f;
    float motorPeriod = 8f;

    void Start()
    {
        hj = GetComponent<HingeJoint>();
        hj.useMotor = motorUsing;
    }

    void Update()
    {
        if(Time.time > nextActionTime)
        {
            nextActionTime += motorPeriod;
            hj.useMotor = !hj.useMotor;
            //Vector3 myrotation = transform.rotation.eulerAngles;
            //myrotation.y += 180;
            //transform.rotation = Quaternion.Euler(myrotation);
        }
        
    }
}
