using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class prayToLenin : MonoBehaviour
{
    [SerializeField] GameObject Pray;
    [SerializeField] GameObject gratz;
    [SerializeField] UnityEngine.UI.Image progressBar;
    [SerializeField] GameObject WarningText;

    int nearLenin = 0;
    float timer = 0f;
    float progressTime = 3f;
    int praycount = 0;
    float barLenght;

    private void Start()
    {
        barLenght = progressBar.rectTransform.rect.width;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody" )
        {
            Pray.SetActive(false);
            nearLenin = 0;
            gratz.SetActive(false);
        }
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody" && praycount < 10)
        {
            Pray.SetActive(true);
            nearLenin = 1;   
        }
        else if (collision.gameObject.tag == "playerBody" && praycount >= 10)
        {
            gratz.SetActive(true);
        }
    }

   private void Update()
    {
        if(praycount < 10)
        {
            if (nearLenin == 1 && Input.GetKey(KeyCode.E))
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
                if (timer >= progressTime)
                {
                    timer = 0;
                    praycount += 1;

                }
            }
            else if (Input.GetKeyUp(KeyCode.E)) { timer = 0f; }

            if (progressBar.rectTransform.rect.width <= barLenght)
            {
                progressBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, timer * barLenght / progressTime);
            }
            else { progressBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0); }

            if (praycount >= 10)
            {
                PlayerManager.playerHP = 200;
                ZombieManager.damage_amplification = 1.5f;
            }
        }
        
    }
   
}
