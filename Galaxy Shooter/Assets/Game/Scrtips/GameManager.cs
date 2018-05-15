using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState {OnStart, Playing};
    
    public GameState gameState;
    public GameObject player;

    private UIManager UIManager;

    // Use this for initialization
    void Start ()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameState = GameState.OnStart;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(gameState.Equals(GameState.OnStart))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameState = GameState.Playing;
                this.UIManager.HideTitleScreen();
            }
        }
	}
}
