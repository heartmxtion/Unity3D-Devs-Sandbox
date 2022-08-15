using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shotpos;
    
    public float StartTimeFire;
    private float TimeFire;
    private RaycastHit hit;
    void Start()
    {
        TimeFire = StartTimeFire;   
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if(TimeFire <= 0)
            {
                Instantiate(Bullet, shotpos.transform.position, transform.rotation);
                TimeFire = StartTimeFire;
            }
            else
            {
                TimeFire -= Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            Physics.Raycast(ray, out hit);
            if(hit.collider.tag == "Enemy")
            {
                string enemyName = hit.collider.gameObject.name;
                GameObject enemy = GameObject.Find(enemyName);
                Destroy(enemy, 1f);
            }

        }
    }
}
