using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class PlayerScript : MonoBehaviour {
	[SerializeField]
	UnityEvent onPlayerSpawn;
	[SerializeField]
	UnityEvent playerEnteredCOP;
	[SerializeField]
	Animator fadeAnim;


	[SerializeField]
	UnityEvent onPlayerAnswered;
	void OnEnable()
	{
		onPlayerSpawn.Invoke ();		
	}

	// Use this for initialization
	void Start () {
		//fadeSystemAnim.fadeCanvGrp (fadeAnim, true);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "CircleofPower") {
			print ("COP Entered");
			playerEnteredCOP.Invoke ();
		}
	}

}
