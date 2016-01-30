using UnityEngine;
using System.Collections;

public enum QTEResult {
	Success,
	Failure,
	Next
}

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
		if (sequence == null) {
			return;
		}

		if (currentIndex == sequence.Length) {
			return;
		}

		if (index != sequence[currentIndex]) {
			ControllerScript.instance.OnQTEResult(QTEResult.Failure);
			sequence = null;
			return;
		}

		currentIndex++;
		if (currentIndex == sequence.Length) {
			ControllerScript.instance.OnQTEResult(QTEResult.Success);
			sequence = null;
		} else if(currentIndex<sequence.Length){
			ControllerScript.instance.OnQTEResult(QTEResult.Next);
		}
	}
}