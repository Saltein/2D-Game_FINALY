using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private float timer = 0f;

    void Update()
    {
        if (timer > 2f)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
