using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_control : MonoBehaviour
{
    public GameObject sun;
    public Material skyBoxMaterial;
    public Material skyBoxMaterial2;
    void Start()
    {

    }
    void Update()
    {
        Vector3 sunrotation = transform.rotation.eulerAngles;
        // sunrotation.x += 10f * Time.deltaTime;
        //transform.rotation = Quaternion.Euler(sunrotation);
        //transform.Rotate(transform.up * 360 * Time.deltaTime); 
        sun.transform.Rotate(new Vector3(10f * Time.deltaTime, 0, 0));

        if (transform.rotation.eulerAngles.x >= 20f && transform.rotation.eulerAngles.x <= 110f)
        {
            RenderSettings.skybox = skyBoxMaterial2;

        }
        else
        {
            RenderSettings.skybox = skyBoxMaterial;
        }
    }
}
