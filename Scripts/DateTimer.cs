using System;
using TMPro;
using UnityEngine;

public class DateTimer : MonoBehaviour
{
    public TMP_Text timer;
    public TMP_Text newDate;
    public TMP_Text oldDate;
    public bool isSetNewTime = false;

    public void Start()
    {
        if (isSetNewTime)
        {
            string newStringDate = Convert.ToString(System.DateTime.Now);
            PlayerPrefs.SetString("PlayDate", newStringDate);
            Debug.Log("New Times: " + newStringDate);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {

        string stringDate = PlayerPrefs.GetString("PlayDate");
        System.DateTime dateToGo = Convert.ToDateTime(stringDate).AddDays(3);
        System.DateTime DateIsNow = System.DateTime.Now;
        TimeSpan span = dateToGo.Subtract(DateIsNow);

        oldDate.text = dateToGo.ToString();
        newDate.text = DateIsNow.ToString();

        if (span.Ticks >= 0)
        {
            string dates = LeadingZero(span.Days);
            string hour = LeadingZero(span.Hours);
            string minute = LeadingZero(span.Minutes);
            string seconds = LeadingZero(span.Seconds);
            string time = dates + ":" + hour + ":" + minute + ":" + seconds;
            timer.text = time;

        }

        //Reward your Player When Timer Runs Out
        if (span.Ticks < 0)
        {
            PlayerPrefs.DeleteKey("PlayDate");
        }


    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
