using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{

    public CharacterController controller ;

    public float speed = 12f; 
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask voidMask;
    public float jumpHeight = 3f;
    public Vector3 respawn = new Vector3(0f,0f,0f);
    public static int increment = 0;

    Vector3 velocity;
    bool isGrounded;
    bool vide;

    void Start()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "piece")
        {   
            increment+= 1;
            Debug.Log(increment);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right  * x + transform.forward * z; 
        controller.Move(move* speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity *Time.deltaTime);



        vide = Physics.CheckSphere(groundCheck.position, groundDistance, voidMask);
        if(vide)
        {
            gameObject.transform.position = respawn;
            //vie = 0
        }
        //Debug.Log(vide);



    }
}
