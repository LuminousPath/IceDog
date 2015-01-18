using UnityEngine;
using System.Collections;

public class DogController : MonoBehaviour {

	public BoxCollider2D IceCollider;

	public float Speed;

	public float Acceleration;

	public float Force;

	public Vector3 Direction;

	public float mass;

	public Sprite DogUp;
	public Sprite DogLeft;
	public Sprite DogRight;
	public Sprite DogDown;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite = DogLeft;
		print (GetComponent<SpriteRenderer>().sprite.name);
		if(GetComponent<SpriteRenderer>().sprite == null)
		   print("Something went wrong");
	}

	public void Bump(Vector3 direction, float Force)
	{
		Speed = Force / mass;
		this.Direction = direction;
		this.Force = Force;
	}
	
	// Update is called once per frame
	void Update () {
		if(Direction.x >= 0)
		{
			if(Direction.y >= 0)
			{
				if(Direction.x >= Direction.y)
				{
					GetComponent<SpriteRenderer>().sprite = DogRight;
				}
				else
					GetComponent<SpriteRenderer>().sprite = DogUp;
			}
		}
		else
		{
			if(Direction.y <= 0)
			{
				if(Direction.x >= Direction.y)
				{
					GetComponent<SpriteRenderer>().sprite = DogDown;
				}
				else
					GetComponent<SpriteRenderer>().sprite = DogLeft;
			}
		}

		transform.Translate(Direction.x * Speed, Direction.y * Speed, 0);
		if(Speed > 0)
			Speed = Speed + Acceleration;
		else
			Speed = 0;
	}

	void OnTriggerExit(Collider coll)
	{
		if(coll.gameObject.name == "Ice")
		{
			Speed = 0;
		}
	}
	
}
