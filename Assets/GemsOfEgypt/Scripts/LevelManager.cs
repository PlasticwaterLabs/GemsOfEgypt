using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour {

	[SerializeField]
	CanvasGroup blackScreen;
	[SerializeField]
	Slider progressBar;
	// Use this for initialization
	void Start () {
		print ("Start of level Manager");
		fadeSystem.fadeCanvGrp (blackScreen, true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void loadJacketScene()
	{
		MySceneManager.loadLevelAsync("JacketScene",progressBar,blackScreen);
	}
}
