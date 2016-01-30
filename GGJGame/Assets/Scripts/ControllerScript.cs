using UnityEngine;
using System.Collections;

public class ControllerScript : Singleton<ControllerScript> {
	const string _newObjectName = "_ControllerScript";

	bool knightIsReady = false;
	public DialogueScript UI;
	int[] QTE;

	protected override string newObjectName {
		get { return _newObjectName; }
	}

	protected override bool dontDestroyOnLoad {
		get { return false; }
	}

	void SetKnightReady() {
		knightIsReady = true;
		genQTE (6);
		QTEController.instance.BeginValidation(QTE);
	}

	void genQTE(int length) {
		QTE = new int[length];
		for (int i = 0; i < length; i++) {
			QTE [i] = Random.Range (0, 3);
		}
	}

	public void OnQTEResult(QTEResult res) {
		switch(res)
		{
		case QTEResult.Failure: {
				UI.SelfDisable();
				break;
			}
		case QTEResult.Next: {
				UI.SetButtons();
				break;
			}
		case QTEResult.Success: {
				UI.SelfDisable();
				break;
			}
		}
	}

	void Start() {
		SetKnightReady();
	}

	// Update is called once per frame
	void Update () {
		if (knightIsReady) {

		}
	}

}