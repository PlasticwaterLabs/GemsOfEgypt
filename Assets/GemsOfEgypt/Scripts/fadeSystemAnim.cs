using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class fadeSystemAnim : MonoBehaviour 
{


	public static Animator canvas_group;
	public static fadeSystemAnim instance;
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

	public static void fadeCanvGrp(Animator cgrp,bool makeInvisible)
	{
		
		canvas_group = cgrp;
		isFaded=false;

		if (instance != null)
		{
			instance.StopAllCoroutines();

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
				canvas_group.SetTrigger ("fadeOut");
				yield return new WaitForSeconds (1.3f);
				isFaded = true;
			
			}
			else 
			{
				
				canvas_group.SetTrigger ("fadeIn");
				yield return new WaitForSeconds (1.3f);
				isFaded = true;

			}	
		}
		else
			Debug.LogError("Lost the blackscreen!!!!");
		yield return null;
	}


}
