using MechAndSandals;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public GameObject playerGameObject;
    public GameObject healthBar;
    public GameObject armourBar;
    public GameObject heatBar;
    Player player;


	// Use this for initialization
	void Start () {
        player = playerGameObject.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            double health = player.Health;
            float healthWidth = (float)health * 4f;

            var healthBarTransform = healthBar.transform as RectTransform;
            healthBarTransform.sizeDelta = new Vector2(healthWidth, healthBarTransform.sizeDelta.y);
             
            if (health < 25)
            {
                var image = healthBar.GetComponent<Image>();
                image.color = new Color(255f, 0, 0);
            }

            double armour = player.Armour;
            float armourWidth = (float)armour * 4f;

            var armourTransform = armourBar.transform as RectTransform;
            armourTransform.sizeDelta = new Vector2(armourWidth, armourTransform.sizeDelta.y);

            double heat = player.Heat;
            float heatWidth = (float)heat * 4f;

            var heatTransform = heatBar.transform as RectTransform;
            heatTransform.sizeDelta = new Vector2(heatWidth, heatTransform.sizeDelta.y);



        }
	}

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
