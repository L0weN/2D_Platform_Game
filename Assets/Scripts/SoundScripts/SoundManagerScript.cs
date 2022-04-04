using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, coinSound, shootSound;
    static AudioSource audioSrc;
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump1");
        coinSound = Resources.Load<AudioClip>("coin1");
        shootSound = Resources.Load<AudioClip>("shoot1");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump1":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "coin1":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "shoot1":
                audioSrc.PlayOneShot(shootSound);
                break;
        }
    }
}
