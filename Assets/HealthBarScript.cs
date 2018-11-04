using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    Image healthBar;
    float maxHealth;
    MovingPlayer script;


    // Use this for initialization
    void Start () {
        healthBar = GetComponent<Image>();
        script = FindObjectOfType<MovingPlayer>();
        maxHealth = script.MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = script.health / maxHealth;
	}
}
