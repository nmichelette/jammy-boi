using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{

    Rigidbody2D rigid;
    public float speed;
    public float damage;

    float counter;
    public float TimeUntilDeleted;

    // Use this for initialization
    void Start()
    {
        counter = TimeUntilDeleted;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeUntilDeleted -= Time.deltaTime;

        if (TimeUntilDeleted <= 0)
            Destroy(gameObject);
        rigid.velocity = transform.up * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MovingPlayer script = collision.GetComponent<MovingPlayer>();
            script.health -= damage;
            script.hurtSound.Play();
            ShakeScript sk = FindObjectOfType<ShakeScript>();
            sk.shakeScreen();

            Destroy(gameObject);
        }
    }
}
