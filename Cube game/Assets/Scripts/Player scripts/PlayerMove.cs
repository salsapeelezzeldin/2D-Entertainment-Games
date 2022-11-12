using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float moveSpeed = 2f;
    private Vector2 touchOrigin;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = 0f;
        horizontal = Input.GetAxisRaw("Horizontal");

        //controls movement on cursor arrow press
        if (horizontal > 0f)
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }
        //controls movement on cursor arrow press
        if (horizontal < 0f)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }

    }

    //Used on moving platforms
    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
