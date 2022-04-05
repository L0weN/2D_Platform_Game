using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleEnd : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.PLAYER_TAG)
        {
            StartCoroutine(loadEndGame());
        }
    }
    IEnumerator loadEndGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("EndGame");
    }
}
