using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Day_Night_Change : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject dayLight;
    [SerializeField] private GameObject timerObject;

    public static bool IsDay = true;
    public static string bedMessage = "ÍÅ ÂÐÅÌß ÑÏÀÒÜ!";

    private Quaternion dayTime = Quaternion.Euler(0, 0, 0);
    private Quaternion nightTime = Quaternion.Euler(0, 90, 0);
    private Quaternion timeToSet;

    string strHours;
    string strMinutes;

    public static int timerDays = 1;
    public static int timerHours = 6;
    public static int timerMinutes;

    public static int startDayTime = 6;
    public static int endDayTime = 18;

    public static float timer;
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


        if (InventoryScript.IsOpen)
        {
            timerObject.SetActive(false);
        }
        else { timerObject.SetActive(true); }
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

        timerText.text = $"äåíü {timerDays}:   {strHours}:{strMinutes}";

        if (timerHours == endDayTime)
        {
            IsDay = false;
            bedMessage = "ÂÛ ÏÐÎÑÏÀËÈ ÄÎ ÍÎ×È";
            timeToSet = nightTime;
        }
        if (timerHours == startDayTime)
        {
            IsDay = true;
            bedMessage = "[E] - ÑÏÀTÜ";
            timeToSet = dayTime;
        }

        dayLight.transform.rotation = Quaternion.Lerp(dayLight.transform.rotation, timeToSet, changeSpeed);
    }
}
