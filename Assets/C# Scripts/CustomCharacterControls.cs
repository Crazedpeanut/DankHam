using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class CustomCharacterControls : MonoBehaviour {

	public bool isMouseLocked;
	private Vector3 startingPos;

	// Use this for initialization
	void Start () {
		if (isMouseLocked) {
			Screen.lockCursor = true;
			//Cursor.visible = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	
	void OnConversationStart(Transform actor)
	{
		actor.GetComponent<Collider>().enabled = false;
		startingPos = this.transform.position;

		if (isMouseLocked) {
			Screen.lockCursor = false;
			Cursor.visible = true;
		}
	}

	void OnConversationEnd(Transform actor)
	{
		Debug.Log (actor.name);
		actor.GetComponent<Collider>().enabled = true;
		this.transform.position = startingPos;

		if (isMouseLocked) {
			Screen.lockCursor = true;
			Cursor.visible = false;
		}
	}

}
