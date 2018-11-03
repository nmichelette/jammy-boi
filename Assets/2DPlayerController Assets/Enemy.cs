using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject Shot;
    public Transform shotSpawn;

    private float nextFire;

    public float fireRate;

    public float speed;

    Transform player;
    Rigidbody2D rigid;

    public float health;

    Score score;

    public int amountOfScore;
	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerInput>().gameObject.transform;
        rigid = GetComponent<Rigidbody2D>();
        score = FindObjectOfType<Score>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //finds the player
        player = FindObjectOfType<PlayerInput>().gameObject.transform;
        rigid = GetComponent<Rigidbody2D>();

        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);

        rigid.AddForce(gameObject.transform.up * speed);
        
        if(health <= 0)
        {
            Destroy(gameObject);
            score.KilledEnemy(amountOfScore);
        }

        if ( Time.time > nextFire)
        {
            nextFire = Time.time + Random.Range(0.25f,1f);
            Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
