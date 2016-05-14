using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ElectronSceneManager : MonoBehaviour {

	[SerializeField]
	CanvasGroup blackScreen;
	[SerializeField]
	Slider progressBar;


	// Use this for initialization
	void Start () {
		fadeSystem.fadeCanvGrp(blackScreen,true);
		StartCoroutine(moniterPlayerAnim());
	}

	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator moniterPlayerAnim()
	{
		
		yield return new WaitForSeconds(16);

		MySceneManager.loadLevelAsync("JacketScene",progressBar,blackScreen);

	}
}
