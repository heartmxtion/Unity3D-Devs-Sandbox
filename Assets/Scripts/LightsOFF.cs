using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOFF : MonoBehaviour
{
    [SerializeField] GameObject light1;
    [SerializeField] GameObject light2;
    [SerializeField] GameObject light3;
    [SerializeField] GameObject light4;
    IEnumerator Enumerator()
    {
        light1.SetActive(false);
        yield return new WaitForSeconds(2);
        light2.SetActive(false);
        yield return new WaitForSeconds(2);
        light3.SetActive(false);
        yield return new WaitForSeconds(2);
        light4.SetActive(false);
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Enumerator());
        }
    }
}
