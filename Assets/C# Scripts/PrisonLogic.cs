using UnityEngine;
using System.Collections;

public class PrisonLogic : MonoBehaviour {

	public GameObject rum;
	public GameObject rumText;
	public GameObject convict;
	public GameObject convictComplete;
	public string nextLevel;

	// Use this for initialization
	void Start () {
		convict.SetActive(true);
		convictComplete.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject == rum) {
					if (Input.GetKeyDown ("e")) {
						rum.SetActive(false);
						convict.SetActive(false);
						convictComplete.SetActive(true);
					}
				}
		}
	}
}
