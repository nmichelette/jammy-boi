using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour {

    Score script;

    static int lives = 3;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public HealthBarScript h;

    private void Start()
    {
        script = FindObjectOfType<Score>();
        h = FindObjectOfType<HealthBarScript>();
    }
    private void Update()
    {
        if(lives == 3)
        {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        if(lives == 2)
        {
            life1.SetActive(false);
            life2.SetActive(true);
            life3.SetActive(true);
        }
        if (lives == 1)
        {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(true);
        }
    }

    public void MinusLives()
    {
        lives--;
        if(lives <= 0)
        {
            script.scoreReset();
            lives = 3;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log(lives);
        }
    }

    public int GetLives()
    {
        return lives;
    }
}
