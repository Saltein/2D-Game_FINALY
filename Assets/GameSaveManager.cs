using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    

    

    public void SaveGame() ///����������
    {
        
        PlayerPrefs.SetInt("SavedHP", PlayerManager.playerHP);
        PlayerPrefs.SetFloat("SavedStamina", PlayerManager.playerStamina);


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


        GameObject[] gameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject gameObject in gameObjects)
        {
            
            PlayerPrefs.SetFloat(Convert.ToString(gameObject.name) + "savedX", gameObject.transform.position.x);
            PlayerPrefs.SetFloat(Convert.ToString(gameObject.name) + "savedY", gameObject.transform.position.y);
            PlayerPrefs.SetFloat(Convert.ToString(gameObject.name) + "savedZ", gameObject.transform.position.z);
            PlayerPrefs.SetFloat(Convert.ToString(gameObject.name) + "savedRX", gameObject.transform.rotation.x);
            PlayerPrefs.SetFloat(Convert.ToString(gameObject.name) + "savedRY", gameObject.transform.rotation.y);
            PlayerPrefs.SetFloat(Convert.ToString(gameObject.name) + "savedRZ", gameObject.transform.rotation.z);
            
        }

        PlayerPrefs.Save();
        Debug.Log("Game data saved!");

        

    }


   public void LoadGame() /// ����������
    {
        if (PlayerPrefs.HasKey("SavedHP"))
        {
            PlayerManager.playerHP = PlayerPrefs.GetInt("SavedHP");
            PlayerManager.playerStamina = PlayerPrefs.GetFloat("SavedStamina");


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

            GameObject[] gameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject gameObject in gameObjects)
            {

                GameObject.Find(gameObject.name).transform.position = new Vector3(PlayerPrefs.GetFloat(Convert.ToString(gameObject.name) + "savedX"), 
                    PlayerPrefs.GetFloat(Convert.ToString(gameObject.name) + "savedY"), PlayerPrefs.GetFloat(Convert.ToString(gameObject.name) + "savedZ"));
            }



            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }




}
