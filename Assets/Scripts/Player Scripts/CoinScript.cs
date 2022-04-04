using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    private Text coinText;
    private int score;
  
    void Awake()
    {
        
    }

    void Start()
    {
        coinText = GameObject.Find("Coin Text").GetComponent<Text>();

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == MyTags.COIN_TAG)
        {
            target.gameObject.SetActive(false);
            score++;
            coinText.text = "x" + score;
            SoundManagerScript.PlaySound("coin1");
        }
    }
}
