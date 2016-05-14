using UnityEngine;
using System.Collections;

enum mummyState
{
	isIdle,
	isWalking,
	isAttacking,
}


public class MummyAI : MonoBehaviour {

	[SerializeField]
	NavMeshAgent navAgent;

	[SerializeField]
	mummyState currentState;

	[SerializeField]
	GameObject player;

	[SerializeField]
	Animator anim;

	[SerializeField]
	string lastAnimState;

	[SerializeField]
	float delayToAggression;

	[SerializeField]
	bool isAggressive;

	// Use this for initialization
	void Start () {
		currentState = mummyState.isIdle;
		lastAnimState = "isIdle";
		isAggressive = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == mummyState.isIdle && !isAggressive) {
			if (lastAnimState != "isIdle") {
				anim.SetBool (lastAnimState, false);
				anim.SetBool ("isIdle", true);
				lastAnimState = "isIdle";
	
			}	
				
		} else if (isAggressive) {
			
		}

			

	}


	IEnumerator makeAggressive()
	{
		yield return new WaitForSeconds (delayToAggression);
		isAggressive = true;
	}
}
