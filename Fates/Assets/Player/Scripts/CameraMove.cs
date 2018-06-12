using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject Follow;
    private Vector3 Pos;
    public float MoveSpeed;


	void Start () {
        MoveSpeed = 10f;
	}
	
	void Update () {
        Pos = new Vector3(Follow.transform.position.x, Follow.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position , Pos , MoveSpeed * Time.deltaTime);
	}
}
