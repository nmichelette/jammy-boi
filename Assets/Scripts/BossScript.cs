using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public enum FightingStages { Phase1, Phase2, Phase3 }
    FightingStages stage;
    bool phaseon;

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

    Animator anim;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerInput>().gameObject.transform;
        rigid = GetComponent<Rigidbody2D>();
        score = FindObjectOfType<Score>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (phaseon)
        {
            return;
        }
        player = FindObjectOfType<PlayerInput>().gameObject.transform;
        rigid = GetComponent<Rigidbody2D>();

        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);

        //rigid.AddForce(gameObject.transform.up * speed);

        switch (stage)
        {
            case FightingStages.Phase1:
               StartCoroutine(Phase1Attack());
                break;
            case FightingStages.Phase2:
                Phase2Attack();
                break;
            case FightingStages.Phase3:
                Phase3Attack();
                break;

        }

        if (health <= 0)
        {
            Destroy(gameObject);
            score.KilledEnemy(amountOfScore);
        }

        //if (Time.time > nextFire)
        //{
          //  nextFire = Time.time + UnityEngine.Random.Range(0.25f, 1f);
            //Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
     //   }
    }

    private void Phase3Attack()
    {
        phaseon = true;

    }

    private void Phase2Attack()
    {
        phaseon = true;
    }

    IEnumerator Phase1Attack()
    {
        //phaseon = true;

        yield return new WaitForSeconds(.25f);

        Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
    }
}
