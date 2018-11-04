using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    MovingPlayer player;
    BoxCollider2D coll;
    Color c;
    float baseSpeed;
    Color purple = new Color(138/255f, 23/255f, 122/255f, 1);
    Color orange = new Color(217/255f, 97/255f, 22/255f, 1);
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = Color.green;
        player = FindObjectOfType<MovingPlayer>();
        coll = GetComponent<BoxCollider2D>();
        baseSpeed = player.speed;
        c = GetComponent<SpriteRenderer>().color;
    }
	
	// Update is called once per frame
	void Update () {
        if (c.Equals(Color.gray))
            GetComponent<BoxCollider2D>().isTrigger = false;
        else
            GetComponent<BoxCollider2D>().isTrigger = true;
        if (coll.bounds.Intersects(player.GetComponent<BoxCollider2D>().bounds))
        {
            
            if (c.Equals(Color.green))
                player.Regen = true;
            else
                player.Regen = false;

            if (c.Equals(Color.red))
                player.Dot = true;
            else
                player.Dot = false;

            if (c.Equals(purple))
                player.MoreDmg = true;
            else
                player.MoreDmg = false;

            if (c.Equals(orange))
                player.MoreShots = true;
            else
                player.MoreShots = false;

            if (c.Equals(Color.yellow))
                Time.timeScale = .5f;
            else
                Time.timeScale = 1;
            if (c.Equals(Color.white))
                player.Invis = true;
            else
                player.Invis = false;
            if (c.Equals(Color.black))
            {
                player.Regen = false;
                player.Dot = false;
                player.MoreDmg = false;
                player.MoreShots = false;
                Time.timeScale = 1;
                player.Invis = false;
                GetComponent<BoxCollider2D>().isTrigger = true;
                player.MoreSpeed = false;
            }
            if (c.Equals(Color.blue))
                player.MoreSpeed = true;
            else
                player.MoreSpeed = false;
            
        }
        else
        {
            if (c.Equals(Color.gray))
                GetComponent<BoxCollider2D>().isTrigger = false;
            else
                GetComponent<BoxCollider2D>().isTrigger = true;
        }
        
	}
    public void setColor(float f)
    {
        if(f<.5)
            GetComponent<SpriteRenderer>().color = Color.black;
        if (f < .55&&f >= .5)
            GetComponent<SpriteRenderer>().color = Color.red;
        if (f < .65 && f >= .55)
            GetComponent<SpriteRenderer>().color = purple;
        if (f < .75 && f >= .65)
            GetComponent<SpriteRenderer>().color = orange;
        if (f < .8 && f >= .75)
            GetComponent<SpriteRenderer>().color = Color.white;
        if (f < .85 && f >= .8)
            GetComponent<SpriteRenderer>().color = Color.yellow;
        if (f < .88 && f >= .85)
            GetComponent<SpriteRenderer>().color = Color.blue;
        if (f<.90&& f >= .88)
            GetComponent<SpriteRenderer>().color = Color.gray;
        if(f>=.90)
            GetComponent<SpriteRenderer>().color = Color.green;
        c = GetComponent<SpriteRenderer>().color;
    }
    public Color getColor()
    {
        return c;
    }
}
