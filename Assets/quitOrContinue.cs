using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quitOrContinue : MonoBehaviour 
{

	[SerializeField]
	Slider progressBar;
	[SerializeField]
	CanvasGroup blackScreen;

	[SerializeField]
	LoadingScreen loadScreen;

	// Use this for initialization
	void Start () 
	{
		fadeSystem.fadeCanvGrp(blackScreen,true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void tilted()
	{
 

	}

	public void quit_or_continue()
	{
		print(GameManager.previousLevel);
		//loadScreen.loadingScreenImage.enabled = true;
		loadScreen.startingCoroutineMethod();
		MySceneManager.loadLevelAsync(GameManager.previousLevel,progressBar,blackScreen);
	}
	public void quit()
	{
		//loadScreen.loadingScreenImage.enabled = true;
		loadScreen.startingCoroutineMethod();
		Application.Quit ();
	}

}
