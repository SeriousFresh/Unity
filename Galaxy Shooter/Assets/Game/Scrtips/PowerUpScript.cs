using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    enum PowerUp {TripleShot, SpeedBoost, Shields};

    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private PowerUp powerUpId;

    [SerializeField]
    private AudioClip audioClip;
    
    // Use this for initialization
    void Start ()
    {
		//transform.position = new Vector3()
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -7)
            Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")//other.name
        {
            PlayerScript player = other.GetComponent<PlayerScript>();

            if (player)
            {
                switch(powerUpId)
                {
                    case PowerUp.Shields:
                        player.EnableShield();
                        break;
                    case PowerUp.SpeedBoost:
                        player.SpeedBoostPowerUpOn();
                        break;
                    case PowerUp.TripleShot:
                        player.TripleShotPowerUpOn();
                        break;
                }  
            }

            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            Destroy(this.gameObject);
        }

        

    }

}
