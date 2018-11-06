using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {

    Image i;
    TileManage tileman;
	// Use this for initialization
	void Start () {
        i = GetComponent<Image>();
        tileman = FindObjectOfType<TileManage>();
	}
	
	// Update is called once per frame
	void Update () {
        i.fillAmount = tileman.Timee;
	}
}
