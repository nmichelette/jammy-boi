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
    Transform player;
    Rigidbody2D rigid;
    public float health;
    Score score;
    public int amountOfScore;

    Animator anim;
    public int counterUntilPhaseChange;
    public int phase1Length;
    public int phase2Length;
    public int phase3Length;
    public GameObject[] BossSpawns;

    public GameObject theBoss;
    public float speed;
    bool isright;

    // Use this for initialization
    void Start()
    {
        counterUntilPhaseChange = 0;
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
                StartCoroutine(Phase2Attack());
                break;
            case FightingStages.Phase3:
                StartCoroutine(Phase3Attack());
                break;

        }

        if (health <= 0)
        {
            Destroy(theBoss);
            score.KilledEnemy(amountOfScore);
        }

        //if (Time.time > nextFire)
        //{
          //  nextFire = Time.time + UnityEngine.Random.Range(0.25f, 1f);
            //Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
     //   }
    }

    IEnumerator Phase3Attack()
    {
        yield return new WaitForSeconds(.65f);
        phaseon = true;

    }

    IEnumerator Phase2Attack()
    {
        theBoss.transform.Translate(-speed * Time.deltaTime, 0, 0);
        for (int i = 0; i < BossSpawns.Length; i++)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(Shot, BossSpawns[i].gameObject.transform.position, BossSpawns[i].gameObject.transform.rotation);
        }

        if (counterUntilPhaseChange == phase2Length)
        {
            counterUntilPhaseChange = 0;
            stage = FightingStages.Phase3;
        }
        counterUntilPhaseChange++;
    }

    IEnumerator Phase1Attack()
    {
        theBoss.transform.Translate(speed * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(1f);
        Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
        if (counterUntilPhaseChange == phase1Length)
        {
            counterUntilPhaseChange = 0;
            stage = FightingStages.Phase2;
        }
        counterUntilPhaseChange++;

    }
}
