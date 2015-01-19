using UnityEngine;
using System.Collections;

public class paintcontroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.name == "Dog")
		{
			GameObject.Find("ScoreText").GetComponent<ScoreController>().Score += 10;
			Destroy(this.gameObject);
		}
	}
}
