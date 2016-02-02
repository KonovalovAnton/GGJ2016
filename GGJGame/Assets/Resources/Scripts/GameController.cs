using UnityEngine;
using System.Collections;

public class GameController : Singleton<GameController> {
	const string _newObjectName = "_GameController";

	public Transform knightSpawnPoint;
	public GameObject knightPrefab;
	public int[] sequence;

	bool spawnFlag = true;

	protected override string newObjectName {
		get { return _newObjectName; }
	}
	
	protected override bool dontDestroyOnLoad {
		get { return false; }
	}

	protected override void OnAwake () {
	}

	void Start() {
		QTEController.instance.BeginValidation(sequence);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}

		if (spawnFlag) {
			SpawnKnight();
		}
	}

	public void QTEResult(bool success) {
		Debug.Log(success);
	}

	public void QTEUpdate() {
		
	}

	void SpawnKnight() {
	}

	public void OnKnightReady() {
	}
}