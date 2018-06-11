using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Move_Player : MonoBehaviour
{
    private float SpeedDefault;
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

    // Use this for initialization
    void Start()
    {
        // Дефолтные значения
        SpeedDefault = 5f;
        AnimInt = 2;
        //-------------------

        anim = GetComponent<Animator>();
        Rig = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Speed = SpeedDefault;
        SpeedShift = Speed * 1.5f;
        Move = true;
    }

    // Update is called once per frame
    void ChechEn()
    {
        Enemy = GameObject.FindGameObjectsWithTag ("Enemy");
        if(Enemy.Length > 0)
        {
            int P = 0;
            float Min = Vector2.Distance(Player.transform.position,Enemy[0].transform.position);
            for(int i = 1; i != Enemy.Length;i++)
                if(Min > Vector2.Distance(Player.transform.position,Enemy[i].transform.position))
                    {
                        Min = Vector2.Distance(Player.transform.position,Enemy[i].transform.position);
                        P = i;
                    }
            NumberEnemy = P;
            EnemyOnMap = true;
        }
        else
        {
            EnemyOnMap = false;
        }
    }

    void Update()
    {
        ChechEn();
        if(Input.GetMouseButtonDown(0))
            if(Speed != SpeedShift)
            {
                Move = false;
                Rig.velocity = new Vector2(0f,0f);
                anim.SetBool("Atack",true);
                Atack = true;
            }
        if(Input.GetMouseButtonUp(0))
        {
            Move = true ;
            Atack = false;
            anim.SetBool("Atack",false);
        }
        if(EnemyOnMap == true && Vector2.Distance(Player.transform.position,Enemy[NumberEnemy].transform.position) <= 1.7f && Atack == true)
        {
            Atack = false;
            var p = Enemy[NumberEnemy].GetComponent<Main_Makaka>();
            p.HP -= 20;
            if(p.HP <= 0)
                Destroy(Enemy[NumberEnemy]);
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
                anim.SetFloat("Y",AnimInt);  
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
                anim.SetFloat("Y",-AnimInt);
            Rig.velocity = new Vector2(Rig.velocity.x , Input.GetAxisRaw("Vertical") * Speed);
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
        }

        if ((Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) && Move == true)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f)
                anim.SetFloat("X",AnimInt);
            else if (Input.GetAxisRaw("Horizontal") < -0.5f)
                anim.SetFloat("X",-AnimInt);
            Rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Speed, Rig.velocity.y);
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f));
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            Rig.velocity = new Vector2(0f,Rig.velocity.y);
        }

        if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            Rig.velocity = new Vector2(Rig.velocity.x,0f);
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
            anim.SetFloat("X",0);
        if (Input.GetAxisRaw("Vertical") == 0)
            anim.SetFloat("Y",0);
    }
}

