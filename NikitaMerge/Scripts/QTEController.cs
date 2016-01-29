using UnityEngine;
using System.Collections;

public class QTEController : Singleton<QTEController> {
	const string _newObjectName = "_QTEController";

	int[] sequence;
	int currentIndex;

	protected override string newObjectName {
		get { return _newObjectName; }
	}
	
	protected override bool dontDestroyOnLoad {
		get { return false; }
	}

	protected override void OnAwake() {
	}

	void Update() {
		
	}

	public void BeginValidation(int[] sequence) {
		this.sequence = sequence;
		currentIndex = 0;
	}

	public void TakeInput(int index) {
		if (currentIndex == sequence.Length) {
			return;
		}

		if (index != sequence[currentIndex]) {
			GameController.instance.QTEResult(false);
		}

		currentIndex++;
		if (currentIndex == sequence.Length) {
			GameController.instance.QTEResult(true);
		}
	}
}