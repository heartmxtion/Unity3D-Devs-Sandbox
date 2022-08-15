using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float Speed = 0.3f;
    private Rigidbody _rb;
    public GameObject myhero;
    public float sensitivyHor = 4.0f;
    public float sensitivyVert = 4.0f;
    public float minimumVert = -90f;
    public float maximumVert = 90f;
    private float _rotationX = 0;


    void Start()
    {
        _rb = myhero.GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        MouseRotation();
        PlayerControl();
        GroundCheck();
    }
    void MouseRotation()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivyHor;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        float delta = Input.GetAxis("Mouse X") * sensitivyHor;
        float _rotationY = transform.localEulerAngles.y + delta;
        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    }
    void PlayerControl()
    {
        myhero.transform.Translate(new Vector3(0f, 0f, Input.GetAxis("Vertical") * 100f * Time.deltaTime));
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * 100f * Time.deltaTime, 0));
    }
    void GroundCheck()
    {
        bool isGrounded;
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);
        if (Physics.Raycast(myhero.transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&(isGrounded == true))
        {
            _rb.AddForce(0, 30f, 0, ForceMode.Impulse);
        }
    }
}
