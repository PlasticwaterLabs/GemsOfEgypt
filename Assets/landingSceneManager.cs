using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class landingSceneManager : MonoBehaviour {
	[SerializeField]
	CanvasGroup blackScreen;
	[SerializeField]
	Slider slider;
	// Use this for initialization
	void Start () {
		StartCoroutine ("autoStartIntro");
		fadeSystem.fadeCanvGrp (blackScreen, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void startGame()
	{
		MySceneManager.loadLevelAsync ("Level1", slider, blackScreen);
	}

	public void startIntro()
	{
		MySceneManager.loadLevelAsync ("IntroScene", slider, blackScreen);
	}

	IEnumerator autoStartIntro()
	{
		yield return new WaitForSeconds (5);
		startIntro ();
	}
}
