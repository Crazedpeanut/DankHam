using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class WharfInvestigationLogic : MonoBehaviour {

	public GameObject williamSorell;

	// Use this for initialization
	void Start () {
		Debug.Log ("start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnConversationStart(Transform actor) {
		Debug.Log ("convo start");
	}

	void OnConversationEnd(Transform actor) {
		Debug.Log ("Actor is: " + actor.name);
		if (actor.name == williamSorell.name) {
			Debug.Log ("in");
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
