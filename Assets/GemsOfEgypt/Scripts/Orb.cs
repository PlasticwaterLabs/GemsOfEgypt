using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour 
{
	public Transform Target;
	public Transform Player;
	public NavMeshAgent nma;

	void Awake ()
	{
		transform.position = Player.transform.position;
	}

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveToTarget ();

	}

	void moveToTarget()
	{
		//transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, Time.deltaTime);
		nma.SetDestination(Target.transform.position);
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.name == "MissionAccomplished")
			Destroy (gameObject);
	}


}
