using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JacketManager : MonoBehaviour {
	[SerializeField]
	CanvasGroup blackScreen;
	[SerializeField]
	Slider progressBar;
	[SerializeField]
	bool hasUserTriggered;
	[SerializeField]
	CanvasGroup logoImage;
	[SerializeField]
	CanvasGroup menuGroup;
	// Use this for initialization
	void Awake()
	{
		hasUserTriggered=false;
	}
	void Start () {
		fadeSystem.fadeCanvGrp(blackScreen,true);
		if(!GameManager.firstTimeJacket)
		{
		menuGroup.alpha=0;
		logoImage.alpha=0;
	//	StartCoroutine(waitForTutorial());
		StartCoroutine(fadeLogo());
		}
		else
			logoImage.alpha=0;
		GameManager.firstTimeJacket=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Cardboard.SDK.Triggered)
		{
			print("NFC");
			hasUserTriggered=true;
		}
		
	}

	public void startJOE()
	{
		MySceneManager.loadLevelAsync("LandingScene",progressBar,blackScreen);
	}
	public void startDT()
	{
		MySceneManager.loadLevelAsync("ElecTutorial",progressBar,blackScreen);
	}

	public void startSolSys()
	{
		MySceneManager.loadLevelAsync("LivingRoom",progressBar,blackScreen);
	}

	public void startHeart()
	{
		MySceneManager.loadLevelAsync("HeartTutorial",progressBar,blackScreen);
	}
	public void quitWholeGame()
	{
		Application.Quit ();
	}
//	IEnumerator waitForTutorial()
//	{
//		int count=0;
//
//		while(true && !GameManager.finishedTut)
//		{
//			count++;
//			print(count);
//			if(hasUserTriggered && count<20)
//			{
//				print("breaking");
//				break;
//			}
//			else if(count>=25)
//			{
//				
//				GameManager.finishedTut=true;
//				MySceneManager.loadLevelAsync("Tutorial",progressBar,blackScreen);
//				break;
//			}
//			yield return new WaitForSeconds(0.5f);
//		}
//	}
	IEnumerator fadeLogo()
	{
		while(!fadeSystem.isFaded)
			yield return null;
		fadeSystem.fadeCanvGrp(logoImage,false);
		while(!fadeSystem.isFaded)
			yield return null;
		yield return new WaitForSeconds(1);
		fadeSystem.fadeCanvGrp(logoImage,true);
		while(!fadeSystem.isFaded)
			yield return null;
	
		yield return new WaitForSeconds(1);
		fadeSystem.fadeCanvGrp(menuGroup,false);

	}


}
