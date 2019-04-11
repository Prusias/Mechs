using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndscreenUI : MonoBehaviour {

    public GameObject ActionsObject;
    public GameObject YourTurn;
    public GameObject endscreenText;
    public GameObject endscreenButton;

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
        endscreenText.GetComponent<Text>().enabled = true;
        endscreenButton.GetComponent<Image>().enabled = true;
        endscreenButton.GetComponentInChildren<Text>().enabled = true;
        Destroy(ActionsObject);
        Destroy(YourTurn);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
