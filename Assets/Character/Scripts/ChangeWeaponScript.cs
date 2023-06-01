using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponScript : MonoBehaviour
{
    public GameObject shadow;

    public Sprite glock18;
    public Sprite ak47;

    private SpriteRenderer spriteRenderer;
    public static int weaponID = 1;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponID = 1;
            spriteRenderer.sprite = ak47;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponID = 2;
            spriteRenderer.sprite = glock18;
        }

    }
}
