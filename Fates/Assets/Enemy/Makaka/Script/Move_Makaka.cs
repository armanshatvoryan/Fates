using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_Makaka : MonoBehaviour {

	private float speed;
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
		Delay = StartDelay;
		anim = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		speed = 3f;
		aggroDistance = 5f;
		stopDistance = 1.7f;
	}
	void Update() 
	{ 
 		if (Vector2.Distance(transform.position, Player.position) <= 1.5f)
		{
			var p = Player.GetComponent<Main>();
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
				p.HP -= 20;
				Delay = StartDelay;
				Delay1 = StartDelay1;
			}
		}

		if ((Vector2.Distance(transform.position, Player.position) < aggroDistance ) && (Vector2.Distance(transform.position, Player.position) > stopDistance)) 
		{ 
			float x = transform.position.x;
			float y = transform.position.y;
			transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
			if(transform.position.x > x){anim.SetFloat("X",1);}
			else if(transform.position.x < x){anim.SetFloat("X",-1);}
			if(transform.position.y > y){anim.SetFloat("Y",1);}
			else if(transform.position.y < y){anim.SetFloat("Y",-1);}
		}
		else
		{
			anim.SetFloat("X",0);
			anim.SetFloat("Y",0);
		}
		
	}
}
