using UnityEngine;
using System.Collections;

public class Emmissive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DynamicGI.SetEmissive(this.gameObject.GetComponent<Renderer>(), Color.green);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
