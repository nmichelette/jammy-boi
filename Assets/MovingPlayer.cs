using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlayer : MonoBehaviour {
    int counterForPlayer;

    public GameObject PlayerPrefab;

    public float health;

    public float speed;

    Rigidbody2D rigid;

    Lives script;

	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        script = FindObjectOfType<Lives>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float inputvert = Input.GetAxis("Vertical");
        float inputhoriz = Input.GetAxis("Horizontal");

        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            for (var i = 0; i < speed; i++)
            {
                rigid.AddForce(gameObject.transform.up * inputvert * i * speed);
            }
        }

        if(Input.GetKey("a") || Input.GetKey("d"))
        {
            for (var i = 0; i < speed; i++)
            {
                rigid.AddForce(gameObject.transform.right * inputhoriz * i * speed);
            }
        }

        if(health <= 0)
        {
            Die();
            Respawn();
        }

    }

    private void Respawn()
    {
        Instantiate(PlayerPrefab, Vector3.zero, transform.rotation);
    }

    private void Die()
    {
        Destroy(gameObject);
        script.MinusLives();
    }
}
