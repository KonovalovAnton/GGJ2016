using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponentInChildren<Text>();
	}

	public void SetScore (int score) {
		scoreText.text = "Score:\n" + score.ToString();
	}
}
