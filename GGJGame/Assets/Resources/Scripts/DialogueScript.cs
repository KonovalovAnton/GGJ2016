using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DialogueScript : MonoBehaviour {

	[SerializeField]SetButtonColor[] buttons;
	int [] whiteBlocks = new int[] {4, 4, 4};
	int[] sequence;
	int i;
	Score score;

	void Awake() {
		score = GetComponentInParent<Score> ();
		gameObject.SetActive(false);
	}

	public void SetSequence(int[] sequence) {
		//this.sequence = sequence.Concat(whiteBlocks);
		var list = new List<int>();
		list.AddRange(sequence);
		list.AddRange(whiteBlocks);
		this.sequence = list.ToArray();
		SetButtons ();
	}

	/*public void SetButtons(int[] sequence) {
		gameObject.SetActive(true);
		for (int i = 0; i < sequence.Length; i++) {
			buttons[i].SetColor(sequence[i]);
		}
	}*/

	public void SetButtons() {
		gameObject.SetActive(true);
		int j = i + 2;
//		print("i: " + i + " j: " + j);
		for (int k = 0; k < buttons.Length; k++) {
			buttons[k].SetColor(sequence[i+k]);
		}
		i++;
	}

	public void SelfDisable() {
		gameObject.SetActive(false);
		i = 0;
	}

	public void setScore(int points) {
		score.SetScore (points);
	}

	public void setTime(int seconds) {

	}
}
