using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ElecTutorial : MonoBehaviour 
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
		StartCoroutine(tutorialBegin());
	}

	// Update is called once per frame
	public void onButtonClicked () 
	{
		done = true;
		if ( doubleClick == false) 
		{
			doubleClick = true;
			StartCoroutine ("CloseDoubleClick");
		} else if (doubleClick ) 
		{
			doubleCheck.SetActive (true);
			isDone=true;

		} 

		if (isDone) 
		{
			
		movToElecGame();
		}
	}

	public void showStep1(bool isVisible)
	{
		steps[0].SetActive(isVisible);
	}

	IEnumerator tutorialBegin()
	{
		
	
		step1[0].SetActive(true);
		yield return new WaitForSeconds(5f);
		step1[0].SetActive(false);
		step1[1].SetActive(true);
		yield return new WaitForSeconds(3.5f);
		step1[1].SetActive(false);
		initStep2();
	
	}
	public void initStep2()
	{
		StartCoroutine(startStep2());

	}
	IEnumerator startStep2()
	{
		yield return new WaitForSeconds(3.5f);
		steps[0].SetActive(false);
		steps[1].SetActive(true);
		step2[0].SetActive(true);
		yield return new WaitForSeconds(3.5f);
		step2[0].SetActive(false);
		step2[1].SetActive(true);
		yield return new WaitForSeconds(3.5f);
		step2[1].SetActive(false);
		step2[2].SetActive(true);
		step2[3].SetActive(true);
	
	}
	IEnumerator CloseDoubleClick()
	{
		yield return new WaitForSeconds (0.6f);
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
		
		yield return new WaitForSeconds(2);
		fadeSystem.fadeCanvGrp(blackScreen,false);
		while(!fadeSystem.isFaded)
			yield return new WaitForEndOfFrame();
			
		NFCTutorial.SetActive (false);
		MySceneManager.loadLevelAsync("EleLevel1",progressBar,blackScreen);
	}

	public void movToElecGame()
	{
		
		StartCoroutine(closeRoutine());	
	}


}
