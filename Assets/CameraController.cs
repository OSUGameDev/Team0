using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject bird;

	// Use this for initialization
	void Start ()
    {
        bird = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 cameraPos = this.transform.position;
        cameraPos.x = bird.transform.position.x;
        this.transform.position = cameraPos;
	}
}
