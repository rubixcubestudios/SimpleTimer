using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SimpleTimer : MonoBehaviour
{
    public TMP_Text timer;
    public TMP_Text TimerSet;
    public float delta_time;

    // Start is called before the first frame update
    void Start()
    {
        //delta_time = 250;
        TimerSet.text = delta_time + "Sec";
    }

    // Update is called once per frame
    void Update()
    {
        if (delta_time >= 0)
        {
            delta_time -= Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(delta_time);

            string minute = LeadingZero(span.Minutes);
            string seconds = LeadingZero(span.Seconds);
            string _Timing = minute + ":" + seconds;
            timer.text = _Timing;
        }

    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

}
