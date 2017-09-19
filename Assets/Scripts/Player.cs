using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    bool isGrounded = false ;
    public float jumpPower;
    public float moveSpeed;
    public AudioClip gemSound;
    public AudioClip jumpSound;
    Vector2 jumpForce;

	// Use this for initialization
	void Start () {
        jumpForce = new Vector2(0.0f, jumpPower);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if ( isGrounded)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(jumpForce);
                gameObject.GetComponent<AudioSource>().PlayOneShot(jumpSound);
                isGrounded = false;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * -1.0f * moveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;
        }

        // test sound play
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Gem")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(gemSound);
            Destroy(collision.gameObject);
        }
    }
}
