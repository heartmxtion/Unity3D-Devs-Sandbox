using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsTrap : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shotpos;
    public float StartTimeFire;
    private float TimeFire;

    float speed = 20f;
    public float minX;
    public float maxX;
    bool moveingRight = true;
    bool startShoot = false;
    IEnumerator Numerator()
    {
        yield return new WaitForSeconds(3);
        startShoot = true;
        //TimeFire = StartTimeFire;
    }
    void Start()
    {

    }

    void Update()
    {
        Move();
        if (startShoot == true)
        {
            Shoot();
        }
    }
    void Move()
    {
        if (transform.position.x > maxX)
        {
            moveingRight = false;
        }
        else if (transform.position.x < minX)
        {
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
    void Shoot()
    {
        if (TimeFire <= 0)
        {
            Instantiate(Bullet, shotpos.transform.position, transform.rotation);
            TimeFire = StartTimeFire;
        }
        else
        {
            TimeFire -= Time.deltaTime;
        }
    }
    public void OnCollisionEnter(Collision other) //похоже что не реагирует на касание не через коллайдер энтер, не через тригер .
    {
        if (other.collider.tag == "StartShooting")
        {
            StartCoroutine(Numerator());
        }
    }
}
    