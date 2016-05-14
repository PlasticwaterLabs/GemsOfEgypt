using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HeartSceneManager : MonoBehaviour {
	[SerializeField]
	CanvasGroup blackScreen;
	[SerializeField]
	Slider progressBar;


	// Use this for initialization
	void Start () {
		fadeSystem.fadeCanvGrp(blackScreen,true);
	}
	
	// Update is called once per frame
	void Update () {
	 	
	}
	public void QuitToMenu()
	{
		MySceneManager.loadLevelAsync("JacketScene",progressBar,blackScreen);
	}
}
