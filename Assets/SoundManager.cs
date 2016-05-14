using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum FadeType
{
	FADEOUT,
	FADEIN,
};
public class SoundManager : MonoBehaviour {
	static SoundManager instance;
	static int instanceID=-1;
	// Use this for initialization
	static FadeType fadeType;
	static float fadeSpeed;
	static int tempId;
	static AudioSource audSrc;
	public static bool hasFaded;
	void Awake () {
		instance=this;
	
	}


	// Update is called once per frame
	void Update () {
	
	}

	static public void fadeAudioSrc(AudioSource asrc, FadeType ft,float fs)
	{
		audSrc=asrc;
		fadeType=ft;
		fadeSpeed=fs;


//		instances.Insert(tempId,new SoundManager());
//
//		print(instances[tempId].ToString()+" "+audSrc+" "+fadeType+" "+fadeSpeed+" "+tempId);
		instance.StartCoroutine(fadeSound(audSrc,fadeType,fadeSpeed));

	}
	static IEnumerator fadeSound(AudioSource audSrc,FadeType fadeType,float fadeSpeed)
	{
		hasFaded=false;
		if(fadeType==FadeType.FADEOUT)
		{
			while(audSrc.volume>0)
			{
				audSrc.volume-=Time.deltaTime*fadeSpeed;
				yield return new WaitForEndOfFrame();
			}
			hasFaded=true;
		}
		else if(fadeType==FadeType.FADEIN)
		{
			while(audSrc.volume<1)
			{
				audSrc.volume+=Time.deltaTime*fadeSpeed;
				yield return new WaitForEndOfFrame();
			}
			hasFaded=true;
		}

	}
//	 static int getNewInstanceID()
//	{
//		 int i;
//
//
//		for( i=0;i<instances.Capacity;i++)
//		{
//			print(instances.Count+" "+ i);
//			if(instances.Count<=i || instances[i]==null)
//				return i;
//		}
//		if(i>=instances.Capacity-1)
//		{
//			Debug.LogError("Error too many Audio fades at same time.Limit is 50 fades.");
//			return -1;
//		}
//		else
//		{
//			Debug.LogError("Unknown error in audiomanager");
//			return -2;
//		}
//	}
}
