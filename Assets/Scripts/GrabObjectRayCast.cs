using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjectRayCast : MonoBehaviour
{
    private RaycastHit hit;
    //private RaycastHit hit2;
    public GameObject myhero;
    public GameObject ball;
    public Transform hand;
    public Rigidbody rb;
    
    void Start()
    {
        //ball = GameObject.Find("Ball");
        rb = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 curPos = ball.transform.position;
       // Vector3 dir = curPos - new Vector3(myhero.transform.position.x, myhero.transform.position.y);
       // Ray ray = new Ray(myhero.transform.position, dir);
        Physics.Raycast(ray, out hit);
        //Physics.Raycast(ray, out hit);
        if (Input.GetKeyDown(KeyCode.R) && hit.collider.tag == "get"  && hit.distance < 100000f)
        {
            Getrigidbody();

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            AddForceRigidBody();
        }
    }
    void Getrigidbody()
    {
        ball.transform.SetParent(hand);
        ball.transform.position = hand.transform.position;
        ball.transform.rotation = hand.transform.rotation;
        rb.useGravity = false;
        rb.isKinematic = true;
    }
    void AddForceRigidBody()
    {
        rb.isKinematic = false;
        ball.transform.parent = null;
        rb.useGravity = true;
        rb.AddForce(0, 20f, 50f, ForceMode.Impulse);
    }

} 