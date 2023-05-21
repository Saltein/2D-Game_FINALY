using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day_Night_Change : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject dayLight;

    public static bool IsDay = true;

    private Quaternion dayTime = Quaternion.Euler(0, 0, 0);
    private Quaternion nightTime = Quaternion.Euler(0, 90, 0);
    private Quaternion timeToSet;

    string strHours;
    string strMinutes;

    private int timerDays = 1;
    private int timerHours = 6;
    private int timerMinutes;

    private int startDayTime = 6;
    private int endDayTime = 18;

    private float timer;
    private float minuteTime = 0.2f;
    private float changeSpeed = 0.003f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= minuteTime)
        {
            timer -= minuteTime;
            timerMinutes += 1;
        }
        if (timerMinutes >= 60)
        {
            timerMinutes = 0;
            timerHours += 1;
        }
        if (timerHours >= 24)
        {
            timerHours = 0;
            timerDays += 1;
        }

    }

    private void FixedUpdate()
    {
        if (timerHours <= 9)
        {
            strHours = "0" + timerHours.ToString();
        } else { strHours = timerHours.ToString(); }
        if (timerMinutes <= 9)
        {
            strMinutes = "0" + timerMinutes.ToString();
        } else { strMinutes = timerMinutes.ToString(); }

        timerText.text = $"день {timerDays}:   {strHours}:{strMinutes}";

        if (timerHours == endDayTime)
        {
            IsDay = false;
            timeToSet = nightTime;
        }
        if (timerHours == startDayTime)
        {
            IsDay = true;
            timeToSet = dayTime;
        }

        dayLight.transform.rotation = Quaternion.Lerp(dayLight.transform.rotation, timeToSet, changeSpeed);
    }
}
