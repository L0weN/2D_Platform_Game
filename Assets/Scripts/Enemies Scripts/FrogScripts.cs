using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScripts : MonoBehaviour
{
    private Animator anim;

    private bool animation_Started;
    private bool animation_Finished;

    private int jumpedTimes;
    private bool jumpLeft = true;

    public LayerMask playerLayer;

    private GameObject player;

    private string coroutine_Name = "FrogJump";

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(coroutine_Name);
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer))
        {
            player.GetComponent<PlayerDamage>().takeDamage();
        }
    }

    void LateUpdate()
    {
        if(animation_Finished && animation_Started)
        {
            animation_Started = false;

            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        animation_Started = true;
        animation_Finished = false;
        
        jumpedTimes++;

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }
        StartCoroutine(coroutine_Name);
    }
    void AnimationFinished()
    {
        animation_Finished=true;
        if (jumpLeft)
        {
            anim.Play("FrogIdleLeft");
        }
        else
        {
            anim.Play("FrogIdleRight");
        }

        if(jumpedTimes == 3)
        {
            jumpedTimes = 0;
            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;
            jumpLeft = !jumpLeft;
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.BULLET_TAG)
        {
            anim.Play("FrogDead");
            StartCoroutine(FrogDead());
        }
        
    }
    IEnumerator FrogDead()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
