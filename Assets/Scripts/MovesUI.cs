using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MechAndSandals;
using MechAndSandals.Weapons;

public class ActionsUI : MonoBehaviour {

    public static GameObject buttonPrefab;
    public static GameObject weaponButtonParent;
    public List<GameObject> weaponButtons;
    List<IWeapon> weapons;


    // Use this for initialization
    void Start()
    {
        weapons.Add(new Gun(100, "GoodGun"));
        weapons.Add(new Lazer(100, "GoodLaser"));

        Transform transform = weaponButtonParent.transform;

        int count = 0;
        foreach (IWeapon weapon in weapons)
        {
            GameObject button = Instantiate(buttonPrefab, weaponButtonParent.transform);
            button.GetComponentInChildren<Text>().text = weapon.Name;
            button.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(count));
            count++;
        }
  
    }
	
	// Update is called once per frame
	void Update () {
		



	}

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }
}
