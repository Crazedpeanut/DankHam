using UnityEngine;
using System.Collections;

public class CameraNavigator : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setLocation(Vector3 loc)
	{
		this.transform.localPosition = loc;
	}
}
