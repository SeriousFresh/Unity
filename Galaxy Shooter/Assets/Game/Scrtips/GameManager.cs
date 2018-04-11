using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public bool gameOver = true;
    public GameObject player;

    private UIManager UIManager;

    // Use this for initialization
    void Start ()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                this.UIManager.HideTitleScreen();
            }
        }
	}
}
