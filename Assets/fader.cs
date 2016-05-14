using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fader : MonoBehaviour 
{

	public Image fadingImage;
	public GameObject fadingImageContainingCanvas;
	public CanvasGroup canvas_group;



	public static bool isFaded = false;

	void Start () 
	{

		canvas_group = fadingImage.GetComponent<CanvasGroup>();
		StartCoroutine ("doFade");
	}

	IEnumerator doFade()
	{
		while(canvas_group!=null && canvas_group.alpha > 0)
		{
			canvas_group.alpha -= Time.fixedDeltaTime * 0.5f;
			yield return new WaitForEndOfFrame ();
		}
		//canvas_group.interactable = false;
		fadingImageContainingCanvas.SetActive (false);
		isFaded = true;
		yield return null;
	}
}
