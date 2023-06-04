using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prayToLenin : MonoBehaviour
{
    [SerializeField] GameObject Pray;
    /// [SerializeField] UnityEngine.UI.Image progressBar;
   /// [SerializeField] GameObject WarningText;

    int nearLenin = 0;
    float timer = 0f;
    float progressTime = 3f;
    int praycount = 0;
    float barLenght;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            Pray.SetActive(true);
            nearLenin = 1;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            Pray.SetActive(false);
            nearLenin = 0;
        }
    }

   /* private void Update()
    {
        if (nearLenin == 1 && Input.GetKey(KeyCode.E))
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= progressTime)
            {
                praycount += 1;
                WarningText.SetActive(true);

            }
        }
        else if (Input.GetKeyUp(KeyCode.E)) { timer = 0f; }

        if (progressBar.rectTransform.rect.width <= barLenght && Day_Night_Change.IsDay)
        {
            progressBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, timer * barLenght / progressTime);
        }
        else { progressBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0); }

    }
   */
}
