using UnityEngine;
using System.Collections;
using System.Threading;

public class GraveGenerate : MonoBehaviour {

	static bool runOnce = false;

	string DB_LOC; 

	GameObject[,]  graveStones;
	DataAdapter dataAdapter;

	public GameObject mainCamera;

	bool graveGenerated = false;
	int graveCount = 0;

	int width = 100;

	int gravesPerFrame = 2000;

	int totalGravesToMake = 2000;

	Vector3 startPos;
	Vector3 endPos;

	bool doneMovingToStart = false;

	float speed = 0.1f;
	float fraction = 0;

	float startTime;
	float journeyLength;

	float waitTimer = 0;


	// Use this for initialization
	void Start () {
		/*DB_LOC = "URI=file:"+Application.dataPath+"/convicts.db";
		dataAdapter = new DataAdapter (DB_LOC);


		Debug.Log ("DB Adpater created");

		dataAdapter.setQuery("SELECT * FROM Person ORDER BY RANDOM()");

		Debug.Log ("Set Query");

		Thread t = new Thread (new ThreadStart (dataAdapter.executeQuery));
		t.Start ();
		Debug.Log ("Query Executer");

		startTime = Time.time;
		journeyLength = Vector3.Distance(startPos, endPos);*/
		GameObject go = (GameObject)Instantiate(Resources.Load ("GameObject"));
		startPos = new Vector3 (595, 5, 290);
		endPos = new Vector3 (595, 30, 100);
		mainCamera.GetComponent<CameraNavigator>().setLocation(startPos);
		graveGenerated = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		/*if (dataAdapter.isDone && !graveGenerated) 
		{
			ArrayList results = dataAdapter.results;

			for(int i = 0; i < gravesPerFrame; i++)
			{
				createTombStone((string)results[i + graveCount]);
			}

			if(graveCount >= totalGravesToMake)
			{
				graveGenerated = true;
			}
		}*/

		if (graveGenerated) 
		{
			if(waitTimer < 3) {
				//Debug.Log (waitTimer);
				waitTimer += Time.deltaTime;
			}
			else if(fraction < 1)
			{
				Debug.Log (fraction);
				fraction += Time.deltaTime * speed;
				Vector3 newPos = Vector3.Lerp(startPos, endPos, fraction);
				
				mainCamera.GetComponent<CameraNavigator>().setLocation(newPos);
			}

			/*float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			Vector3 newPos = Vector3.Lerp(startPos, endPos, 0.2f);
			Debug.Log (newPos.x + " - " + newPos.y + " - " + newPos.z);
			mainCamera.GetComponent<CameraNavigator>().setLocation(newPos);*/
		}


	}

	void createTombStone(string name)
	{
		//Debug.Log (name);
		GameObject go = (GameObject)Instantiate(Resources.Load ("TombStoneContainer"));
		Transform trans = go.transform;
		float x, y, z;

		x = this.gameObject.transform.localPosition.x + ((graveCount % width) * 12);
		y = this.gameObject.transform.localPosition.y;
		z = this.gameObject.transform.localPosition.z + ((graveCount / width) * 30);

		go.transform.localPosition = new Vector3 (x, y, z);
		go.transform.parent = this.transform;

		foreach(Transform child in go.transform)
		{
			if(child.name.Equals ("Name"))
			{
				name = name.Replace("Surname Not Recorded", "");
				child.GetComponent<TextMesh>().text = name;

				if(graveCount == totalGravesToMake/2 + (width / 2))
				{
					child.GetComponent<TextMesh>().text = "Bready, Matthew";

					Vector3 pos = go.transform.position;
					pos.x =- 5;
					pos.z =- 5;

					startPos = new Vector3(x-5, y+5, z-10);
					endPos = new Vector3(x-5, y+30, z-200);

					//Debug.Log (startPos.x + " " + startPos.y + " " + startPos.z);
					//mainCamera.GetComponent<CameraNavigator>().setLocation(startPos);
					doneMovingToStart = true;
				}
			}
		}

		graveCount++;
	}
}
