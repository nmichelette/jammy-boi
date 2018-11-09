using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public AudioSource laser;

    public GameObject Shot;
    public Transform shotSpawn;

    MovingPlayer player;
    private float nextFire;
    private float baseFireRate;

    public float fireRate;

    public float timeUntilSound;
    float timeUntilSoundCounter;

    // Use this for initialization
    void Start ()
    {
        timeUntilSoundCounter = timeUntilSound;
        player = FindObjectOfType<MovingPlayer>();
        baseFireRate = fireRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float mag = (float)Math.Sqrt(Math.Pow(transform.position.x - mousePosition.x, 2) + Math.Pow(transform.position.y - mousePosition.y, 2));
        Vector3 rota = new Vector3((transform.position.x - mousePosition.x) / mag, (transform.position.y - mousePosition.y) / mag, 10);
        Quaternion rot = Quaternion.LookRotation(rota, Vector3.forward);
        transform.rotation = rot;
        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        timeUntilSoundCounter -= Time.deltaTime;
        if (player.MoreFireRate)
            fireRate = baseFireRate / 1.5f; 
        else
            fireRate = baseFireRate;
        if ((Input.GetButton("Fire1") && Time.time > nextFire)&&!player.Invis)
        {
            nextFire = Time.time + fireRate;
            laser.Play();
            Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
            
            if (player.MoreShots)
            {
                Instantiate(Shot, shotSpawn.position, shotSpawn.rotation*Quaternion.Euler(0, 0, 350));
                Instantiate(Shot, shotSpawn.position, shotSpawn.rotation*Quaternion.Euler(0, 0, 10));
            }
        }

    }

    private void Shoot(Vector2 mPos)
    {
        Debug.DrawLine(transform.position, (mPos), Color.cyan);
    }
}
