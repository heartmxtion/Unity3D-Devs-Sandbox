using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public Transform hand;
    public Rigidbody rbb;
    void Start()
    {
        rbb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            getrigidbody();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddForceRigidBody();
        }
    }
    void getrigidbody()
    {
        transform.SetParent(hand);
        transform.position = hand.transform.position + new Vector3(0f, 14f, -18f);
        transform.rotation = hand.transform.rotation;
        rbb.useGravity = false;
        rbb.isKinematic = true;
    }
    void AddForceRigidBody()
    {
        rbb.isKinematic = false;
        transform.parent = null;
        rbb.useGravity = true;
        rbb.AddForce(0, 0, 30f, ForceMode.Impulse);
    }
}
