using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManage : MonoBehaviour {

    Tile[] tiles, tiles1,  tiles2, tiles3, tiles4, tiles12, tiles22, tiles32, tiles42;
    List<Tile> list1, list2, list3, list4;
    float tempRand, tempRand2, tempRand3, tempRand4;
    float timeUntilNextTiles,  timeAfterFirst;

    public float timeUntilTileChange;
    private bool firstDone, secondDone;
    MovingPlayer player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<MovingPlayer>();
        tiles = GetComponentsInChildren<Tile>();
        list1 = new List<Tile>();
        list2 = new List<Tile>();
        list3 = new List<Tile>();
        list4 = new List<Tile>();
        timeUntilNextTiles = timeUntilTileChange;
        timeAfterFirst = 0;
        firstDone = false;
        secondDone = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(player.GetComponent<Rigidbody2D>().velocity.x>.05&& player.GetComponent<Rigidbody2D>().velocity.x > .05)
        {
            timeUntilNextTiles -= Time.deltaTime;
            if(timeAfterFirst<= timeUntilTileChange*4)
                timeAfterFirst += Time.deltaTime;    
        }

        if (timeUntilNextTiles <= 0)
        {
            
            if (!firstDone)
            {
                timeUntilNextTiles = timeUntilTileChange;
                firstDone = true;
                tempRand = Random.value;
                tempRand2 = Random.value;
                tempRand3 = Random.value;
                tempRand4 = Random.value;
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (tiles[i].transform.position.x > 0 && tiles[i].GetComponent<BoxCollider2D>().transform.position.y > 0)
                    {
                        list1.Add(tiles[i]); //x and y are positive
                        tiles[i].setColor(tempRand);
                    }
                    tiles1=list1.ToArray();
                    
                    if (tiles[i].transform.position.x < 0 && tiles[i].GetComponent<BoxCollider2D>().transform.position.y > 0)
                    {
                        list2.Add(tiles[i]); //x is negative and y is positive
                        tiles[i].setColor(tempRand2);
                    }
                    tiles2 = list2.ToArray();
                    
                    if (tiles[i].transform.position.x > 0 && tiles[i].GetComponent<BoxCollider2D>().transform.position.y < 0)
                    {
                        list3.Add(tiles[i]); //y is negative and x is positive
                        tiles[i].setColor(tempRand3);
                    }
                    tiles3 = list2.ToArray();
                    
                    if (tiles[i].transform.position.x < 0 && tiles[i].GetComponent<BoxCollider2D>().transform.position.y < 0)
                    {
                        list4.Add(tiles[i]); //both negative
                        tiles[i].setColor(tempRand4);
                    }
                    tiles4 = list4.ToArray();
                    
                }
            }
            

            if((!secondDone&&firstDone)&&timeAfterFirst>= timeUntilTileChange*2)
            {
                timeUntilNextTiles = timeUntilTileChange*2;
                secondDone = true;
                tempRand = Random.value;
                tempRand2 = Random.value;
                tempRand3 = Random.value;
                tempRand4 = Random.value;
                for (int i = 0;i<tiles1.Length;i++)
                {
                    
                    if((Mathf.Abs(tiles1[i].transform.position.x)<5.5)&&(Mathf.Abs(tiles1[i].transform.position.y)<3.7))
                    {
                        tiles1[i].setColor(tempRand);
                    }
                    
                    if ((Mathf.Abs(tiles1[i].transform.position.x)  > 5.5) && (Mathf.Abs(tiles1[i].transform.position.y) < 3.7))
                    {
                        tiles1[i].setColor(tempRand2);
                    }
                    
                    if ((Mathf.Abs(tiles1[i].transform.position.x)  < 5.5) && (Mathf.Abs(tiles1[i].transform.position.y)  > 3.7))
                    {
                        tiles1[i].setColor(tempRand3);
                    }
                    
                    if ((Mathf.Abs(tiles1[i].transform.position.x)  > 5.5) && (Mathf.Abs(tiles1[i].transform.position.y)  > 3.7))
                    {
                        tiles1[i].setColor(tempRand4);
                    }                
                }
                tempRand = Random.value;
                tempRand2 = Random.value;
                tempRand3 = Random.value;
                tempRand4 = Random.value;
                for (int i = 0; i < tiles2.Length; i++)
                {
                    if ((Mathf.Abs(tiles2[i].transform.position.x) < 5.5) && (Mathf.Abs(tiles2[i].transform.position.y) < 3.7))
                    {
                        tiles2[i].setColor(tempRand);
                    }

                    if ((Mathf.Abs(tiles2[i].transform.position.x) > 5.5) && (Mathf.Abs(tiles2[i].transform.position.y) < 3.7))
                    {
                        tiles2[i].setColor(tempRand2);
                    }

                    if ((Mathf.Abs(tiles2[i].transform.position.x) < 5.5) && (Mathf.Abs(tiles2[i].transform.position.y) > 3.7))
                    {
                        tiles2[i].setColor(tempRand3);
                    }

                    if ((Mathf.Abs(tiles2[i].transform.position.x) > 5.5) && (Mathf.Abs(tiles2[i].transform.position.y) > 3.7))
                    {
                        tiles2[i].setColor(tempRand4);
                    }
                }
                tempRand = Random.value;
                tempRand2 = Random.value;
                tempRand3 = Random.value;
                tempRand4 = Random.value;
                for (int i = 0; i < tiles3.Length; i++)
                {
                    if ((Mathf.Abs(tiles3[i].transform.position.x) < 5.5) && (Mathf.Abs(tiles3[i].transform.position.y) < 3.7))
                    {
                        tiles3[i].setColor(tempRand);
                    }

                    if ((Mathf.Abs(tiles3[i].transform.position.x) > 5.5) && (Mathf.Abs(tiles3[i].transform.position.y) < 3.7))
                    {
                        tiles3[i].setColor(tempRand2);
                    }

                    if ((Mathf.Abs(tiles3[i].transform.position.x) < 5.5) && (Mathf.Abs(tiles3[i].transform.position.y) > 3.7))
                    {
                        tiles3[i].setColor(tempRand3);
                    }

                    if ((Mathf.Abs(tiles3[i].transform.position.x) > 5.5) && (Mathf.Abs(tiles3[i].transform.position.y) > 3.7))
                    {
                        tiles3[i].setColor(tempRand4);
                    }
                }
                tempRand = Random.value;
                tempRand2 = Random.value;
                tempRand3 = Random.value;
                tempRand4 = Random.value;
                for (int i = 0; i < tiles4.Length; i++)
                {
                    if ((Mathf.Abs(tiles4[i].transform.position.x) < 5.5) && (Mathf.Abs(tiles4[i].transform.position.y) < 3.7))
                    {
                        tiles4[i].setColor(tempRand);
                    }

                    if ((Mathf.Abs(tiles4[i].transform.position.x) > 5.5) && (Mathf.Abs(tiles4[i].transform.position.y) < 3.7))
                    {
                        tiles4[i].setColor(tempRand2);
                    }

                    if ((Mathf.Abs(tiles4[i].transform.position.x) < 5.5) && (Mathf.Abs(tiles4[i].transform.position.y) > 3.7))
                    {
                        tiles4[i].setColor(tempRand3);
                    }

                    if ((Mathf.Abs(tiles4[i].transform.position.x) > 5.5) && (Mathf.Abs(tiles4[i].transform.position.y) > 3.7))
                    {
                        tiles4[i].setColor(tempRand4);
                    }
                }
            }
            
            if((secondDone&&firstDone)&&timeAfterFirst>= timeUntilTileChange*4)
            {
                timeUntilNextTiles = timeUntilTileChange*4;
                for (int i = 0; i<tiles.Length; i++)
                {
                    tiles[i].setColor(Random.value);
                    
                }
            }
        }
	}
}
