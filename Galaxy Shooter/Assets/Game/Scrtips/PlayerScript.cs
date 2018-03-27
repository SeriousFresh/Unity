using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabLaser;
    [SerializeField]
    private float fireRate = 0.25f;
    [SerializeField]
    private float canFire = 0.0f;
    [SerializeField]
    private float speed = 5.0f;
  

	// Use this for initialization
	void Start ()
    {
  
        transform.position = new Vector3(0, 0, 0);

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
        if (Time.time > canFire)
        {
            Instantiate(prefabLaser, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            canFire = Time.time + fireRate;
        }
    }
    
    private void Movement()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * inputHorizontal);
        transform.Translate(Vector3.up * inputVertical * speed * Time.deltaTime);

        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x, 0, 0);

        if (transform.position.y < -4.2f)
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        /*
        if (transform.position.x > 8)
            transform.position = new Vector3(8, transform.position.y, 0);

        if (transform.position.x < -8)
            transform.position = new Vector3(-8, transform.position.y, 0);
            */
        if (transform.position.x > 9.5f)
            transform.position = new Vector3(-9.5f, transform.position.y, 0);

        if (transform.position.x < -9.5f)
            transform.position = new Vector3(9.5f, transform.position.y, 0);

    }
}
