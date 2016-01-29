using UnityEngine;
using System.Collections;

public class TestDialogue : MonoBehaviour {

	[SerializeField]DialogueScript test;

	// Use this for initialization
	void Start () {
		test.SetButtons(new int[] {1, 1, 2});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
