using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	Transform player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (player,this.transform.up);
	}
}
