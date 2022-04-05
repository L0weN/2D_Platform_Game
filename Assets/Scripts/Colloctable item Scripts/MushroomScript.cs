using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.MUSHROOM_TAG)
        {
            target.gameObject.SetActive(false);
            player.GetComponent<PlayerDamage>().takeHeal();
            Vector3 tempScale = transform.localScale;
            tempScale.y = 1.1f;
            transform.localScale = tempScale;
            StartCoroutine(backNormal());
        }
    }

    IEnumerator backNormal()
    {
        yield return new WaitForSeconds(5f);
        Vector3 tempScale = transform.localScale;
        tempScale.y = 1f;
        transform.localScale = tempScale;
    }
}
