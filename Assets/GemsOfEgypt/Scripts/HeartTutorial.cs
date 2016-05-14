using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HeartTutorial: MonoBehaviour 
{

	int checkCount;
	[SerializeField]
	GameObject NFCTutorial;
	[SerializeField]
	GameObject TiltTutorial;
	bool doubleClick;
	[SerializeField]
	GameObject doubleCheck;
	[SerializeField]
	GameObject[]  steps;
	[SerializeField]
	GameObject[] step1;

	[SerializeField]
	Slider progressBar;
	[SerializeField]
	GameObject[] step2;


	[SerializeField]
	CanvasGroup blackScreen;




	bool done;
	bool isDone;

	void Start()
	{
		isDone = false;
		fadeSystem.fadeCanvGrp (blackScreen, true);
		StartCoroutine(closeRoutine());
	}

	// Update is called once per frame
	public void onButtonClicked () 
	{
		
	}

	public void showStep1(bool isVisible)
	{
		steps[0].SetActive(isVisible);
	}



	// Update is called once per frame
	void Update () 
	{

	}

	public void updateCheckCount()
	{
		checkCount++;
		if (checkCount == 1) 
		{
			TiltTutorial.SetActive (false);
		}
	
	}

	IEnumerator closeRoutine()
	{
		
		yield return new WaitForSeconds(7);
		fadeSystem.fadeCanvGrp(blackScreen,false);
		while(!fadeSystem.isFaded)
			yield return new WaitForEndOfFrame();
			
		NFCTutorial.SetActive (false);
		MySceneManager.loadLevelAsync("SunH3",progressBar,blackScreen);
	}



}
