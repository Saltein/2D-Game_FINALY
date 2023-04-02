using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    int zombieHP;

    private void Start()
    {
        zombieHP = 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bullet_ak-47":
                zombieHP -= 40;
                break;

            case "bullet_turret":
                zombieHP -= 70;
                break;
        }

        if (zombieHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
