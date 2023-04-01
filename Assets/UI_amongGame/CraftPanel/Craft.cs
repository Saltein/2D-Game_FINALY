using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
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
}
