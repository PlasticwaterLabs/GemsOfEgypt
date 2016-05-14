using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour 
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
	bool[] isDone;

	void Start()
	{
		isDone = new bool[2] ;
		fadeSystem.fadeCanvGrp (blackScreen, true);
		StartCoroutine(tutorialBegin());
	}

	// Update is called once per frame
	public void onButtonClicked () 
	{
		done = true;
		if ( doubleClick == false) 
		{
			doubleClick = true;
			isDone [0] = true;
			StartCoroutine ("CloseDoubleClick");
		} else if (doubleClick ) 
		{
			doubleCheck.SetActive (true);
			isDone [1] = true;

		} 
		foreach (bool d in isDone) 
		{
			if (d == false)
				done = false;
		}
		if (done) 
		{
			
			reqAudMvToJacket();
		}
	}

	public void showStep1(bool isVisible)
	{
		steps[0].SetActive(isVisible);
	}

	IEnumerator tutorialBegin()
	{
		
	
		step1[0].SetActive(true);
		yield return new WaitForSeconds(5);
		step1[0].SetActive(false);
		step1[1].SetActive(true);
		step1[2].SetActive(true);

	
	}
//	public void initStep2()
//	{
//		StartCoroutine(startStep2());
//
//	}
//	IEnumerator startStep2()
//	{
//		yield return new WaitForSeconds(5);
//		steps[0].SetActive(false);
//		steps[1].SetActive(true);
//		step2[0].SetActive(true);
//		yield return new WaitForSeconds(5);
//		step2[0].SetActive(false);
//		step2[1].SetActive(true);
//		yield return new WaitForSeconds(5);
//		step2[1].SetActive(false);
//		step2[2].SetActive(true);
//		step2[3].SetActive(true);
//		yield return new WaitForSeconds(5);
//	}
	IEnumerator CloseDoubleClick()
	{
		yield return new WaitForSeconds (0.7f);
		doubleClick = false;
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
	public void tilted()
	{

		Application.Quit ();

	}
	IEnumerator closeRoutine()
	{
		steps[2].SetActive(false);
		steps[3].SetActive(true);
		yield return new WaitForSeconds(4);
		fadeSystem.fadeCanvGrp(blackScreen,false);
		while(!fadeSystem.isFaded)
			yield return new WaitForEndOfFrame();
			
		NFCTutorial.SetActive (false);
		MySceneManager.loadLevelAsync("JacketScene",progressBar,blackScreen);
	}

	public void reqAudMvToJacket()
	{
		
		StartCoroutine(closeRoutine());	
	}


}
