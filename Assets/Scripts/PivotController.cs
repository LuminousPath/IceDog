using UnityEngine;
using System.Collections;

public class PivotController : MonoBehaviour {

	public float direction;
	public float pullback;
	public float maxpullback;
	bool holddown;

	// Use this for initialization
	void Start () {
		holddown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if(holddown == false)
			{
				pz.z = 0.0f;
				transform.position = pz;
			}

			GameObject PivotEnd = transform.Find("PivotEnd").gameObject;
			PivotEnd.transform.position = pz;

			holddown = true;
		}
		if(Input.GetMouseButtonUp(0))
		{
			holddown = false;
		}
	}
	
}
