using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndscreenUI : MonoBehaviour {

    public GameObject endscreenGameObject;
    public GameObject endscreenText;
    public GameObject endscreenButton;
    public GameObject endscreenBackground;

	// Use this for initialization
	void Start () {
        
        endscreenButton.GetComponentInChildren<Button>().onClick.AddListener(() => Restart());

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Display(bool isWinner)
    {
        if (isWinner)
        {
            endscreenText.GetComponent<Text>().text = "You Win!";
        }
        else
        {
            endscreenText.GetComponent<Text>().text = "You Loose!";
        }
        endscreenButton.GetComponent<Image>().enabled = true;
        endscreenBackground.GetComponent<Image>().enabled = true;
        endscreenButton.GetComponentInChildren<Text>().enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
