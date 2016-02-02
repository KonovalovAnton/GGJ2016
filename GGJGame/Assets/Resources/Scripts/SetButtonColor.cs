using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetButtonColor : MonoBehaviour {

	[SerializeField]Sprite[] buttonColors;

	// Use this for initialization
	void Start () {
	
	}

	public void SetColor(int id) {
		GetComponent<Image>().sprite = buttonColors[id];
	}
}
