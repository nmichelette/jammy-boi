using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlayer : MonoBehaviour {
    int counterForPlayer;

    public GameObject PlayerPrefab;

    public float health;
    private float nextRegen;
    public float regenRate;
    private float nextDOT;
    public float dotRate;

    private float maxHealth;

    public float speed;

    Rigidbody2D rigid;

    Lives script;

    public AudioSource hurtSound;

    Color currentColor;
    private float baseSpeed;
    private bool regen;
    private bool dot;
    private bool moreDmg;
    private bool invis;
    private bool moreShots;
    private bool moreSpeed;

    public bool Regen
    {
        get
        {
            return regen;
        }

        set
        {
            regen = value;
        }
    }

    public bool Dot
    {
        get
        {
            return dot;
        }

        set
        {
            dot = value;
        }
    }

    public bool MoreDmg
    {
        get
        {
            return moreDmg;
        }

        set
        {
            moreDmg = value;
        }
    }

    public bool Invis
    {
        get
        {
            return invis;
        }

        set
        {
            invis = value;
        }
    }

    public bool MoreShots
    {
        get
        {
            return moreShots;
        }

        set
        {
            moreShots = value;
        }
    }


    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            maxHealth = value;
        }
    }

    public bool MoreSpeed
    {
        get
        {
            return moreSpeed;
        }

        set
        {
            moreSpeed = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        script = FindObjectOfType<Lives>();
        MaxHealth = health;
        baseSpeed = speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float inputvert = Input.GetAxis("Vertical");
        float inputhoriz = Input.GetAxis("Horizontal");
        if (moreSpeed)
            speed = baseSpeed * 1.5f;
        else
            speed = baseSpeed;
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
        if(dot&&Time.time>nextDOT)
        {
            nextDOT = Time.time + dotRate;
            health -= 5;
            
        }
        if(health <= 0)
        {
            Die();
            Respawn();
        }
        if((health<maxHealth) && (regen&&Time.time>nextRegen))
        {
            nextRegen = Time.time+regenRate;
            health += 5;
        }
        if(health>maxHealth)
        {
            health = maxHealth;
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
