using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Controller_Players : MonoBehaviour {

	private float SpeedDefault;
    public int HP;
    private Rigidbody2D Rig;
    private GameObject Player;
    private int AnimInt;
    private float Speed;
    private float SpeedShift;
    private Animator anim;
    private bool Move;
    private int NumberEnemy;
    private bool EnemyOnMap;
    private GameObject[] Enemy;
    private bool Atack;
	private float Delay;
	private float StartDelay;
    public string NameE;
    public int N;
    public Scene CurrentScene;

    // Use this for initialization
    void Start()
    {
        // Дефолтные значения
        SpeedDefault = 5f;
        AnimInt = 2;
        HP = 100;
		StartDelay = 0.4f;
        //-------------------

		Delay = StartDelay;
        CurrentScene = SceneManager.GetActiveScene();
        anim = GetComponent<Animator>();
        Rig = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Speed = SpeedDefault;
        SpeedShift = Speed * 1.5f;
        Move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Speed != SpeedShift)
            {
                Move = false;
                Rig.velocity = new Vector2(0f,0f);
                anim.SetBool("Atack",true);
				Atack = true;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            Move = true ;
			Atack = false;
            anim.SetBool("Atack",false);
        }

        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        N = Enemy.Length;
        if(Enemy.Length > 0)
        {
            int P = 0;
            float Min = 10000000f;
            for(int i = 0; i != Enemy.Length;i++)
                {
                    if(Enemy[i].name != "Finish")
                    {
                        if(Min >= Vector2.Distance(Player.transform.position,Enemy[i].transform.position))
                            {
                                P = i;
                                Min = Vector2.Distance(Player.transform.position,Enemy[i].transform.position);
                            }
                    }
                }
            NumberEnemy = P;
            EnemyOnMap = true;
            NameE = Enemy[NumberEnemy].name;
        }
        else
        {
            EnemyOnMap = false;
        }
        if(EnemyOnMap == true && Vector2.Distance(Player.transform.position,Enemy[NumberEnemy].transform.position) <= 1.7f)
        {
			Delay -= Time.deltaTime;
			if(Delay > 0)
			{
				if(Atack)
                {anim.SetBool("Atack",true);}
			}
			else
			{
				anim.SetBool("Atack",false);
			}
			if(Delay <= 0)
			{
                if(Input.GetMouseButtonDown(0))
                {
                    string Str = "";
                    int i = 0;
                    while (i != Enemy[NumberEnemy].name.Length)
                    {
                        if(Enemy[NumberEnemy].name[i] != ' ')
                        {
                            Str += Enemy[NumberEnemy].name[i];
                        }
                        else
                        {
                            break;
                        }
                        i++;
                    }
                    NameE = Str;
					switch(Str)
					{
						case "Goblen":
							var Enem = Enemy[NumberEnemy].GetComponent<Controller_Goblen>();
							Enem.HP -= 20;
							if(Enem.HP <= 0)
							{
								Animator E = Enemy[NumberEnemy].GetComponent<Animator>();
								E.SetBool("Dead",true);
                                Enem.name = "Finish";
							}
						break;
						case "Makaka":
							var Enems = Enemy[NumberEnemy].GetComponent<Move_Makaka>();
							Enems.HP -= 20;
							if(Enems.HP <= 0)
							{
								Animator E = Enemy[NumberEnemy].GetComponent<Animator>();
								E.SetBool("Dead",true);
                                Enems.name = "Finish";
							}
						break;
                        case "GoblenWAR":
                            var Enem1 = Enemy[NumberEnemy].GetComponent<Controller_GoblenWAR>();
                            Enem1.HP -= 20;
							if(Enem1.HP <= 0)
							{
								Animator E = Enemy[NumberEnemy].GetComponent<Animator>();
								E.SetBool("Dead",true);
                                Enem1.name = "Finish";
							}
                        break;
                        case "Snake":
                            var Enem2 = Enemy[NumberEnemy].GetComponent<Controller_Snake>();
                            Enem2.HP -= 20;
							if(Enem2.HP <= 0)
							{
								Animator E = Enemy[NumberEnemy].GetComponent<Animator>();
								E.SetBool("Dead",true);
                                Enem2.name = "Finish";
							}
                        break;
                        case "GoboBoss":
                            var Enem3 = Enemy[NumberEnemy].GetComponent<Controller_Gogoboss>();
                            Enem3.HP -= 20;
							if(Enem3.HP <= 0)
							{
								Animator E = Enemy[NumberEnemy].GetComponent<Animator>();
								E.SetBool("Dead",true);
                                Enem3.name = "Finish";
							}
                        break;
					}
					Delay = StartDelay;
                }
			}
		}
}
    void FixedUpdate()
    {  
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Speed = SpeedShift;
            AnimInt = 4;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            Speed = SpeedDefault;
            AnimInt = 2;
        }

        if ((Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) && Move == true)
        {
            if (Input.GetAxisRaw("Vertical") > 0.5f)
                {anim.SetFloat("Y",AnimInt);}
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
                {anim.SetFloat("Y",-AnimInt);}
            //Rig.velocity = new Vector2(Rig.velocity.x , Input.GetAxisRaw("Vertical") * Speed);
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
        }

        if ((Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) && Move == true)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f)
                {anim.SetFloat("X",AnimInt);}
            else if (Input.GetAxisRaw("Horizontal") < -0.5f)
                {anim.SetFloat("X",-AnimInt);}
            //Rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Speed, Rig.velocity.y);
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f));
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {Rig.velocity = new Vector2(0f,Rig.velocity.y);}

        if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {Rig.velocity = new Vector2(Rig.velocity.x,0f);}

        if (Input.GetAxisRaw("Horizontal") == 0)
            {anim.SetFloat("X",0);}
        if (Input.GetAxisRaw("Vertical") == 0)
            {anim.SetFloat("Y",0);}
    }
}
