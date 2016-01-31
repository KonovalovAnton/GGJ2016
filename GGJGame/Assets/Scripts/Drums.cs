using UnityEngine;
using System.Collections;

public class Drums : MonoBehaviour {

	public AudioClip[] clips;
	public float delay = 0.1f;

	AudioSource cahedAudio;
	float lastTimePlayed;

	void Awake() {
		cahedAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayDrum(int index) {
		cahedAudio.PlayOneShot(clips[index]);
	}
}