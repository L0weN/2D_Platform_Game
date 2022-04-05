using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;
    private Animator anim;

    public Transform groundCheckPosition;
    public LayerMask groudLayer;

    private bool isGrounded;
    private bool jumped;
    private bool takenDamage;
    private bool rightWalk;
    private bool canWalk = true;
    private float jumpPower = 12f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    void Start()
    {
        rightWalk = true;
    }

    void Update()
    {
       CheckIfGrounded();
        PlayerJump();
    }
    
    void FixedUpdate()
    {
        PlayerWalk();
    }

    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (canWalk)
        {
            if (h > 0)
            {
                myBody.velocity = new Vector2(speed, myBody.velocity.y);
                ChangeDirection(1);
                rightWalk = true;
            }
            else if (h < 0)
            {
                myBody.velocity = new Vector2(-speed, myBody.velocity.y);
                ChangeDirection(-1);
                rightWalk=false;
            }
            else
            {
                myBody.velocity = new Vector2(0f, myBody.velocity.y);
            }
            anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));
        }
        

    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groudLayer);

        if (isGrounded)
        {
            if (jumped)
            {
                jumped = false;

                anim.SetBool("Jump", false);
            }
        }
    }

    void PlayerJump()
    {
        if (isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
                jumped = true;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
                anim.SetBool("Jump", true);
                SoundManagerScript.PlaySound("jump1");
            }
        }
    }

    public void playerTakeDamage()
    {
        if (!takenDamage)
        {
            anim.SetBool("Damage", true);
            if (rightWalk)
            {
                myBody.velocity = new Vector2(-5f, 5f);
            }
            else
            {
                myBody.velocity = new Vector2(5f, 5f);
            }
            
        }
        takenDamage = true;
        canWalk = false;
        StartCoroutine(takeDamage());
    }

    IEnumerator takeDamage()
    {
        yield return new WaitForSeconds(2f);
        takenDamage = false;
        canWalk = true;
        anim.SetBool("Damage", false);
    }

}
