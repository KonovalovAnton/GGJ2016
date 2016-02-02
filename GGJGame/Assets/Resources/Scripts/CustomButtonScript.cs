using UnityEngine;
using System.Collections;

public class CustomButtonScript : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	[SerializeField] Sprite[] sprites;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnMouseEnter() {
		spriteRenderer.sprite = sprites[1];
	}

	void OnMouseDown() {
		spriteRenderer.sprite = sprites[2];
		Application.LoadLevel(1);
	}

	void OnMouseExit() {
		spriteRenderer.sprite = sprites[0];
	}
}
