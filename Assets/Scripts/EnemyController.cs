using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	float walktimer;
	public int walktimermin;
	public int walktimermax;
	public float stoptime;
	public float WalkSpeed;
	public int avgploptime;
	bool stopped;
	Direction facing;
	bool edgestop;
	float Speed;
	int paintplopnum;

	float ploptimer;

	public Sprite[] paintsprites;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().enabled = true;
		walktimer = Random.Range(walktimermin, walktimermax);
		ploptimer = Random.Range (avgploptime - 2, avgploptime + 2);
		facing = (Direction)Random.Range(0, 4);
		paintplopnum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		walktimer -= Time.deltaTime;
		ploptimer -= Time.deltaTime;

		if(ploptimer <= 0)
		{
			ploppaint();
			ploptimer = Random.Range(avgploptime - 1, avgploptime + 1);
		}

		if(walktimer <= 0)
		{
			if(stopped)
			{
				stopped = false;
				walktimer = Random.Range(walktimermin, walktimermax);
				facing = (Direction)Random.Range(0, 3);
				Debug.Log("Now Moving: " + facing.ToString());
				Speed = WalkSpeed;
			}
			else
			{
				walktimer = stoptime;
				stopped = true;
				Speed = 0;
			}
		}
		else
		{
			if(facing == Direction.Up)
			{
				transform.Translate(0, 1 * Speed, 0);
			}
			if(facing == Direction.Left)
			{
				transform.Translate(-1 * Speed, 0, 0);
			}
			if(facing == Direction.Right)
			{
				transform.Translate(1 * Speed, 0, 0);
			}
			if(facing == Direction.Down)
			{
				transform.Translate(0, -1 * Speed, 0);
			}
		}
		GetComponent<Animator>().SetFloat("Speed", Speed);
		GetComponent<Animator>().SetInteger("Direction", (int)facing);
	}

	public void switchdirection()
	{
		if(facing == Direction.Up)
			facing = Direction.Down;
		else if(facing == Direction.Down)
			facing = Direction.Up;
		else if(facing == Direction.Left)
			facing = Direction.Right;
		else if(facing == Direction.Right)
			facing = Direction.Left;
		GetComponent<Animator>().SetInteger("Direction", (int)facing);
		Debug.Log("Now Facing: " + facing.ToString());
	}

	void ploppaint ()
	{
		paintplopnum++;
		var paint = new GameObject("paintplop_" + paintplopnum);
		paint.AddComponent<SpriteRenderer>();
		paint.AddComponent<BoxCollider>();
		paint.AddComponent("paintcontroller");
		paint.GetComponent<BoxCollider>().isTrigger = true;
		paint.GetComponent<SpriteRenderer>().sprite = paintsprites[Random.Range(0, 6)];
		paint.GetComponent<BoxCollider>().size = paint.GetComponent<SpriteRenderer>().sprite.bounds.size;
		paint.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,1.0f),Random.Range(0,1.0f), Random.Range(0,1.0f));
		paint.transform.position = transform.position;
		paint.GetComponent<SpriteRenderer>().sortingOrder = 0;
		Debug.Log("Created: " + paint.GetComponent<SpriteRenderer>().sprite.name);
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.name == "Dog")
		{
			Destroy (this.gameObject);
		}
	}
}

public enum Direction : int {
	Up = 0,
	Down = 1,
	Left = 2,
	Right = 3
}
