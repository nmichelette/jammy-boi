using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySound : MonoBehaviour {

    public AudioSource audi;

	// Use this for initialization
	void Start ()
    {
        audi.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
