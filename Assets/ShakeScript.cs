using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour {

    Camera m_cam;

	// Use this for initialization
	void Start () {
        m_cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void shakeScreen()
    {
        Vector3 cameraPos = m_cam.transform.position;
        float shakeX = Random.Range(-.2f, .2f) + cameraPos.x;
        float shakeY = Random.Range(-.2f, .2f) + cameraPos.y;
        cameraPos.x += shakeX;
        cameraPos.y += shakeY;
        m_cam.transform.position = cameraPos;
        StartCoroutine(goBack());
    }

    private IEnumerator goBack()
    {
        yield return new WaitForSeconds(0.1f);
        m_cam.transform.position = new Vector3(0, 0, -10);
    }
}
