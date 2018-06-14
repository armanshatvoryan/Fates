using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Goblen : MonoBehaviour {

	private float Speed;
	public int HP;
	private Animator Anim;
 	private Transform Player;
 	private float AggroDistance;
 	private float StopDistance;
	 // Delay
	float StartDelay;
	float StartDelay1;
	float Delay1;
	float Delay;
	//------------------

 	void Start () 
	{ 
		StartDelay = 1.5f; StartDelay1 = 0.5f;
		HP = 100;
		Delay = StartDelay;
		Delay1 = StartDelay1;
		Anim = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		Speed = 3f;
		AggroDistance = 5f;
		StopDistance = 1.7f;
	}
	void Update() 
	{ 
 		if (Vector2.Distance(transform.position, Player.position) <= 1.7f)
		{
			var p = Player.GetComponent<Controller_Players>();
			if(HP > 0)
			{
				Delay -= Time.deltaTime;
				Delay1 -= Time.deltaTime;
				if(Delay1 > 0)
				{
					Anim.SetBool("Atack",true);
				}
				else
				{
					Anim.SetBool("Atack",false);
				}
				if(Delay <= 0)
				{
					p.HP -= 20;
					Delay = StartDelay;
					Delay1 = StartDelay1;
				}
			}
		}
		else
			Anim.SetBool("Atack",false);

		if ((Vector2.Distance(transform.position, Player.position) < AggroDistance ) && (Vector2.Distance(transform.position, Player.position) > StopDistance)) 
		{ 
			float x = transform.position.x;
			float y = transform.position.y;
			if(HP > 0)
				transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
			if(transform.position.x > x){Anim.SetFloat("X",1);}
			else if(transform.position.x < x){Anim.SetFloat("X",-1);}
		}
		else
		{
			Anim.SetFloat("X",0);
		}
		
	}
}
