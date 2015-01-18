using UnityEngine;
using System.Collections;

public class PivotController : MonoBehaviour {

	public Vector3 direction;
	public float pullback;
	public float maxpullback;
	public DogController Dog;
	bool holddown;
	GameObject PivotEnd;
	GameObject Dot1;
	GameObject Dot2;
	GameObject Dot3;

	// Use this for initialization
	void Start () {
		holddown = false;
		PivotEnd = transform.Find("PivotEnd").gameObject;
		Dot1 = transform.Find("Dot1").gameObject;
		Dot2 = transform.Find ("Dot2").gameObject;
		Dot3 = transform.Find("Dot3").gameObject;
		PivotEnd.renderer.enabled = false;
		Dot1.renderer.enabled = false;
		Dot2.renderer.enabled = false;
		Dot3.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pz.z = 0f;

		if(Input.GetMouseButtonUp(0))
		{
			holddown = false;
			PivotEnd.renderer.enabled = false;
			Dot1.renderer.enabled = false;
			Dot2.renderer.enabled = false;
			Dot3.renderer.enabled = false;
			pullback = Vector3.Distance(transform.position, PivotEnd.transform.position);
			direction = transform.position - pz;
			Dog.Bump(direction, pullback);
		}
		if(Input.GetMouseButtonDown(0))
		{
			holddown = true;
			//GameObject.Find("Dog").transform.position = pz;
			transform.position = pz;
		}

		if(holddown == true)
		{
			var distance = Vector3.Distance(transform.position, pz);
			//Debug.DrawLine(transform.position, pz);
			//print("Distance: " + distance);
			if(distance <= maxpullback)
			{
				Vector3 diff = transform.position - pz;
				diff.Normalize();

				float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
				PivotEnd.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
				Debug.DrawRay(pz, diff);

				PivotEnd.renderer.enabled = true;
				Dot1.renderer.enabled = true;
				Dot2.renderer.enabled = true;
				Dot3.renderer.enabled = true;

				PivotEnd.transform.position = pz;

				diff = -(transform.position - pz);

				Dot1.transform.localPosition = diff/4;
				Dot2.transform.localPosition = diff/4 * 2;
				Dot3.transform.localPosition = diff/4 * 3;
			}
		}

	}
	
}
