using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class EgyptGameAnalyzer : MonoBehaviour {



	static float walkTimer;
	static bool walkState = true;
	static float pickupTimer;
	static bool pickupState = true;
	static int sessionLevelCount;
	static EgyptGameAnalyzer instance;
	static bool hasLookedAtMummy;



	public void Awake()
	{
		instance = this;
		GameObject.DontDestroyOnLoad (this.gameObject);
		hasLookedAtMummy = false;
	}

	//Calling this function will incerease number of players who skipped tutorials.
	public void tutrialSkipped()
	{
		AnalyticsManager.sendCustomEvent ("TutorialSkipped", null, null);
	}


	//Start the timer to see how long does it take for him to walk after instructing
	public static void startWalkTimer()
	{
		
		instance.StartCoroutine (startWalkTimerR ());
	}

	static IEnumerator startWalkTimerR()
	{
		while (walkState) 
		{
			walkTimer += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		AnalyticsManager.sendCustomEvent ("startedWalking", "walkLearningDelay", walkTimer);
	}

	//Call this when he starts walking
	public static void stopWalkTimer()
	{

		walkState = false;
	}
	//Call this function when user has  just instructed to pickup
	public static void startPickTimer()
	{

		instance.StartCoroutine (startPickupTimer ());
	}


	static IEnumerator startPickupTimer()
	{
		while (pickupState) 
		{
			pickupTimer += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		AnalyticsManager.sendCustomEvent ("pickedUp", "pickupLearningDelay", walkTimer);
	}

	//Call this when he just picks up the gem in tutorial
	public static void stopPickTimer()
	{
		pickupState = false;
	}

	//Function increments number of people who saw the mummy
	public static void sendLookedAtMummy()
	{
		if (!hasLookedAtMummy) {
			hasLookedAtMummy = true;
			AnalyticsManager.sendCustomEvent ("lookedAtMummy", null, null);
		}
	}

	void OnLevelWasLoaded()
	{
		int currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
		if(currentSceneIndex>1 && currentSceneIndex!=5 )
		sessionLevelCount++;
	}

	void OnApplicationQuit()
	{
		AnalyticsManager.sendCustomEvent ("appQuit", "numberOfLevels", sessionLevelCount);
	}
}
