using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    int damageCount = 0;
    float damageTime = 0.5f;

    float timer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        if (timer >= damageTime && collision.gameObject.tag == "playerBody")
        {
            PlayerManager.Damage(damageCount);
            timer = 0;
        }
        if (timer >= damageTime && collision.gameObject.tag == "mainTarget")
        {
            LeninManager.Damage(damageCount);
            timer = 0;
        }
        
    }
}
