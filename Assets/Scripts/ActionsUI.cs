﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MechAndSandals;
using MechAndSandals.Weapons;

public class ActionsUI : MonoBehaviour {

    public GameObject buttonPrefab;
    public GameObject weaponButtonParent;
    List<GameObject> weaponButtons;
    List<IWeapon> weapons;


    // Use this for initialization
    void Start()
    {
        weapons = new List<IWeapon>();
        weapons.Add(new Gun(100, "GoodGun"));
        weapons.Add(new Lazer(100, "GoodLaser"));
        weapons.Add(new Missile(100, "GoodMissile"));
        
        Transform transform = weaponButtonParent.transform;

        int count = 0;
        foreach (IWeapon weapon in weapons)
        {
            GameObject label = Instantiate(buttonPrefab, weaponButtonParent.transform);
            label.transform.position = new Vector3(label.transform.position.x, label.transform.position.y + 25 * count, label.transform.position.z);
            label.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 30);
            double damage = float.Parse(weapon.Damage);
            label.GetComponentInChildren<Text>().text = weapon.Name + " DMG: " + damage;


            for (int  i = 0;  i < 3;  i++)
            {
                GameObject button = Instantiate(buttonPrefab, weaponButtonParent.transform);
                button.transform.position = new Vector3(button.transform.position.x + 45 * i + 90, button.transform.position.y + 25 * count, button.transform.position.z);
                button.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 30);
               

                if (i == 0)
                {
                    button.GetComponentInChildren<Text>().text = "Quick";
                    button.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(count, 1));
                } else if (i == 1)
                {
                    button.GetComponentInChildren<Text>().text = "Normal";
                    button.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(count, 2));
                } else
                {
                    button.GetComponentInChildren<Text>().text = "Heavy";
                    button.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(count, 3));
                }
                
            }


            //GameObject button = Instantiate(buttonPrefab, weaponButtonParent.transform);
            //button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y + 25 * count, button.transform.position.z);
            //button.GetComponentInChildren<Text>().text = weapon.Name + " Dmg: " + weapon.Damage;
            //button.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(count));
            count++;
        }
  
    }
	
	// Update is called once per frame
	void Update () {
		



	}

    void ButtonClicked(int buttonNo, int actiontype = 0)
    {




        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }
}