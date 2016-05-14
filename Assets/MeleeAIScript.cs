using UnityEngine;
using System.Collections;
public enum AIState
{
	ISIDLE,
	ISWALKING,
	ISBLOCKED,
	ISBITING,
}


[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(NavMeshAgent))]
public class MeleeAIScript : MonoBehaviour {


	public AIState curState;

	[SerializeField]
	NavMeshAgent mNavAgent;
	[SerializeField]
	GameObject target;
	[SerializeField]
	Animator anim;
	[SerializeField]
	GameObject currentObstacle;

	bool blockValid;
	Vector3 initTargetPos;
	Vector3 finalTargetPos;

	[SerializeField]
	AudioSource sfxSource;
	[SerializeField]
	AudioClip mummyIdle;
	[SerializeField]
	AudioClip mummyBiting;
	[SerializeField]
	AudioClip mummyBanganging;
	Vector3 gatePosition;
	// Use this for initialization
	void Start () {
		mNavAgent = this.GetComponent<NavMeshAgent> ();
		curState = AIState.ISIDLE;
		moveToPosition (target.transform.position);
//		loopSFX (mummyIdle);
	}
	
	// Update is called once per frame
	void Update () 
	{
		updatePath ();
		updateAnimation ();
		if(M.isInstructionFinished)
		updateSounds ();
		updateAIState ();
	}

	void moveToPosition(Vector3 position)
	{
		mNavAgent.SetDestination(position);
		initTargetPos=position;
	}

	void updatePath()
	{
		

		
		finalTargetPos=target.transform.position;
		//print(initTargetPos + "" + finalTargetPos);
		if ((finalTargetPos - initTargetPos).magnitude > 1 && curState != AIState.ISBLOCKED) 
		{
			print("je");
			moveToPosition (target.transform.position);
		} 
		else if (curState == AIState.ISBLOCKED) 
		{
			moveToPosition (gatePosition);
		}

	}
	void updateAIState()
	{
		
		float distanceToTarget = (this.transform.position - target.transform.position).magnitude;
		//print (distanceToTarget);
		if (mNavAgent.velocity.magnitude > 0 && distanceToTarget >=2.5 && curState!=AIState.ISBLOCKED)
			curState = AIState.ISWALKING;
		else if ((mNavAgent.pathStatus == NavMeshPathStatus.PathPartial|| distanceToTarget > mNavAgent.stoppingDistance)&& blockValid)
			curState = AIState.ISBLOCKED;
		else if (mNavAgent.pathStatus == NavMeshPathStatus.PathComplete && distanceToTarget <= 2.5f) 
			curState = AIState.ISBITING;
		else
			curState=AIState.ISIDLE;
	
	}
	void updateAnimation()
	{
		Vector3 dir = target.transform.position - this.transform.position;
		this.transform.forward = dir.normalized;
		this.transform.eulerAngles = new Vector3 (0,this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		switch (curState) {
		case AIState.ISIDLE:
							anim.SetTrigger ("isIdle");
							break;
		case AIState.ISBLOCKED:
			anim.SetTrigger ("isDrilling"); 
							break;
		case AIState.ISWALKING:
			anim.SetTrigger  ("isWalking"); 
							break;
		case AIState.ISBITING:
			anim.SetTrigger ("isBiting");
							break;

		}
	}
	void updateSounds()
	{
		Vector3 dir = target.transform.position - this.transform.position;
		this.transform.forward = dir.normalized;
		this.transform.eulerAngles = new Vector3 (0,this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		switch (curState) 
		{
		case AIState.ISIDLE:
			
			loopSFX (mummyIdle);
			break;
		case AIState.ISBLOCKED:
			
			loopSFX (mummyBanganging);
			break;
		case AIState.ISWALKING:
			
			loopSFX (mummyIdle);
			break;
		case AIState.ISBITING:
			
			loopSFX (mummyBiting);
			break;

		}
	}

	void OnTriggerEnter(Collider other)
	{
		//print ("Touched gate");
		if (other.tag == "gate") 
		{
			blockValid = true;
			gatePosition = other.transform.position;

		}

		if (other.tag == "Player") 
		{
			curState = AIState.ISBITING;
		}
	}
	void OnTriggerExit(Collider other)
	{
//		print ("untouched gate");
		if (other.tag == "gate") 
		{
			blockValid = false;
			moveToPosition (target.transform.position);
			
		}


	}
	void playSFX(AudioClip sound)
	{
		AudioSource.PlayClipAtPoint (sound, this.transform.position,0.7f);
	}

	void loopSFX(AudioClip sound)
	{
		if (sfxSource.clip == null || sfxSource.clip.name != sound.name) {
			sfxSource.loop = true;
			sfxSource.clip = sound;
			sfxSource.Play ();
		}
	}
}
