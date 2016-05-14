using UnityEngine;
using System.Collections;


public class PointShowData : MonoBehaviour 
{
	bool leapConnected=false;
	[SerializeField]


	float length;
	float width;

	float touchDistance;
	Ray pointableRay;

	int currentHandType;
	int partIndex ;
	[SerializeField]
	GameObject pointer;
	RaycastHit pointableHit;
	bool infoTrigger;
	public bool isPointing;
	public bool isMoving;
	[SerializeField]
	 MeshRenderer[] highlightMeshes;
	 public MeshRenderer lastHighlighted;
	[SerializeField]
	HeartManager masterScript;
	[SerializeField]
	AudioClip[] audioClips;
	[SerializeField]
	AudioSource audioSource;
	[SerializeField]
	AudioSource musicSource;

	//public static bool menu_btn;

	public static bool stop_disp;

	public static bool hitting_bg;

	// Use this for initialization
	void Start () 
	{

	}

	private int hand_index_ = 0;							//0 = SemiTransperent 1= Full Transperent




	// Update is called once per frame
	void Update () 
	{

	}	


	public  void GazeBasedInfo(GameObject obj)
	{
		CardboardHead head = Cardboard.Controller.Head;
		RaycastHit hit;
		bool isLookedAt = Physics.Raycast(head.Gaze, out hit, Mathf.Infinity);

		Debug.DrawRay (head.Gaze.origin, head.Gaze.direction*hit.distance,Color.red,50);
		if(hit.collider.gameObject.tag!="Untagged")
		{
			//print (pointableHit.collider.gameObject.tag);

			InfoProvider.setSomething (hit.collider.name);

			if (lastHighlighted != null)
				lastHighlighted.enabled = false;
			 partIndex = InfoProvider.getHeartPartIndex (hit.collider.gameObject.tag);
			lastHighlighted = highlightMeshes [partIndex];
			if (audioClips [partIndex] != null) {

			
				StartCoroutine(revertBackSound());
			}
			lastHighlighted.enabled = true;
		}
	}
	IEnumerator revertBackSound()
	{
		SoundManager.fadeAudioSrc(audioSource,FadeType.FADEIN,0.5f);
		while(!SoundManager.hasFaded)
			yield return new WaitForEndOfFrame();
		SoundManager.fadeAudioSrc(musicSource,FadeType.FADEOUT,0.5f);
		while(!SoundManager.hasFaded)
			yield return new WaitForEndOfFrame();
		audioSource.clip = audioClips [partIndex];
		audioSource.Play ();
		while(audioSource.isPlaying)
			yield return new WaitForEndOfFrame();
		SoundManager.fadeAudioSrc(audioSource,FadeType.FADEOUT,0.5f);
		while(!SoundManager.hasFaded)
			yield return new WaitForEndOfFrame();
		SoundManager.fadeAudioSrc(musicSource,FadeType.FADEIN,0.3f);
	}
}



