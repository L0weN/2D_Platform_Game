using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    void Start()
    {

    }

    void Update()
    {

    }
    
    void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");
        print("Value is " + h);

        if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        }

    }
}
