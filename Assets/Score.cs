using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    static public int scoreholder = 0;

    public Text score;

    public int transportToBoss;

	// Use this for initialization
	void Start ()
    {
        transportToBoss = 0;   
	}
	
	// Update is called once per frame
	void Update ()
    {
        score.text = "Score: " + scoreholder;
	}

    public void KilledEnemy(int score_)
    {
        scoreholder += score_;
        transportToBoss++;
        if(transportToBoss >= 10)
        {
            SceneManager.LoadScene("FinalBoss");
        }
    }

    public void scoreReset()
    {
        scoreholder = 0;
    }
}
