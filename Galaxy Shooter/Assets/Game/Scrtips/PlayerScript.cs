using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private float speed = 5.0f;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
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
