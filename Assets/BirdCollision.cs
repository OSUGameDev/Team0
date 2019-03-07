using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdCollision : MonoBehaviour
{
    public int score = 0;
    public GameObject currentText;
    // Start is called before the first frame update

    private void Update()
    {
        currentText = GameObject.FindGameObjectsWithTag("UI")[0];
    }

    void OnCollisionEnter(Collision collision)
    {
        score += 1;
        currentText.GetComponent<Text>().text = score.ToString();
        Debug.Log(score);
    }
}
