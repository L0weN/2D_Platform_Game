using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{
    public Transform bottomCollision;
    private Animator anim;
    public LayerMask playerLayer;
    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnimate;
    private bool canAnimate = true;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        originPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += 0.15f;

    }

    void Update()
    {
        CheckForCollision();
        Animate();
    }

    void CheckForCollision()
    {
        if (canAnimate)
        {
            RaycastHit2D hit = Physics2D.Raycast(bottomCollision.position, Vector2.down, 0.1f, playerLayer);
            if (hit)
            {
                if (hit.collider.gameObject.tag == MyTags.PLAYER_TAG)
                {
                    anim.Play("BlockIdle");
                    startAnimate = true;
                    canAnimate = false;
                }
            }
        }
    }

    void Animate()
    {
        if (startAnimate)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime);
            if(transform.position.y >= animPosition.y)
            {
                moveDirection = Vector3.down;
            }
            else if (transform.position.y <= originPosition.y)
            {
                startAnimate = false;
            }
        }
    }
}
