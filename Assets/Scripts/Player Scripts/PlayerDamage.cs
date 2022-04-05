using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public int healthCount;
    private Text healthText;

    private bool canTakeDamage;
    
    void Awake()
    {
        healthText = GameObject.Find("Health Text").GetComponent<Text>();
        healthCount = 3;
        healthText.text = "x" + healthCount;

        canTakeDamage = true;
    }

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        
    }

    public void takeDamage()
    {
        if (canTakeDamage)
        {
            healthCount--;
            if (healthCount >= 0)
            {
                healthText.text = "x" + healthCount;
            }
            if (healthCount == 0)
            {
                Time.timeScale = 0;
                StartCoroutine(RestartTheGame());
            }
            canTakeDamage = false;
            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(3f);
        canTakeDamage = true;

    }

    IEnumerator RestartTheGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Game");
    }
}
