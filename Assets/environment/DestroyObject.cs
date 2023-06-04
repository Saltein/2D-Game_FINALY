using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float destroyTime = 15f;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
