using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BedScript : MonoBehaviour
{
    [SerializeField] GameObject sleepText;
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] UnityEngine.UI.Image progressBar;

    private float timer = 0f;
    private float progressTime = 3f;
    private float barLenght;

    private bool IsNearBed = false;

    private void Start()
    {
        barLenght = progressBar.rectTransform.rect.width;
    }

    private void Update()
    {
        if (IsNearBed && Input.GetKey(KeyCode.E))
        {           
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= progressTime)
            {
                SleepUntill(Day_Night_Change.endDayTime);
            }
        }
        else if (Input.GetKeyUp(KeyCode.E)) { timer = 0f; }

        if (progressBar.rectTransform.rect.width <= barLenght && Day_Night_Change.IsDay)
        {
            progressBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, timer * barLenght / progressTime);
        }
        else { progressBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0); }

        messageText.text = Day_Night_Change.bedMessage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerBody")
        {
            sleepText.SetActive(true);
            IsNearBed = true;
        }           
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "playerBody")
        {
            sleepText.SetActive(false);
            IsNearBed = false;
        }            
    }

    void SleepUntill(int time)
    {
        if (Day_Night_Change.timerHours < Day_Night_Change.endDayTime && Day_Night_Change.timerHours >= Day_Night_Change.startDayTime)
            Day_Night_Change.timerHours = time;
    }
}
