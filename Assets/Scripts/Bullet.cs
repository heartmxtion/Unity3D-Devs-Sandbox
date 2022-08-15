using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public int destroy;
    //Rigidbody body;
   //[SerializeField] private GameObject myhero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Invoke("DestroyTime", destroy);
      //  myhero = GameObject.FindGameObjectWithTag("Player");
      //  body = myhero.GetComponent<Rigidbody>();

    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        // Physics.Raycast(ray, out hit);
        // if(hit.collider.CompareTag("Player"))
        // {

        // }



    }

    void DestroyTime()
    {
        Destroy(gameObject);
    }
    float pushPower = 60.0f;
    void OnCollisionEnter(Collision hit)
    {
       // if (hit.collider.CompareTag("Player"))
       // {
       //     Ray BulletDirection = new Ray(transform.position, transform.forward);
       //     
       //     Vector3 pushDir = new Vector3(BulletDirection.direction.x, BulletDirection.direction.y, BulletDirection.direction.z);
       //     myhero.transform.Translate(pushDir * pushPower);
       // }
      
            //Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            //body.velocity = pushDir * pushPower;
            Destroy(gameObject);
    }
    

}
