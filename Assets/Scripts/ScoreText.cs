using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	private Text text; //UI component of the score
	public static int score; //Score of the player

    //Initialize the score
	void Start ()
    {
		text = GetComponent<Text>();
		score = 0;
	}
	
	//Update the acore
	void Update ()
    {
		text.text = "Score: " + score;
	}
}
