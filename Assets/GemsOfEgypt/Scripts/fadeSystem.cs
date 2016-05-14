using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class fadeSystem : MonoBehaviour 
{


	public static  CanvasGroup canvas_group;
	public static fadeSystem instance;
	//public CanvasGroup mummyOutTimeBarContainingCanvasGroup;
	public static Coroutine instanceRoutine;
	public static bool isFaded = false;
	//public Text Killed;

//	[SerializeField]
//	GameObject above_player;
	void Awake()
	{
		
		instance = this;
	}
	// Use this for initialization
	void Start () 
	{
		
		isFaded=false;

	}

	public static void fadeCanvGrp(CanvasGroup cgrp,bool makeInvisible)
	{
		
		canvas_group = cgrp;
		isFaded=false;
		if (instance != null)
		{
			instance.StopAllCoroutines();
			canvas_group.alpha=Mathf.Abs(canvas_group.alpha);
			instanceRoutine =	instance.StartCoroutine ("doFade", makeInvisible);
		}
		else
			Debug.LogError (" FadeSystem script not present in the scene.");
	}
	
	 IEnumerator doFade(bool flag)
	{

		if(canvas_group!=null)
		{
			if (flag) 
			{
				while (  canvas_group.alpha > 0) 
				{
					canvas_group.alpha -= Time.fixedDeltaTime * 0.5f;
					yield return new WaitForEndOfFrame ();
				}
				isFaded = true;
			
			}
			else 
			{
				
				while ( canvas_group.alpha < 1) 
				{
					canvas_group.alpha += Time.fixedDeltaTime * 0.5f;
					yield return new WaitForEndOfFrame ();
				}
				isFaded = true;
			}	
		}
		else
			Debug.LogError("Lost the blackscreen!!!!");
		yield return null;
	}


}
