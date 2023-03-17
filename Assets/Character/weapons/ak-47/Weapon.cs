using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform weapPos;
    public GameObject bullet;

    private float rate_of_fire = 0.1f;

    private float timer = 1f;

    void Update()
    {
        if (Input.GetAxis("Fire1") == 1)
        {
            if (timer >= rate_of_fire)
            {
                Instantiate(bullet, weapPos.transform.position, weapPos.transform.rotation);
                timer = 0f;
            }
        }
        timer += Time.deltaTime;
    }
}
