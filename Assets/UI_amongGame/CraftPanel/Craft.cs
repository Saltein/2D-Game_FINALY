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

    // ÊÎËÞ×Àß ÏÐÎÂÎËÎÊÀ  ÊÎËÞ×Àß ÏÐÎÂÎËÎÊÀ  ÊÎËÞ×Àß ÏÐÎÂÎËÎÊÀ  ÊÎËÞ×Àß ÏÐÎÂÎËÎÊÀ  ÊÎËÞ×Àß ÏÐÎÂÎËÎÊÀ
    [SerializeField] private GameObject barbedWire;
    public void CraftBarbedWire()
    {
        if (InventoryScript.scrapAm >= 8)
        {
            InventoryScript.barbedWireCount += 1;
            InventoryScript.scrapAm -= 8;
            PlayerManager.PlayerScore += 5;
        }
    }
    public void UseBarbedWire()
    {
        if (InventoryScript.barbedWireCount >= 1)
        {
            Instantiate(barbedWire);
            InventoryScript.barbedWireCount -= 1;
            InventoryScript.IsOpen = false;
            PlayerManager.PlayerScore += 10;
        }
    }

    // ÊÈÐÏÈ×ÍÀß ÑÒÅÍÀ  ÊÈÐÏÈ×ÍÀß ÑÒÅÍÀ  ÊÈÐÏÈ×ÍÀß ÑÒÅÍÀ  ÊÈÐÏÈ×ÍÀß ÑÒÅÍÀ  ÊÈÐÏÈ×ÍÀß ÑÒÅÍÀ  ÊÈÐÏÈ×ÍÀß ÑÒÅÍÀ 
    [SerializeField] private GameObject brickWall;
    public void CraftBrickWall()
    {
        if (InventoryScript.brickAm >= 8)
        {
            InventoryScript.brickWallCount += 1;
            InventoryScript.brickAm -= 8;
            PlayerManager.PlayerScore += 5;
        }
    }
    public void UseBrickWall()
    {
        if (InventoryScript.brickWallCount >= 1)
        {
            Instantiate(brickWall);
            InventoryScript.brickWallCount -= 1;
            InventoryScript.IsOpen = false;
            PlayerManager.PlayerScore += 10;
        }
    }

    // ÏÀÒÐÎÍÛ 7.62  ÏÀÒÐÎÍÛ 7.62  ÏÀÒÐÎÍÛ 7.62  ÏÀÒÐÎÍÛ 7.62  ÏÀÒÐÎÍÛ 7.62  ÏÀÒÐÎÍÛ 7.62  ÏÀÒÐÎÍÛ 7.62 
    public void CraftAmmo7_62()
    {
        if (InventoryScript.scrapAm >= 3 && InventoryScript.chemicAm >= 2)
        {
            Weapon.ammoOutCount += 30;
            InventoryScript.scrapAm -= 3;
            InventoryScript.chemicAm -= 2;
        }
    }
}
