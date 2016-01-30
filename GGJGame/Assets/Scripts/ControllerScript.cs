using UnityEngine;
using System.Collections;

public class ControllerScript : Singleton<ControllerScript> {
	const string _newObjectName = "_ControllerScript";

	bool knightIsReady = false;
	public DialogueScript UI;
	public KnightBehaviour knight;
	int score = 0;
	int[] QTE;

	protected override string newObjectName {
		get { return _newObjectName; }
	}

	protected override bool dontDestroyOnLoad {
		get { return false; }
	}

	public void SetKnightReady() {
		knightIsReady = true;
		genQTE (2);
		UI.SetSequence (QTE);
		QTEController.instance.BeginValidation(QTE);
	}

	void genQTE(int length) {
		QTE = new int[length];
		for (int i = 0; i < length; i++) {
			QTE [i] = Random.Range (0, 3);
		}
	}

	public void OnQTEResult(QTEResult res) {
		Debug.Log (res);
		switch(res)
		{
			case QTEResult.Failure: {
					UI.SelfDisable();
					knight.setKneesOff (true);
					break;
				}
			case QTEResult.Next: {
					UI.SetButtons();
					break;
				}
			case QTEResult.Success: {
					UI.SelfDisable();
					score++;
					UI.setScore (score);
					knight.setKneesOff (false);
					break;
				}
			}
	}

	void Start() {
		UI.setScore (score);
	}

	// Update is called once per frame
	void Update () {
		if (knightIsReady) {

		}
	}

}