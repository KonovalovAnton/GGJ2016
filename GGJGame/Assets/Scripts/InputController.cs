using UnityEngine;
using System.Collections;

public enum InputMode {
	Keyboard,
	Joystick
}

public class InputController : Singleton<InputController> {
	const string _newObjectName = "_InputController";

	public InputMode mode;
	public KeyCode[] joystickCodes;
	public KeyCode[] keyboardCodes;

	public Drums drums;

	protected override string newObjectName {
		get { return _newObjectName; }
	}
	
	protected override bool dontDestroyOnLoad {
		get { return false; }
	}

	protected override void OnAwake () {
	}

	void Update () {
		for (int i = 0; i < joystickCodes.Length; i++) {
			/*KeyCode code = KeyCode.A;
			switch (mode) {
			case InputMode.Joystick:
				code = joystickCodes[i];
			break;
			case InputMode.Keyboard:
				code = keyboardCodes[i];
			break;
			}*/

			if (Input.GetKeyDown(joystickCodes[i]) || Input.GetKeyDown(keyboardCodes[i])) {
					drums.PlayDrum(i);
					QTEController.instance.TakeInput(i);
					Debug.Log(i);
			}
		}
	}
}
