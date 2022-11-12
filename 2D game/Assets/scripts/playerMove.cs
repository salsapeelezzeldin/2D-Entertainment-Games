using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed = 3f;
    public float jumpSpeed = 4f;
    private float movement = 0f;
    private Animator anim;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public Vector3 respawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);


        //walking through x-axis
        movement = Input.GetAxis("Horizontal");   
        if (movement > 0f)          //Walking Right
        {
            rig.velocity = new Vector2(movement * speed, rig.velocity.y);
            transform.localScale = new Vector2 (0.159353f, transform.localScale.y);      //turn right
        } 
        else if (movement < 0f)     //Walking Left
        {
            rig.velocity = new Vector2(movement * speed, rig.velocity.y); 
            transform.localScale = new Vector2 (-0.159353f, transform.localScale.y);     //turn left
        }
        else                        //Standing
        {
            rig.velocity = new Vector2(0, rig.velocity.y); 
        }


        //jumping
        if (Input.GetButtonDown ("Jump") && isTouchingGround)
        {
           rig.velocity = new Vector2 (rig.velocity.x, jumpSpeed); 
        }

        anim.SetFloat("speed", Mathf.Abs(rig.velocity.x));
        anim.SetBool("onGround", isTouchingGround);
    }

    //Fall Detector
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }

        if (other.tag == "Respawn")
        {
            respawnPoint = other.transform.position;
        }

    }


}
