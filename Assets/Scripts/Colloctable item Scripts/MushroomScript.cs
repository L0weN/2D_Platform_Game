using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    

    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.MUSHROOM_TAG)
        {
            target.gameObject.SetActive(false);
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
