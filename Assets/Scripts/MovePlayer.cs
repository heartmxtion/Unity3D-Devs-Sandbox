using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    // private float playerSpeed = 60.0f;
    private float jumpHeight = 10.0f;
    private float gravityValue = -9.81f;
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    //public float sensitivyHor = 4.0f;
    //public float sensitivyVert = 4.0f;
    //public float minimumVert = -90f;
    //public float maximumVert = 90f;
    //private float _rotationX = 0;
    public GameObject myhero;
    CharacterController controller;
    private Vector3 lastVelocity;
   // private Rigidbody rb;
    private float BulletSpeed;
    Animator animator;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
      //  rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //lastVelocity = rb.velocity;


        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        //transform.TransformDirection(0, Input.GetAxis("Horizontal"), 0);
        // transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * 100f * Time.deltaTime, 0));
        // transform.Translate(new Vector3(0f, 0f, Input.GetAxis("Horizontal") * 100f * Time.deltaTime));

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = speed * Input.GetAxis("Vertical");
            controller.SimpleMove(forward * curSpeed);
      //  }
      //  if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
      //  {
      //      Vector3 horiz = transform.TransformDirection(Vector3.right);
      //     float curSpeed = speed * Input.GetAxis("Horizontal");
      //      controller.SimpleMove(horiz * curSpeed);
      //  }
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        //Vector3 forward = transform.TransformDirection(Vector3.forward);
       // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
       // controller.Move(move * Time.deltaTime * playerSpeed);
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
       // MouseRotation();
       
    }
    float pushPower = 200.0f;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Rigidbody body = hit.collider.attachedRigidbody;
        // Rigidbody bullet = hit.collider.attachedRigidbody;
        // if (body == null || body.isKinematic)
        // {
        //     return;
        // }
        // if(hit.moveDirection.y < 0.3)
        // {
        //     return;
        // }
        //Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        if (hit.collider.tag == "Bullet")
        {
            Vector3 pushedPlayerDir = new Vector3(hit.normal.x, 0, hit.normal.z);
            controller.Move(pushedPlayerDir * pushPower);
            // myhero.transform.Translate(pushedPlayerDir * pushPower);
        }
        if (hit.collider.tag == "Enemy")
        {
            controller.transform.position = new Vector3(-633.4f, 12.1f, -0.7f);
        }
       // body.velocity = pushDir * pushPower;
        //Vector3 CharacterPushDir = new Vector3(hit.collider.attachedRigidbody.velocity, )
        
        
    }
    //   private void OnCollisionEnter(Collision collision)
    //   {
    //       var BooletSpeed = lastVelocity.magnitude;
    //       var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
    //       rb.velocity = direction * Mathf.Max(BooletSpeed, 0f);
    //  }
    //void MouseRotation()
    //{
    //    _rotationX -= Input.GetAxis("Mouse Y") * sensitivyHor;
    //    _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
    //    float delta = Input.GetAxis("Mouse X") * sensitivyHor;
    //    float _rotationY = transform.localEulerAngles.y + delta;
    //    transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    //}
   
}   
