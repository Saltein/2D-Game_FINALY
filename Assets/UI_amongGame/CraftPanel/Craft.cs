using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    // ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ ÁÈÍÒ
    int bandageHP = 20;
    public void CraftBandage()
    {
        if (InventoryScript.ragAm >= 2)
        {
            InventoryScript.bandageCount += 1;
            InventoryScript.ragAm -= 2;
        }
    }
    public void UseBandage()
    {
        if (InventoryScript.bandageCount >= 1)
        {
            if (PlayerManager.playerHP < 100) { InventoryScript.bandageCount -= 1; }
            if (PlayerManager.playerHP <= 100 - bandageHP)
            {
                PlayerManager.playerHP += bandageHP;
            }
            else
            {
                if (PlayerManager.playerHP < 100 || PlayerManager.playerHP > 100 - bandageHP)
                {
                    PlayerManager.playerHP = 100;
                }
            }            
        }
    }

    private void Update()
    {
        Debug.Log(InventoryScript.scrapAm);
    }

    // ÊÎËŞ×Àß ÏĞÎÂÎËÎÊÀ  ÊÎËŞ×Àß ÏĞÎÂÎËÎÊÀ  ÊÎËŞ×Àß ÏĞÎÂÎËÎÊÀ  ÊÎËŞ×Àß ÏĞÎÂÎËÎÊÀ  ÊÎËŞ×Àß ÏĞÎÂÎËÎÊÀ
    [SerializeField] private GameObject barbedWire;
    public void CraftBarbedWire()
    {
        if (InventoryScript.scrapAm >= 8)
        {
            InventoryScript.barbedWireCount += 1;
            InventoryScript.scrapAm -= 8;
        }
    }
    public void UseBarbedWire()
    {
        if (InventoryScript.barbedWireCount >= 1)
        {
            Debug.Log("Èñïîëüçîâàë ÊÎËŞ×Àß ÏĞÎÂÎËÎÊÀ");
            Instantiate(barbedWire);
            InventoryScript.barbedWireCount -= 1;
            InventoryScript.IsOpen = false;
        }
    }
}
