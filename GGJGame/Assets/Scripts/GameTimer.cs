using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float timeLeft;
	private Text timeText;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text>();
	}

	void SetTimer(int time) {
		timeText.text = time + " left";
	}

	void Update() {
		if ((int)timeLeft == 0) {
//			print("Round end");
		}
		else {
			timeLeft -= Time.deltaTime;
			SetTimer((int)timeLeft);
		}
	}
}
