using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public AudioSource laser;

    public GameObject Shot;
    public Transform shotSpawn;

    private float nextFire;

    public float fireRate;

    public float timeUntilSound;
    float timeUntilSoundCounter;

    // Use this for initialization
    void Start ()
    {
        timeUntilSoundCounter = timeUntilSound;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        timeUntilSoundCounter -= Time.deltaTime;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
                laser.Play();
            Instantiate(Shot, shotSpawn.position, shotSpawn.rotation);
        }

    }

    private void Shoot(Vector2 mPos)
    {
        Debug.DrawLine(transform.position, (mPos), Color.cyan);
    }
}
