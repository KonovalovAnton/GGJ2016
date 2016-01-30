using UnityEngine;
using System.Collections;

public class TestDialogue : MonoBehaviour {

	[SerializeField]DialogueScript test;

	// Use this for initialization
	void Start () {
		test.SetSequence(new int[] {1, 2, 0, 0, 1, 2});
		test.SetButtons();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			print("test");
			test.SetButtons();
		}
	}
}
