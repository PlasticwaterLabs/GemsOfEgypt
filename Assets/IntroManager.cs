using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class IntroManager : MonoBehaviour {

	[SerializeField]
	AudioClip[] introRoutineAS_A;
	[SerializeField]
	AudioClip[] introRoutineAS_B;
	[SerializeField]
	AudioClip[] finishingAS;
	[SerializeField]
	Animator gemAnimator;
	[SerializeField]
	GameObject magicalCircle;
	[SerializeField]
	GameObject showersParticle;
	[SerializeField]
	AudioSource anubisVoice;
	[SerializeField]
	AudioSource backgroundMusic;
	[SerializeField]
	GameObject nfcHelper;
	Autowalk playerWalkScript;
	[SerializeField]
	Text helperText;
	float interStatementDelay;		//Delay between two consecutive statement


	[SerializeField]
	GameObject nfcTutGameObj;
	[SerializeField]
	bool NFCTutEnabled;
	bool nfcTutEnabled
	{
		get{
			return NFCTutEnabled;
		}
		set{
			print ("Set tut");
			NFCTutEnabled = value;
			if( nfcTutGameObj!=null)
				nfcTutGameObj.SetActive(nfcTutEnabled);
		}

	}

	bool isPlayerEntered;
	bool pickedSpecialObj;
	// Use this for initialization
	void Awake()
	{
		nfcTutEnabled = true;
//		nfcHelper = GameObject.FindGameObjectWithTag ("nfcHelper");
//		if (helperText != null)
//		helperText = nfcHelper.GetComponentInChildren<Text> ();

	}
	void Start () 
	{
		playerWalkScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<Autowalk>();
		anubisVoice=this.gameObject.GetComponent<AudioSource> ();
		StartCoroutine ("startAnubisIntro");

		interStatementDelay = 0.7f;
		isPlayerEntered = false;
		nfcTutEnabled = false;
	}
	


	IEnumerator speechRoutine(AudioClip[] audioSequence)
	{

		for (int i = 0; i < audioSequence.Length; i++) {
			print ("Playing" + audioSequence [i].name);
			backgroundMusic.volume = 0.01f;
			anubisVoice.clip = audioSequence [i];
			anubisVoice.Play ();
			yield return new WaitForSeconds (audioSequence[i].length);
			yield return new WaitForSeconds (interStatementDelay);
			backgroundMusic.volume = 0.1f;
		}
		
	}


	IEnumerator startAnubisIntro()
	{
		

		StartCoroutine(speechRoutine (introRoutineAS_A));
		yield return new WaitForSeconds(getTotalAudioLength (introRoutineAS_A)+(introRoutineAS_A.Length)*interStatementDelay);

		Rigidbody[] rgdBdy=gemAnimator.gameObject.GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody rb in rgdBdy)
			rb.isKinematic = true;
//		gemAnimator.SetTrigger ("startGemAnim");
//		yield return new WaitForSeconds (3);
//		foreach (Rigidbody rb in rgdBdy)
//			rb.isKinematic =false;
		magicalCircle.SetActive (true);
		nfcTutEnabled = true;
		EgyptGameAnalyzer.startWalkTimer ();
		while (!isPlayerEntered) {
			if(!playerWalkScript.isWalking)
			doubleTrigger (true);
			else
			doubleTrigger (false);
			yield return null;
		}
		EgyptGameAnalyzer.stopWalkTimer();
		nfcTutEnabled = false;
		helperText.text = "";
		showersParticle.SetActive (true);
		yield return new WaitForSeconds (5);
		showersParticle.SetActive (false);
		magicalCircle.SetActive (false);
		StartCoroutine(speechRoutine (introRoutineAS_B));
		yield return new WaitForSeconds(getTotalAudioLength (introRoutineAS_B)+(introRoutineAS_B.Length)*interStatementDelay);
		nfcTutEnabled = true;
		EgyptGameAnalyzer.startPickTimer();
		while (!pickedSpecialObj)
			yield return null;
		EgyptGameAnalyzer.stopPickTimer ();
		nfcTutEnabled = false;
		StartCoroutine(speechRoutine (finishingAS));
		yield return new WaitForSeconds(getTotalAudioLength (finishingAS)+finishingAS.Length*interStatementDelay);
		playerWalkScript.gameObject.GetComponent<M> ().moveToMainLevel ();
	}

	float getTotalAudioLength(AudioClip[] AS)
	{
		float totalAudioLength = 0;
		foreach (AudioClip a in AS) {
			totalAudioLength += a.length;
		}
		return totalAudioLength;
	}

	public void onPlayerEnteredCOP()
	{
		isPlayerEntered = true;
	}

	public void onPickedSpecialObj()
	{
		pickedSpecialObj = true;
	}
	public void doubleTrigger(bool state)
	{
		
		if (state) {
			nfcHelper.SetActive (true);
			helperText.text = "Double trigger to Walk";
		} else {
			nfcHelper.SetActive (true);
			helperText.text = "Double trigger to Stop";
		}
	}
}
