using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public enum FightingStages { Phase1, Phase2, Phase3 }
    FightingStages stage;
    bool phaseon;

    bool halfHp;
    private float maxHealth;
    BoxCollider2D coll;
    private int direction;
    private float direction2;
    public GameObject Shot;
    public Transform shotSpawn;
    private float nextFire;
    public float fireRate;
    Transform player;
    Rigidbody2D rigid;
    public float health;
    Score score;
    public int amountOfScore;
    GameObject x;
    Animator anim;
    public int counterUntilPhaseChange;
    public int phase1Length;
    public int phase2Length;
    public int phase3Length;
    public GameObject[] BossSpawns;

    public GameObject theBoss;
    public float speed;
    bool isright;

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

    // Use this for initialization
    void Start()
    {
        counterUntilPhaseChange = 0;
        player = FindObjectOfType<PlayerInput>().gameObject.transform;
        //rigid = GetComponent<Rigidbody2D>();
        score = FindObjectOfType<Score>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        direction = 1;
        direction2 = UnityEngine.Random.Range(-1f, 1f);
        maxHealth = health;
        halfHp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (phaseon)
        {
            return;
        }

        halfHp = health < maxHealth / 2;

        player = FindObjectOfType<PlayerInput>().gameObject.transform;

        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);

        //rigid.AddForce(gameObject.transform.up * speed);
        if(direction==1&&theBoss.transform.position.x<13)
            theBoss.transform.Translate(speed * Time.deltaTime, 0, 0);
        if(direction==-1&& theBoss.transform.position.x > -13)
            theBoss.transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (halfHp)
        {
            speed = 5;
            if(theBoss.transform.position.y > -9.6 && theBoss.transform.position.y<9.6)
                theBoss.transform.Translate(0, direction2 * speed * Time.deltaTime, 0);
        }
        Debug.Log("halfHP: " + halfHp);
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

        if (coll.transform.position.x > 13 || coll.transform.position.x < -13)
        {
            //counterUntilPhaseChange = 0;
            if (UnityEngine.Random.value < .5)
                stage = FightingStages.Phase2;
            else
                stage = FightingStages.Phase1;
            direction = -1 * direction;
            StopAllCoroutines();
        }
        if (halfHp)
        {
            if (coll.transform.position.y > 9.5)
            {
                // counterUntilPhaseChange = 0;
                //if (UnityEngine.Random.value < .5)
                //    stage = FightingStages.Phase2;
                //else
                //    stage = FightingStages.Phase1;
                direction2 = UnityEngine.Random.Range(-1f, -.4f);
            }
            if (coll.transform.position.y < -9.5)
                direction2 = UnityEngine.Random.Range(.4f, 1f);
        }

        for (int i = 0; i < BossSpawns.Length; i++)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(Shot, BossSpawns[i].gameObject.transform.position, BossSpawns[i].gameObject.transform.rotation);
        }
        
        
        
        //counterUntilPhaseChange++;
    }

    IEnumerator Phase1Attack()
    {
        if (coll.transform.position.x > 13 || (coll.transform.position.x < -13))
        {
            counterUntilPhaseChange = 0;
            direction = -1 * direction;
            if (UnityEngine.Random.value < .5)
                stage = FightingStages.Phase2;
            else
                stage = FightingStages.Phase1;
            StopAllCoroutines();
        }
        if (halfHp)
        {
            if (coll.transform.position.y > 9.5)
            {
                // counterUntilPhaseChange = 0;
                //if (UnityEngine.Random.value < .5)
                //    stage = FightingStages.Phase2;
                //else
                //    stage = FightingStages.Phase1;
                direction2 = UnityEngine.Random.Range(-1f, -.4f);
            }
            if (coll.transform.position.y < -9.5)
                direction2 = UnityEngine.Random.Range(.4f, 1f);
        }
        //theBoss.transform.Translate(direction*speed * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(1f);
        Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
        
        //counterUntilPhaseChange++;

    }
}
