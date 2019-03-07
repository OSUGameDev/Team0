using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float gravity = 9.8f;
    public float punch = 20f;
    public float left = 10f;
    protected Vector2 velocity = new Vector2(1,0);
    protected Vector2 acceleration = new Vector2(0, 0);

	// Use this for initialization
	void Start ()
    {
        acceleration.y -= gravity;
        velocity.x = left;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 deltaPos = Time.deltaTime * velocity + 0.5f * Time.deltaTime * Time.deltaTime * acceleration;
        velocity += Time.deltaTime * acceleration;
        this.transform.position += new Vector3(deltaPos.x, deltaPos.y, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y += punch * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
