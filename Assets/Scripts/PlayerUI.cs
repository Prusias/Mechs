using MechAndSandals;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public GameObject playerGameObject;
    public GameObject healthBar;
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
            float width = (float)health * 4f;
   
            var healthBarTransform = healthBar.transform as RectTransform;
            healthBarTransform.sizeDelta = new Vector2(width, healthBarTransform.sizeDelta.y);
             
            if (health < 50)
            {
                var image = healthBar.GetComponent<Image>();
                image.color = new Color(255f, 0, 0);
            }
        }
	}

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
