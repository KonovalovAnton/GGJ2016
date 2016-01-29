using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	private Text timeText;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text>();
	}

	void SetTimer(int time) {
		timeText.text = time + " left";
	}

}
