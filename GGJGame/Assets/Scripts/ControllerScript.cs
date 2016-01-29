using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	bool knightIsReady = false;
	public DialogueScript UI;
	int[] QTE;

	void SetKnightReady() {
		knightIsReady = true;
		genQTE (3);
		QTEController.instance.BeginValidation(QTE);
	}

	void genQTE(int length) {
		QTE = new int[length];
		for (int i = 0; i < length; i++) {
			QTE [i] = Random.Range (0, 3);
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (knightIsReady) {

		}
	}

}