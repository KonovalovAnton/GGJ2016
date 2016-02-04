using UnityEngine;
using System.Collections;

public class CameraManipulation : MonoBehaviour {

	// Use this for initialization
	public SpriteRenderer spriteRenderer;
	void Start () 
	{
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width/ Screen.height; // basically height * screen aspect ratio

		Sprite s = spriteRenderer.sprite;
		float unitWidth = s.textureRect.width / s.pixelsPerUnit;
		float unitHeight = s.textureRect.height / s.pixelsPerUnit;

		spriteRenderer.transform.localScale = new Vector3(width / unitWidth, height / unitHeight);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
