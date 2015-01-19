using UnityEngine;
using System.Collections;

public class EdgeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll)
	{
		Debug.Log("Edge Collide with: " + coll.name);
		if(coll.gameObject.name == "Enemy")
		{
			coll.gameObject.GetComponent<EnemyController>().switchdirection();
		}
		if(coll.gameObject.name == "Dog")
		{
			coll.gameObject.GetComponent<DogController>().Speed = 0;
		}
	}

	void OnTriggerStay(Collider coll)
	{
		if(coll.gameObject.name == "Dog")
		{
			coll.gameObject.GetComponent<DogController>().Speed = 0;
		}
	}
	
}
