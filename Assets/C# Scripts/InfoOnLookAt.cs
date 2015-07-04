using UnityEngine;
using System.Collections;

public class InfoOnLookAt : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	Transform lastHit;
	Renderer rend;
	bool showTextDialog;
	public Transform name;



	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		showTextDialog = false;
		if(name != null)
			name.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) //mouse over object
		{
			if(hit.transform != lastHit)
			{
				if(lastHit != null && hit.transform.tag == "NPCWithTextAboveHead")
				{
					Renderer rend = lastHit.transform.GetComponent<Renderer>();
					rend.material.color = Color.white;
				}

				lastHit = hit.transform;
			}

			if(hit.transform.tag == "NPCWithTextAboveHead")
			{

				print (hit.collider.name);
				Renderer rend = hit.transform.GetComponent<Renderer>();
				rend.material.color = Color.red;
			}
		} else //mouse not over object
		{

		}*/
	}

	void OnGUI()
	{
		if (showTextDialog) 
		{
			if(GUI.Button(new Rect(100, 100, 200, 100), "A button"));
			if(GUI.Button(new Rect(100, 200, 200, 100), "Close"))
				showTextDialog = !showTextDialog;//true-> false, false->true
		}
	}

	void LateUpdate()
	{

	}


	void OnMouseEnter() {
		name.GetComponent<Renderer>().enabled = true;
		//rend.material.color = Color.red;
	}
	void OnMouseExit() {
		name.GetComponent<Renderer>().enabled = false;
		//rend.material.color = Color.white;
	}

	void OnMouseUp()
	{
		showTextDialog = !showTextDialog;//true-> false, false->true
	}
}
