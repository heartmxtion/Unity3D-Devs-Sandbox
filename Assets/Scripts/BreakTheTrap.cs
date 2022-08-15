using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTheTrap : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    public Transform enemyPos2;
    public Renderer rend;
    public HingeJoint hj;
    public GameObject mainobj;
    bool mouseEntered;
    void Start()
    {
        hj = mainobj.GetComponent<HingeJoint>();
    }

    void Update()
    {
        Break();
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
    void Break()
    {
        if (Input.GetKey(KeyCode.H) && (mouseEntered == true))
        {
            hj.breakForce = 1f;
            Instantiate(enemy, enemyPos.transform.position, Quaternion.identity);
            Instantiate(enemy, enemyPos2.transform.position, Quaternion.identity);
        }
    }
}
