using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{

    public GameObject cube;
    public float gonePipes = -20;
    public float xPipes = 20;
    public float betweenPipeDistance = 3;
    public float gap = 3;

    SortedList<float, GameObject> pipesList;
    protected GameObject bird;

	// Use this for initialization
	void Start ()
    {
        pipesList = new SortedList<float, GameObject>();
        bird = GameObject.Find("Player");

    }
	

    void generatePipe(float xLoc)
    {
        const float scale = 8;
        float gapPos = Random.Range(-2, 3.5f);
        GameObject topPipe = GameObject.Instantiate(cube, new Vector3(xLoc, scale / 2 + gap / 2 + gapPos, 0), Quaternion.identity);
        GameObject bottomPipe = GameObject.Instantiate(cube, new Vector3(xLoc, -scale / 2 + -gap / 2 + gapPos, 0), Quaternion.identity);
        topPipe.transform.localScale = new Vector3(1, scale * topPipe.transform.localScale.y, 1);
        bottomPipe.transform.localScale = new Vector3(1, scale * bottomPipe.transform.localScale.y, 1);

        pipesList.Add(xLoc, topPipe);
        pipesList.Add(xLoc + .0001f, bottomPipe);
        betweenPipeDistance = Random.Range(12, 20);
    }


	// Update is called once per frame
	void Update ()
    {
        bool CheckedLast = false;
        while(!CheckedLast)
        {
            if (pipesList.Keys.Count > 0 && pipesList.Keys[0] < bird.transform.position.x + gonePipes)
            {
                Destroy(pipesList[pipesList.Keys[0]]);
                pipesList.RemoveAt(0);
            }
            else
            {
                CheckedLast = true;
            }
        }
        if(pipesList.Count < 2)
        {
            generatePipe(bird.transform.position.x + xPipes);
        }
        if(pipesList.Count >= 2 && pipesList.Keys[pipesList.Keys.Count - 2] + betweenPipeDistance < bird.transform.position.x + xPipes)
        {
            generatePipe(pipesList.Keys[pipesList.Keys.Count - 2] + betweenPipeDistance);
        }
	}
}
