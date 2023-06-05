using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class maradeur1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject loot_a_house;
    [SerializeField] GameObject gratz;
    [SerializeField] UnityEngine.UI.Image progressBar;


    int inhouse = 0;
    float timer = 0f;
    float timer2 = 0f;
    float progressTime = 3f;
    float barLenght;
    int looted = 0;

    int scrap, chemic, rag, wood, brick;
    // Update is called once per frame
    private void Start()
    {
        barLenght = progressBar.rectTransform.rect.width;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            loot_a_house.SetActive(false);
            inhouse = 0;

        }

        scrap = Random.Range(2, 4);
        chemic = Random.Range(1, 4);
        rag = Random.Range(2, 3);
        wood = Random.Range(1, 5);
        brick = Random.Range(1, 5);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            loot_a_house.SetActive(true);
            inhouse = 1;
        }

    }

    private void Update()
    {

        if (inhouse == 1 && Input.GetKey(KeyCode.E) && looted != 1)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);

            if (timer >= progressTime)
            {
                timer = 0;
                InventoryScript.brickAm += brick;
                InventoryScript.chemicAm += chemic;
                InventoryScript.ragAm += rag;
                InventoryScript.woodAm += wood;
                InventoryScript.scrapAm += scrap;

                looted = 1;
                loot_a_house.SetActive(false);
            }
        }

        else if (Input.GetKeyUp(KeyCode.E)) { timer = 0f; }

        if (progressBar.rectTransform.rect.width <= barLenght)
        {
            progressBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, timer * barLenght / progressTime);
        }
        else { progressBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0); }

        if (looted == 1)
        {
            timer2 += Time.deltaTime;
            if (timer2 < 10 && inhouse == 1)
            {
                gratz.SetActive(true);
            }
            if (timer2 > 10 || inhouse != 1)
            {
                gratz.SetActive(false);
            }
        }




    }

}
