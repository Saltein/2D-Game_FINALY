using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCircle : MonoBehaviour
{
    float timer;
    public static int kara = 0;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            kara = 1;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            kara = 0;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (kara == 1&& timer > 1)
        {
            PlayerManager.Damage(5);
            timer = 0;
        }
       
    }
}
