using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Sprite[] imagesLives;
    public Image imageDisplayLives;
    public Text textScore;
    public int score;
    public GameObject titleScreen;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLives(int currentLives)
    {
        imageDisplayLives.sprite = imagesLives[currentLives];
    }

    public void UpdateScore()
    {
        score += 5;
        textScore.text = "Score: " + score;
    }

    public void ShowTitleScrean()
    {
        titleScreen.SetActive(true);
    }
    
    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        textScore.text = "Score: 0";
    }
}
