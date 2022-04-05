using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OctopusScripts : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == MyTags.PLAYER_TAG)
        {
            StartCoroutine(RestartTheGame());
        }
    }

    IEnumerator RestartTheGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Game");
    }
}
