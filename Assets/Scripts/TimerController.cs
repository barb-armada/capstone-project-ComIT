using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float duration;
    private float timeRemaining;
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI timeUI2;
    

    public TextMeshProUGUI customHour;
    public TextMeshProUGUI customMin;

    public Button increaseHour;
    public Button decreaseHour;

    public Button increaseMin;
    public Button decreaseMin;

    private int h;
    private int m;

    // Start is called before the first frame update
    void Start()
    {
        customHour.text = "00";
        customMin.text = "00";        
    }

    // Update is called once per frame
    void Update()
    {        
        timeRemaining -= Time.deltaTime; // Decreases every time Update() updates to represent the time since the start button has been pressed

        // Calculate hours, minutes, seconds, from timeRemaining variable
        // % operator returns the division remainder
        // (int) convert float to int to discard decimals 
        int hour = (int)(timeRemaining / 3600f);
        int min = (int)(timeRemaining % 3600f) / 60;
        int sec = (int)(timeRemaining % 60f);

        timeUI.text = hour.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
        timeUI2.text = timeUI.text;

        if (timeRemaining <= 0)
        {            
            Application.Quit();
        }
    }

    public void SetDuration(float d)
    {
        timeRemaining = d;
        timeUI.gameObject.SetActive(true);        
        timeUI2.gameObject.SetActive(true);
    }

    public void SetMinutes_5()
    {
        duration = 300f;
        SetDuration(duration);
    }
    public void SetMinutes_10()
    {
        duration = 600f;
        SetDuration(duration);
    }
    public void SetMinutes_15()
    {
        duration = 900f;
        SetDuration(duration);
    }
    public void SetMinutes_30()
    {
        duration = 1800f;
        SetDuration(duration);
    }
    public void SetMinutes_45()
    {
        duration = 2700f;
        SetDuration(duration);
    }
    public void SetHour_1()
    {
        duration = 3600f;
        SetDuration(duration);
    }
    public void SetHour_2()
    {
        duration = 7200f;
        SetDuration(duration);
    }
    public void SetHour_4()
    {
        duration = 14400f;
        SetDuration(duration);
    }

    public void CancelTimer()
    {
        timeUI.gameObject.SetActive(false);
        timeUI2.gameObject.SetActive(false);
    }

    public void IncrementHour()
    {
        h = int.Parse(customHour.text);
        if (customHour.text != null)
        {
            h++;
            customHour.text = h.ToString("00");
            if (h > 23)
            {
                customHour.text = "00";
            }
        }

    }
    public void DecrementHour()
    {
        h = int.Parse(customHour.text);
        if (customHour.text != null)
        {
            h--;
            customHour.text = h.ToString("00");
            if (h < 0)
            {
                customHour.text = "23";
            }
        }

    }

    public void IncrementMin()
    {
        m = int.Parse(customMin.text);
        if (customMin.text != null)
        {
            m++;
            customMin.text = m.ToString("00");
            if (m > 59)
            {
                customMin.text = "00";
            }
        }
    }
    public void DecrementMin()
    {
        m = int.Parse(customMin.text);
        if (customMin.text != null)
        {
            m--;
            customMin.text = m.ToString("00");
            if (m <= 0)
            {
                customMin.text = "59";
            }
        }
    }

    public void SetCustomTime()
    {
        h = int.Parse(customHour.text);
        m = int.Parse(customMin.text);
        float dur = ((float)h * 3600f) + ((float)m * 60f);
        SetDuration(dur);
        
    }
}
