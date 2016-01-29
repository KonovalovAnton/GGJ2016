using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T: MonoBehaviour {
	protected static T _instance = null;
	
	public static T instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<T>();
				if (_instance == null) {
					GameObject newObject = new GameObject("_Singleton", typeof(T));
					_instance = newObject.GetComponent<T>();
					newObject.name = (_instance as Singleton<T>).newObjectName;
				}
			}
			return _instance;
		}
	}
	
	private void Awake() {
		if (_instance == null) {
			_instance = this as T;
			if (dontDestroyOnLoad) {
				GameObject.DontDestroyOnLoad(gameObject);
			}
		} else if (_instance != this) {
			Destroy(gameObject);
			return;
		}

		OnAwake();
	}

	protected virtual void OnAwake() {
	}

	protected abstract string newObjectName {
		get;
	}

	protected abstract bool dontDestroyOnLoad {
		get;
	}
}