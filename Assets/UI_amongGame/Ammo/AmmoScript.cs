using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public AudioSource reloadSource;

    [SerializeField] private TextMeshProUGUI ammoTxt;
    [SerializeField] private TextMeshProUGUI ammoOutTxt;
    [SerializeField] private Image ammoBar;
    [SerializeField] private Image reloadBar;
    public static bool IsReloading = false;

    float timer = 0;
    float reloadTime = 1.7f;

    Vector3 barPosBefore = new Vector3(-40, 16.5f, 0);
    Vector3 barPosAfter = new Vector3(-40, 20f, 0);

    private void Start()
    {
        Weapon.ammoOutCount = 30;
        Weapon.ammoCount = 30;
    }
    void Update()
    {
        if (ChangeWeaponScript.weaponID == 1)
        {
            ammoTxt.text = Weapon.ammoCount.ToString();
            ammoOutTxt.text = Weapon.ammoOutCount.ToString();
        }
        else if (ChangeWeaponScript.weaponID == 2)
        {
            ammoTxt.text = "INF";
            ammoOutTxt.text = "";
        }
        timer += Time.deltaTime;

        float maxAmm = Weapon.maxAmmo;
        float ammoCo = Weapon.ammoCount;

        ammoBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ammoCo / maxAmm * 100);

        // перезарядка
        if ((Input.GetKeyDown(KeyCode.R) || Weapon.ammoCount == 0) && !IsReloading && Weapon.ammoCount < Weapon.maxAmmo && Weapon.ammoOutCount > 0)
        {
            reloadSource.Play();
            IsReloading = true;
            timer = 0;
            reloadBar.color = new Color(0, 1, 1, 1);
        }

        if (IsReloading)
        {
            reloadBar.rectTransform.anchoredPosition = barPosAfter;
            reloadBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, timer / reloadTime * 100);
        }
        else 
        { 
            reloadBar.rectTransform.anchoredPosition = Vector3.Lerp(reloadBar.rectTransform.anchoredPosition, barPosBefore, 0.05f);
            reloadBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ammoCo / maxAmm * 100);
        }
        if (reloadBar.rectTransform.anchoredPosition.y <= -209.5f && !IsReloading) { reloadBar.color = new Color(0, 1, 1, 0); }

        if (timer >= reloadTime && IsReloading)
        {
            if (Weapon.ammoOutCount >= Weapon.maxAmmo - Weapon.ammoCount)
            {
                int amTemp = Weapon.ammoCount;
                Weapon.ammoCount = Weapon.maxAmmo;
                Weapon.ammoOutCount -= Weapon.maxAmmo - amTemp;
                IsReloading = false;
            }
            else
            {
                if (Weapon.ammoOutCount < Weapon.maxAmmo - Weapon.ammoCount && Weapon.ammoOutCount > 0)
                {
                    int amTemp = Weapon.ammoCount;
                    Weapon.ammoCount += Weapon.ammoOutCount;
                    Weapon.ammoOutCount = 0;
                    IsReloading = false;
                }
            }

        }
    }
}
