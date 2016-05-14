using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Electrician : MonoBehaviour {
	[SerializeField]
	 bool[] Objectives;
	[SerializeField]
	int[] splObjectives;
	[SerializeField]
	int[] preReqArr;
	[SerializeField]
	bool gameOver;
	[SerializeField]
	GameObject[] completionObjs;

	[SerializeField]
	Slider progressBar;

	[SerializeField]
	AudioClip[] objectiveSounds;

	[SerializeField]
	CanvasGroup blackScreen;

	[SerializeField]
	public bool validMove;
	// Use this for initialization
	void Start () {
		gameOver = false;
		validMove = false;
		fadeSystem.fadeCanvGrp (blackScreen, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setObjective(int index)
	{
		print (index);
		if (checkForSpl (index)) {
			if (isPreReqComplete (index)) {
				Objectives [index] = true;
			} else
				Objectives [index] = false;
		} else {
			Objectives [index] = true;
		}
		if (Objectives [index]) {
			validMove = true;
			if (index<objectiveSounds.Length && objectiveSounds [index] != null)
			AudioSource.PlayClipAtPoint (objectiveSounds[index],this.transform.position);
				
		}
		if (checkGameOver ()) {
			gameOver = true;

			foreach(GameObject obj in completionObjs)
			obj.SetActive (true);
			StartCoroutine (moveToNextScene());
		}

	
	}
	IEnumerator moveToNextScene()
	{
		print("Here");
		yield return new WaitForSeconds (4);
		MySceneManager.loadLevelAsync("FlowScene",progressBar,blackScreen);
	}
	 bool checkForSpl (int index)
	{
		bool isSpl = false;
		foreach (int splIndex in splObjectives) {
			if (splIndex == index) {
				isSpl = true;
				break;
			}
		}
		return isSpl;

	}
	 bool isPreReqComplete (int index)
	{
		if (Objectives [preReqArr [index]])
			return true;
		else
			return false;
	}

	bool checkGameOver()
	{
		foreach (bool obj in Objectives) {
			if (obj == false)
				return false;
		}
		return true;

	}
}
