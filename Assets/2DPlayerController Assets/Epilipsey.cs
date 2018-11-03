using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epilipsey : MonoBehaviour {

    bool change;
    public Camera main;
    public float Timefor;
    float counter;

	// Use this for initialization
	void Start ()
    {
        change = true;
        counter = Timefor;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Timefor <= 0 && change == true)
        {
            main.backgroundColor = Color.blue;
            Debug.Log(".");
            change = false;
            Timefor = counter;
            return;
        }

        if (Timefor <= 0 && change == false)
        {
            main.backgroundColor = Color.HSVToRGB(255f,165f,0f);
            Debug.Log(".");
            change = true;
            Timefor = counter;
            return;
        }

        Timefor -= Time.deltaTime;
	}
}
