using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour {
    public GameObject Player;
    public float Speed;
    public Vector3 positionX;
    private float Delay;
    private float StartD;
    public string S;
    private bool Atack;
    void Start()
    {
        StartD = 1.5f;
        Delay = StartD;
        Speed = 10f;
        Player = GameObject.FindGameObjectWithTag("Player");
        Transform s = Player.GetComponent<Transform>();
        positionX = s.position;
        Atack = true;
    }

    void Update()
    {
        Transform s = Player.GetComponent<Transform>();
        Vector3 vectorToTarget = positionX - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
        transform.position = Vector2.MoveTowards(transform.position, positionX, Speed * Time.deltaTime);
        Delay -= Time.deltaTime;
        var Ar = gameObject;
        if(Vector2.Distance(s.position,transform.position) <= 0.1f)
            {
                var N = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller_Players>();
                if(Atack)
                {
                    N.HP -= 30;
                    Atack = false;
                }
            }
        if(Delay <= 0)
        {
            Destroy(gameObject);
        }
    }
}
