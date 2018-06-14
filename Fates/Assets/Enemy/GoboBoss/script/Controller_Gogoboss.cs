using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Gogoboss : MonoBehaviour {

	private float speed;
	public int HP;
	private Animator anim;
 	private Transform Player;
 	private float aggroDistance;
 	private float stopDistance;
	float StartDelay = 1.5f;
	float StartDelay1 = 0.2f;
	float Delay1 = 0.2f;
	float Delay = 1.5f;

 	void Start () 
	{ 
		HP = 150;
		Delay = StartDelay;
		anim = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		speed = 3f;
		aggroDistance = 5f;
		stopDistance = 1.5f;
	}
	void Update() 
	{ 
 		if (Vector2.Distance(transform.position, Player.position) <= 5f)
		{
			var p = Player.GetComponent<Controller_Players>();
			Delay -= Time.deltaTime;
			Delay1 -= Time.deltaTime;
			if(Delay1 > 0)
			{
				anim.SetBool("Atack",true);
			}
			else
			{
				anim.SetBool("Atack",false);
			}
			if(Delay <= 0)
			{
				Delay = StartDelay;
				Delay1 = StartDelay1;
			}
		}
	}
}
