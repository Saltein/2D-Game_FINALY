using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaLootScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            switch (gameObject.tag)
            {
                case "Scrap":
                    InventoryScript.scrapAm += 1;
                    break;
                case "Rag":
                    InventoryScript.ragAm += 1;
                    break;
                case "Chemicals":
                    InventoryScript.chemicAm += 1;
                    break;
                case "Wood":
                    InventoryScript.woodAm += 1;
                    break;
                case "Bricks":
                    InventoryScript.brickAm += 1;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
