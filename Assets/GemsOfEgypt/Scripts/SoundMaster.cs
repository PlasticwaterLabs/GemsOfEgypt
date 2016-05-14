using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundMaster : MonoBehaviour {
	[SerializeField]
	private List<AudioClip> attackList;
	[SerializeField]
	private List<AudioClip> moanList;
	[SerializeField]
	private List<AudioClip> hurtList;
	[SerializeField]
	private List<AudioClip> deathList;
	[SerializeField]
	private List<AudioClip> ambianceList;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public AudioClip getRandomAttack()
	{
		if (attackList.Count > 0)
			return attackList [Random.Range (0, attackList.Count )];
		else {
			Debug.LogError ("Add at least one Attack Sound");
			return null;
		}
	}
	public AudioClip getRandomMoan()
	{
		if (attackList.Count > 0)
			return moanList [Random.Range (0, moanList.Count)];
		else {
			Debug.LogError ("Add at least one Moan Sound");
			return null;
		}
	}
	public AudioClip getRandomHurt()
	{
		if (attackList.Count > 0)
			return hurtList [Random.Range (0, hurtList.Count)];
		else {
			Debug.LogError ("Add at least one Hurt Sound");
			return null;
		}
	}
	public AudioClip getRandomDeath()
	{
		if (attackList.Count > 0)
			return deathList [Random.Range (0, deathList.Count )];
		else {
			Debug.LogError ("Add at least one Death Sound");
			return null;
		}
	}
	public AudioClip getRandomAmbiance()
	{
		if (attackList.Count > 0)
			return ambianceList [Random.Range (0, ambianceList.Count )];
		else {
			Debug.LogError ("Add at least one Ambiance Sound");
			return null;
		}
	}

}
