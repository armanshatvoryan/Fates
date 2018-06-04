using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Move : MonoBehaviour
{
    public float Speed;
    private float Speeds;
    private float SpeedShift;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Speed = 5f;
        Speeds = Speed;
        SpeedShift = Speed * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Speed = SpeedShift;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            Speed = Speeds;
        }
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f));
            if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                anim.SetFloat("X",Speed);
            }
            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                anim.SetFloat("X",-1*(Speed));
            }
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                anim.SetFloat("Y",Speed);
            }
            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                anim.SetFloat("Y",-1*(Speed));
            }
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetFloat("X",0);
        }
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            anim.SetFloat("Y",0);
        }
    }
}

