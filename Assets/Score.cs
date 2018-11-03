using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    static public int scoreholder = 0;

    public Text score;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        score.text = "Score: " + scoreholder;
	}

    public void KilledEnemy(int score_)
    {
        scoreholder += score_;
    }

    public void scoreReset()
    {
        scoreholder = 0;
    }
}
