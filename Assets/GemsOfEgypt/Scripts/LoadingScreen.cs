using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour 
{
	public  Image loadingScreenImage;
	public  Sprite[] nextImages;

	//Use this for initialization
	void Start () 
	{
		loadingScreenImage.enabled = false;

	}

	public void startingCoroutineMethod()
	{
		loadingScreenImage.enabled = true;
		StartCoroutine(animateLoginScreen());
	}

	public  IEnumerator animateLoginScreen()
	{
		
		while(true)
		{
			for(int i=0; i<4; i++)
			{
				loadingScreenImage.sprite = nextImages[i];
				yield return new WaitForSeconds(0.2f);
			}

		}

	}
}
