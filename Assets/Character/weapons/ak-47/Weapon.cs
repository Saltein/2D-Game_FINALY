using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static bool IsFire = false;

    public Transform weapPos;
    public GameObject bullet;

    private float rate_of_fire = 0.1f;
    private float timer = 1f;

    public static int maxAmmo = 30;
    public static int ammoCount;
    public static int ammoOutCount;

    void Update()
    {
        if (Input.GetAxis("Fire1") == 1 && !AmmoScript.IsReloading)
        {
            IsFire = true;
            if (timer >= rate_of_fire && ammoCount > 0) 
            {
                Instantiate(bullet, weapPos.transform.position, weapPos.transform.rotation);
                ammoCount -= 1;
                timer = 0f;
            }
        } else { IsFire = false; }

        timer += Time.deltaTime;
    }
}
