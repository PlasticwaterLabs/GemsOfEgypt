using UnityEngine;
using System.Collections;

public class printPosition : MonoBehaviour {
	static GameObject thisIns;
	// Use this for initialization
	void Start () {
		thisIns = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void printPos()
	{
		print (thisIns.transform.position);
	}
}
