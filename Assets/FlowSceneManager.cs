using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FlowSceneManager : MonoBehaviour {

	[SerializeField]
	CanvasGroup blackScreen;
	[SerializeField]
	Slider progressBar;
	[SerializeField]
	Animator playerAnim;
	[SerializeField]
	Animator plug;
	[SerializeField]
	AudioSource  sfxSource;
	[SerializeField]
	AudioClip socketin;

	[SerializeField]
	AudioClip electronSound;

	[SerializeField]
	AudioSource switchSource;

	void Awake()
	{
		
	}


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
		yield return new WaitForSeconds(3);
		sfxSource.clip=socketin;
		sfxSource.Play();
		yield return new WaitForSeconds(0.5f);
		switchSource.Play();

		yield return new WaitForSeconds(1);
		sfxSource.clip=electronSound;
		sfxSource.Play();


		yield return new WaitForSeconds(15.5f);

		MySceneManager.loadLevelAsync("ElectronTunnle",progressBar,blackScreen);
	
	}

}
