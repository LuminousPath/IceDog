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

	}

	public void Bump(Vector3 direction, float Force)
	{
		Speed = Force / mass;
		this.Direction = direction;
		this.Force = Force;
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(Direction.x) >= Mathf.Abs(Direction.y))
		{
			if(Direction.x >= 0)
				GetComponent<SpriteRenderer>().sprite = DogRight;
			else
				GetComponent<SpriteRenderer>().sprite = DogLeft;
		}
		else
		{
			if(Direction.y >= 0)
				GetComponent<SpriteRenderer>().sprite = DogUp;
			else
				GetComponent<SpriteRenderer>().sprite = DogDown;
		}

		transform.Translate(Direction.x * Speed, Direction.y * Speed, 0);
		if(Speed > 0)
			Speed = Speed + Acceleration;
		else
			Speed = 0;
	}

}
