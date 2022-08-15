using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimplePathfinding : MonoBehaviour
{
    //Rigidbody rb;
    NavMeshAgent agent;
    [SerializeField] private Transform _target;
   // [SerializeField] private Transform _target2;
    [SerializeField] private Transform _mover;
    [SerializeField] private float _speed = 70f;
    bool targetSpotedd = false;
    Animation animation;
    public IEnumerator RandomPath()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < 100f)
            {
                float angle = Random.Range(-100, 100);
                transform.Rotate(0, angle, 0);
            }
        }
        float distance1 = Vector3.Distance(_target.position, _mover.position);
        if (distance1 > 15f && distance1 < 300f)
        {
            targetSpotedd = true;
        }
        //else targetSpotedd = false;
            yield return null;
        //   // float randomX = Random.Range(-1000f, 1000f);
        //   // float randomZ = Random.Range(-1000f, 1000f);
        //   // yield return new WaitForSeconds(4);
        //   // _target2.position += new Vector3(randomX, 180f, randomZ); //присваивается несколько значений за секунду...

        //    // сделать поворот когда рейкаст хитит объект. transform.Rotate(random);
    }
    public IEnumerator PathFinding()
    {
      
            _mover.LookAt(_target);
            agent.destination = _target.transform.position;
            transform.Translate(transform.forward*_speed*Time.deltaTime);
            agent.destination = _target.transform.position;
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
            yield return null;
        //yield return new WaitForSeconds(1);
        //Vector3 direction = new Vector3(Random.Range(-80f, 80f), Random.Range(-80f, 80f));
        //transform.Translate(direction*speed*Time.deltaTime);
        //yield return new WaitForSeconds(3);
        //transform.Translate(direction * speed * Time.deltaTime);
        //yield return new WaitForSeconds(4);
    }
    void Start()
    {
        animation = GetComponent<Animation>();
        animation.Play("Walk");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        
        //rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //StartCoroutine(PathFinding());
        if (targetSpotedd == false)
        {
            StartCoroutine(RandomPath());
        }
        if (targetSpotedd == true)
        {
            StopCoroutine(RandomPath());
            StartCoroutine(PathFinding());
            animation.Stop("Walk");
            animation.Play("Run");
        }
        //if(targetSpotedd == false)
        //{
        //    //agent.destination = _target2.transform.position;
        //    //transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        //    StartCoroutine(RandomPath());
        //}
        //if (targetSpotedd == true)
        //{
        //    StopCoroutine(RandomPath());
        //}
        //agent.SetDestination(_target.transform.position);
        //Vector3 direction = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
