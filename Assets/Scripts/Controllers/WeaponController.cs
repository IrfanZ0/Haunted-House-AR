using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.ThunderAndLightning;

public class WeaponController : MonoBehaviour {
    public GameObject sword;
    GameObject MagicSword;
    public GameObject flameThrower;
    GameObject FlameThrowerClone;
    public GameObject lightningBolt;
    GameObject LightningBolt;
    public GameObject gun;
    GameObject Gun;
    GameObject[] weapons;
    public Button shotButton;
    Button flameThrowerButton;
    Button gunButton;
    Button lightningGunButton;
    Button magicSwordButton;
    Button potion1Button;
    Button potion2Button;
    Button potion3Button;
    Button potion4Button;
    GameObject mainCanvas;
    GameObject panelAttack;
    GameObject panelWeapons;
    
    
    // Use this for initialization
    void Start () {
        weapons = new GameObject[] { sword, flameThrower, lightningBolt, gun};
        MagicSword = GameObject.Find("Magic_Sword(Clone)");
        FlameThrowerClone = GameObject.Find("Weapon_flamethrower(Clone)");
        LightningBolt = GameObject.Find("Lightning Bolt Gun(Clone)");
        Gun = GameObject.Find("hellwailer(Clone)");
        mainCanvas = GameObject.Find("Canvas_Main_Menu");
        flameThrowerButton = mainCanvas.transform.Find("Panel_Weapons").Find("Flame Thrower").GetComponent<Button>();
        gunButton = mainCanvas.transform.Find("Panel_Weapons").Find("Gun").GetComponent<Button>();
        lightningGunButton = mainCanvas.transform.Find("Panel_Weapons").Find("Lightning Gun").GetComponent<Button>();
        magicSwordButton = mainCanvas.transform.Find("Panel_Weapons").Find("Magic Sword").GetComponent<Button>();
        potion1Button = mainCanvas.transform.Find("Panel_Weapons").Find("Potion 1").GetComponent<Button>();
        potion2Button = mainCanvas.transform.Find("Panel_Weapons").Find("Potion 2").GetComponent<Button>();
        potion3Button = mainCanvas.transform.Find("Panel_Weapons").Find("Potion 3").GetComponent<Button>();
        potion4Button = mainCanvas.transform.Find("Panel_Weapons").Find("Potion 4").GetComponent<Button>();
        panelAttack = mainCanvas.transform.Find("Panel_Attack").gameObject;
        panelWeapons = mainCanvas.transform.Find("Panel_Weapons").gameObject;
    }

    private void FireWeapons(GameObject weapon)
    {
        String weaponTag = weapon.tag;

        switch (weaponTag)
        {
            case "Gun":
                {
                    BulletFire bFire = weapon.GetComponentInChildren<BulletFire>();
                    bFire.Fire();
                    break;
                }

            case "Lightning Bolt Gun":
                {
                    LightningBoltPrefabScript lbPrefabScript = weapon.GetComponentInChildren<LightningBoltPrefabScript>();
                    lbPrefabScript.Trigger();
                    break;
                }

            case "FlameThrower":
                {
                    ParticleSystem FlameThrowerFirePS = weapon.transform.Find("Barrel_end").Find("Flamethrower").Find("FlamethrowerFire").GetComponent<ParticleSystem>();
                    ParticleSystem FlameThrowerSmokePS = weapon.transform.Find("Barrel_end").Find("Flamethrower").Find("FlamethrowerSmoke").GetComponent<ParticleSystem>();

                    if (!FlameThrowerFirePS.isPlaying)
                    {
                        FlameThrowerFirePS.Play();
                    }

                    if (!FlameThrowerSmokePS.isPlaying)
                    {
                        FlameThrowerSmokePS.Play();
                    }

                    break;
                }
        }
        
    }

    public void SwordSpawn(bool obtainedWeapon)
    {
       // bool obtainedWeapon = CheckWeaponObtained();

        if (!obtainedWeapon)
        {
            MagicSword = Instantiate(weapons[0], transform.position, Quaternion.Euler(270f, 0, 0)) as GameObject;
            MagicSword.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            MagicSword.SetActive(true);
            panelAttack.SetActive(true);
            panelWeapons.SetActive(false);
            HideOtherWeapons(FlameThrowerClone);
            HideOtherWeapons(LightningBolt);
            HideOtherWeapons(Gun);
            
            
        }
       
    }

    public void FlameThrowerSpawn(bool obtainedWeapon)
    {
        
        if (!obtainedWeapon)
        {
            FlameThrowerClone = Instantiate(weapons[1], transform.position, transform.rotation) as GameObject;
            FlameThrowerClone.SetActive(true);
            panelAttack.SetActive(true);
            panelWeapons.SetActive(false);
            HideOtherWeapons(MagicSword);
            HideOtherWeapons(LightningBolt);
            HideOtherWeapons(Gun);
            shotButton.onClick.AddListener(() => FireWeapons(FlameThrowerClone));

        }
        
    }

    public void LightningBoltSpawn(bool obtainedWeapon)
    {
        
        if (!obtainedWeapon)
        {
            
            LightningBolt = Instantiate(weapons[2], transform.position, transform.rotation) as GameObject;
            LightningBolt.SetActive(true);
            panelAttack.SetActive(true);
            panelWeapons.SetActive(false);
            HideOtherWeapons(MagicSword);
            HideOtherWeapons(LightningBolt);
            HideOtherWeapons(Gun);
            shotButton.onClick.AddListener(() => FireWeapons(LightningBolt));

        }
       
    }

    public void GunSpawn(bool obtainedWeapon)
    {
       
        if (!obtainedWeapon)
        {
            Gun = Instantiate(weapons[3], transform.position, Quaternion.Euler(270f, 0, 0)) as GameObject;
            Gun.SetActive(true);
            panelAttack.SetActive(true);
            panelWeapons.SetActive(false);
            HideOtherWeapons(FlameThrowerClone);
            HideOtherWeapons(LightningBolt);
            HideOtherWeapons(MagicSword);
            shotButton.onClick.AddListener(() => FireWeapons(Gun));
        }
        
    }

    private void HideOtherWeapons(GameObject weapon)
    {
        if (weapon != null)
        {
            Destroy(weapon);
        }
         
    }

    private bool CheckWeaponObtained(GameObject weapon, bool obtained)
    {
        bool weaponObtained = false;

        if (weapon && obtained)
        {

        }
            weaponObtained = true;

        return weaponObtained;

    }

    
}
