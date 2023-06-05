using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestroyGrenade : MonoBehaviour
{
    float destroyTime = 0.2f;
    float timer;

    private void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= destroyTime)
        {
            timer = 0f;
            Destroy(gameObject);
        }
    }
}
