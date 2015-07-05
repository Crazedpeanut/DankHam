using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class PrisonLogic : MonoBehaviour {

	public GameObject rum;
	public GameObject rumText;
	public GameObject convict;
	public GameObject convictComplete;
	public GameObject door;

	public GameObject william;

	private bool canLeave;

	// Use this for initialization
	void Start () {
		convict.SetActive(true);
		convictComplete.SetActive(false);
		canLeave = false;
	}
	
	// Update is called once per frame
	void Update () {
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (Input.GetKeyDown ("e")) {
					if (hit.collider.gameObject == rum) {
						rum.SetActive(false);
						william.SetActive(false);
						convict.SetActive(false);
						convictComplete.SetActive(true);
					}
					else if(hit.collider.gameObject == door && canLeave) {
						Application.LoadLevel(Application.loadedLevel + 1);
					}
				}
		}
	}

	void OnConversationEnd(Transform actor) {
		if (actor.name == convictComplete.name) {
			canLeave = true;
		}
	}


}
