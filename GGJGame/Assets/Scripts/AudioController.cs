using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public AudioClip normalMusic;
	public AudioClip heavyMusic;
	public AudioSource audioSource;
	public float delay;
	bool normal = true;
	float heavyMusicStart;

	void Awake() {
		audioSource = GetComponent<AudioSource>();
	}

	void Update() {
		if (!normal && Time.time > heavyMusicStart + heavyMusic.length + delay) {
			normal = true;
			audioSource.Stop();
			audioSource.loop = true;
			audioSource.PlayOneShot(normalMusic);
		}
	}

	public void OnHeadOff() {
		if (!normal) {
			return;
		}
		normal = false;
		heavyMusicStart = Time.time;
		audioSource.Stop();
		audioSource.loop = false;
		audioSource.PlayOneShot(heavyMusic);
	}
}