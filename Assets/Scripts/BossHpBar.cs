using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour {

    Image healthBar;
    float maxHealth;
    BossScript script;


    // Use this for initialization
    void Start()
    {
        healthBar = GetComponent<Image>();
        script = FindObjectOfType<BossScript>();
        maxHealth = script.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = script.health / script.MaxHealth;
    }
}
