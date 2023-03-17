using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPScounter : MonoBehaviour
{
    [SerializeField] private Text FPS;
    private float frames;
    private float seconds;
    private float fps;

    private void Start()
    {
        frames = 0f;
        seconds = 0f;
    }

    void Update()
    {
        frames++;
        seconds += Time.deltaTime;
        fps = frames / seconds;
        FPS.text = "FPS: " + Mathf.Round(fps).ToString();

        if (seconds >= 1)
        {
            frames = 0f;
            seconds = 0f;
        }
    }
}
