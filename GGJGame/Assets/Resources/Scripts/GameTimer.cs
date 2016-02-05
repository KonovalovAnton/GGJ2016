using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float timeLeft;
	private Text timeText;

	// Use this for initialization
	void Start () {
		print(Camera.main.aspect);
		timeText = GetComponent<Text>();
	}

	void SetTimer(int time) {
		timeText.text = "Timer:\n" + time;
	}

	void Update() {
		if ((int)timeLeft == 0) {
			Resources.UnloadUnusedAssets();
			Application.LoadLevel (2);
//			print("Round end");
		}
		else {
			timeLeft -= Time.deltaTime;
			SetTimer((int)timeLeft);
		}
	}
}
