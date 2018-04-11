using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject playerExplosionPrefab;

    [SerializeField]
    private GameObject prefabLaser;

    [SerializeField]
    private GameObject prefabLaserTripleShot;

    [SerializeField]
    private float fireRate = 0.25f;

    [SerializeField]
    private float canFire = 0.0f;

    [SerializeField]
    private float Speed = 5.0f;

    [SerializeField]
    private float SpeedBoost = 2.0f;

    [SerializeField]
    private GameObject shieldGameObject;

    [SerializeField]
    private GameObject[] engines;

    private UIManager UIManager;
    private GameManager gameManager;
    private SpawnManagerScript spawnManager;
    private AudioSource audioSource;
    private int hitCount = 0;

    public int lives = 3;
    public bool canTripleShot = false;
    public bool isSpeedBoostOn = false;
    public bool isShieldOn = false;


    // Use this for initialization
    void Start ()
    {
  
        transform.position = new Vector3(0, 0, 0);
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (UIManager)
            UIManager.UpdateLives(lives);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
        if (spawnManager)
            spawnManager.StartSpawnRoutines();

        audioSource = GetComponent<AudioSource>();

        hitCount = 0;

	}

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        this.audioSource.Play();
        if (Time.time > canFire)
        {
            if(canTripleShot)
                Instantiate(prefabLaserTripleShot, transform.position, Quaternion.identity);
            else 
                Instantiate(prefabLaser, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            canFire = Time.time + fireRate;
        }
    }
    
    private void Movement()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        float speedBoost;
        if (isSpeedBoostOn)
            speedBoost = SpeedBoost;
        else
            speedBoost = 1.0f;

        transform.Translate(Vector3.right * Time.deltaTime * Speed * speedBoost * inputHorizontal);
        transform.Translate(Vector3.up * inputVertical * Speed * speedBoost * Time.deltaTime);

        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x, 0, 0);

        if (transform.position.y < -4.2f)
            transform.position = new Vector3(transform.position.x, -4.2f, 0);

        if (transform.position.x > 9.5f)
            transform.position = new Vector3(-9.5f, transform.position.y, 0);

        if (transform.position.x < -9.5f)
            transform.position = new Vector3(9.5f, transform.position.y, 0);

    }
    
    public void Damage()
    {
        if (isShieldOn)
        {
            isShieldOn = false;
            shieldGameObject.SetActive(false);
            return;
        }

        hitCount++;

        if(hitCount == 1)
        {
            engines[0].SetActive(true);
        }
        else if(hitCount == 2)
        {
            engines[1].SetActive(true);
        }

        lives--;
        UIManager.UpdateLives(lives);

        if(lives == 0)
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            gameManager.gameOver = true;
            this.UIManager.ShowTitleScrean();
            Destroy(this.gameObject);

        }
    }

    public void EnableShield()
    {
        isShieldOn = true;
        shieldGameObject.SetActive(true);
    }

    public void SpeedBoostPowerUpOn()
    {
        isSpeedBoostOn = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }
    
    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostOn = false;
    }

    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;

    }
}
