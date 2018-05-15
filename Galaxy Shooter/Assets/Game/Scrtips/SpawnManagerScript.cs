using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabEnemyShip;

    [SerializeField]
    private GameObject[] powerUps;

    [SerializeField]
    private float PowerUpsSpawnRate;

    [SerializeField]
    private float EnemySpawnRate;

    private GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        PowerUpsSpawnRate = 5.0f;
        EnemySpawnRate = 5.0f;
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
	}

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

	
    IEnumerator EnemySpawnRoutine()
    {
        while (gameManager.gameState.Equals(GameManager.GameState.Playing))
        {
            Instantiate(prefabEnemyShip, new Vector3(Random.Range(-7.7f, 7.7f), 6.7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(EnemySpawnRate);
        }
    }
    
    IEnumerator PowerUpSpawnRoutine()
    {
        while (gameManager.gameState.Equals(GameManager.GameState.Playing))
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-7.7f, 7.7f), 6.7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(PowerUpsSpawnRate);
        }
    }

}
