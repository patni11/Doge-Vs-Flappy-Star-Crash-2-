using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
	int score;
	Text scoreText;
	[SerializeField] int ScorePerHit = 1000;
	[SerializeField] int ScorePerSec = 100;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = score.ToString();
        InvokeRepeating("AddScore", 1f, 1f);
    }

    // Update is called once per frame
    private void AddScore(){
    	score = score + ScorePerSec;
    	scoreText.text = score.ToString();
    }

    public void ScoreHit(){
    	score = score + ScorePerHit;
    	scoreText.text = score.ToString();
    }
}
