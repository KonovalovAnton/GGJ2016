using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueScript : MonoBehaviour {

	[SerializeField]SetButtonColor[] buttons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetButtons(int[] sequence) {
		gameObject.SetActive(true);
		for (int i = 0; i < sequence.Length; i++) {
			buttons[i].SetColor(sequence[i]);
		}
	}

	public void SelfDisable() {
		gameObject.SetActive(false);
	}
}
