using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScripts : MonoBehaviour
{
    private float currentTime;
    public Text time;

    void Start()
    {
       time = GameObject.Find("Time").GetComponent<Text>();
    }

    void Update()
    {
        currentTime += 1f * Time.deltaTime;
        time.text = currentTime.ToString("0") + " sn";
    }
}
