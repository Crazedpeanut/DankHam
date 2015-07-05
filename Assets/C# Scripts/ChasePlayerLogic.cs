using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class ChasePlayerLogic : MonoBehaviour 
{
	public GameObject blacksmith;
	public GameObject blacksmithComplete;
	public GameObject bready;
	public GameObject convict;
	public GameObject horseShoeCollection;
	public GameObject horseShoes;
	private bool talkedToBlacksmithOnce;

	// Use this for initialization
	void Start () {
		horseShoeCollection.SetActive(false);
		blacksmithComplete.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("e")) {
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject == horseShoes) {
					horseShoeCollection.SetActive(false);
					blacksmith.SetActive(false);
					blacksmithComplete.SetActive(true);
				}
			}
		}
	}

	void OnConversationStart(Transform actor)
	{
		if (actor.name == blacksmith.name) {

			if (!talkedToBlacksmithOnce) {
				talkedToBlacksmithOnce = true;
				horseShoeCollection.SetActive (true);//make the quest start
			}
		} else if (actor.name == convict.name) {

		} else if (actor.name == bready.name) {
		}
	}

	void OnConversationEnd(Transform actor)
	{
		if (actor.name == bready.name) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
