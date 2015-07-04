using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class IslandBoatLogic : MonoBehaviour 
{
	private Transform oldParent;
	public Collider storiesCollider;
	public string nextLevel;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnConversationStart(Transform actor)
	{
		storiesCollider.enabled = false;
	}

	void OnConversationEnd(Transform actor)
	{
		storiesCollider.enabled = true;

		Application.LoadLevel (nextLevel);
	}
}
