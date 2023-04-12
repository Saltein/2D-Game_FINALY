using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    

    

    public void SaveGame() ///����������
    {
        
        PlayerPrefs.SetInt("SavedHP", PlayerManager.playerHP);
        

        Debug.Log("PlayerManager.playerStamina");

        PlayerPrefs.SetInt("SavedbandageCount", InventoryScript.bandageCount);       /// ��������� ����������
        PlayerPrefs.SetInt("SavedbarbedWireCount", InventoryScript.barbedWireCount);
        PlayerPrefs.SetInt("SavedbrickWallCount", InventoryScript.brickWallCount);
        PlayerPrefs.SetInt("Savedammo7_62Count", InventoryScript.ammo7_62Count);
        PlayerPrefs.SetInt("SavedscrapAm", InventoryScript.scrapAm);
        PlayerPrefs.SetInt("SavedchemicAm", InventoryScript.chemicAm);
        PlayerPrefs.SetInt("SavedragAm", InventoryScript.ragAm);
        PlayerPrefs.SetInt("SavedwoodAm", InventoryScript.woodAm);
        PlayerPrefs.SetInt("SavedbrickAm", InventoryScript.brickAm);

        PlayerPrefs.SetInt("SavedammoCount", Weapon.ammoCount);
        PlayerPrefs.SetInt("SavedammoOutCount", Weapon.ammoOutCount);

        PlayerPrefs.SetFloat("PosPX", PlayerManager.currentTrans.position.x); /// ������� � ������� ����������
        PlayerPrefs.SetFloat("PosPY", PlayerManager.currentTrans.position.y);
        PlayerPrefs.SetFloat("PosPZ", PlayerManager.currentTrans.position.z);
        PlayerPrefs.SetFloat("PosRX", PlayerManager.currentTrans.rotation.x);
        PlayerPrefs.SetFloat("PosRY", PlayerManager.currentTrans.rotation.y);
        PlayerPrefs.SetFloat("PosRZ", PlayerManager.currentTrans.rotation.z);

        PlayerPrefs.Save();
        Debug.Log("Game data saved!");

        

    }


   public void LoadGame() /// ����������
    {
        if (PlayerPrefs.HasKey("SavedHP"))
        {
            PlayerManager.playerHP = PlayerPrefs.GetInt("SavedHP");
            

            InventoryScript.bandageCount = PlayerPrefs.GetInt("SavedbandageCount");       /// ��������� ��������
            InventoryScript.barbedWireCount = PlayerPrefs.GetInt("SavedbarbedWireCount");
            InventoryScript.brickWallCount = PlayerPrefs.GetInt("SavedbrickWallCount");
            InventoryScript.scrapAm = PlayerPrefs.GetInt("Savedammo7_62Count");
            InventoryScript.ammo7_62Count = PlayerPrefs.GetInt("SavedscrapAm");
            InventoryScript.scrapAm = PlayerPrefs.GetInt("SavedchemicAm");
            InventoryScript.ragAm = PlayerPrefs.GetInt("SavedragAm");
            InventoryScript.woodAm = PlayerPrefs.GetInt("SavedwoodAm");
            InventoryScript.brickAm = PlayerPrefs.GetInt("SavedbrickAm");

            Weapon.ammoCount = PlayerPrefs.GetInt("SavedammoCount");
            Weapon.ammoOutCount = PlayerPrefs.GetInt("SavedammoOutCount");

            /// ������� + ������� ��������
            GameObject.Find("Player").transform.position = new Vector3(PlayerPrefs.GetFloat("PosPX"), PlayerPrefs.GetFloat("PosPY"), PlayerPrefs.GetFloat("PosPZ"));
            

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }




}
