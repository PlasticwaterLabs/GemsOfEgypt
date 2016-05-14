using UnityEngine;
using System.Collections;
[RequireComponent (typeof(NavMeshAgent))]
public class Zombie : MonoBehaviour,IDamagable<float>,IKillable {
	public NavMeshAgent thisAgent;
	public GameObject playa;
	public GameObject obstacle;
	public float health;
	public Animation anim;
	public AnimationClip walk;
	public AnimationClip attack;
	public AnimationClip damaged;
	public AnimationClip die;
	public bool targetIsAlive;
	//State Machine nodes
	public bool isAttacking;
	public bool isWalking;
	public bool isDead;

	public GameObject hnd;
	public SoundMaster soundMaster;
	public AudioSource audioSource_mouth;
	public AudioSource audioSource_fx;



	// Use this for initialization
	void Start () {
		soundMaster = this.GetComponent<SoundMaster> ();
		audioSource_mouth.spatialBlend=1f;				//Full 3D 
		audioSource_fx.spatialBlend = 0.75f;				//Partial 3D sound
		thisAgent=this.GetComponent<NavMeshAgent>();
		anim = this.GetComponent<Animation> ();
		health = 100;
		print (walk);
		anim.AddClip (walk, "walk");
		anim.AddClip (attack, "attack");
		anim.AddClip (die, "die");
		print (anim.GetClipCount());
		thisAgent.stoppingDistance = 1;
		isAttacking = false;
		isWalking = true;
		targetIsAlive=true;
		isDead = false;
		playa = GameObject.FindGameObjectWithTag ("Player");
		StartCoroutine ("moan");

	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead) {


			if (!thisAgent.pathPending)
			{
				if (thisAgent.remainingDistance <= thisAgent.stoppingDistance)
				{
					if (!thisAgent.hasPath || thisAgent.velocity.sqrMagnitude == 0f)
					{
						print ("Stopped");
					}
				}
			}
		
		}
		else
		{
			StopCoroutine ("attackPlaya");
			StopCoroutine ("moan");
		}
	}
	public void Damage(float amount)
	{
	health = (health - amount) <= 0 ? 0 : health - amount;
	if (health <= 0) {
			isDead=true;

			isAttacking=false;
			isWalking=false;
			if(isDead==false)
			Kill ();
		}
	}
	public void Kill()
	{

		print ("Death");
		anim.CrossFade ("die");

		audioSource_mouth.clip = soundMaster.getRandomDeath ();
		audioSource_mouth.Play ();
		Destroy (this.gameObject, audioSource_mouth.clip.length);

	}
	public IEnumerator attackPlaya()
	{

		while (targetIsAlive && !isDead) {
			
			anim.clip=anim.GetClip("attack");
			anim.CrossFade("attack");
			audioSource_mouth.clip=soundMaster.getRandomAttack();
			audioSource_mouth.Play();
		//	playa.SendMessage ("Damage",20,SendMessageOptions.DontRequireReceiver);
		//	Instantiate(hnd);
			yield return new WaitForSeconds(2);

		}
	}
	IEnumerator moan()
	{
		 while (isWalking) {
			yield return new WaitForSeconds(Random.Range(3,10));
			audioSource_mouth.clip=soundMaster.getRandomMoan();
			audioSource_mouth.Play();

		}
	}

}
