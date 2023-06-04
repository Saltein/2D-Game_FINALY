using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killercircle : MonoBehaviour
{
 
    int kara2_0 = 0;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            kara2_0 = 1;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            kara2_0 = 0;
        }
    }
    private void Update()
    {
        
        if (kara2_0 == 1)
        {
            PlayerManager.Damage(20);
           
        }

    }
}
