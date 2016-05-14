using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {
	[SerializeField]
	int objIndex;
	[SerializeField]
	GameObject correctObject;

	Electrician electScript;
	// Use this for initialization
	void Start () {
		electScript=GameObject.FindGameObjectWithTag ("Player").GetComponent<Electrician> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void updateState()
	{
		electScript.setObjective (objIndex);
		if (electScript.validMove)
			physicalFix ();
	
	}
	public void physicalFix()
	{
		if (electScript.validMove) {
			correctObject.SetActive (true);
			this.gameObject.SetActive (false);
			electScript.validMove = false;
		}
			
	}
	
}

