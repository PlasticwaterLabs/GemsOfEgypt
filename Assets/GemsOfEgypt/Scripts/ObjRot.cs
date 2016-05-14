using UnityEngine;
using System.Collections;

public class ObjRot : MonoBehaviour 
{
	float y_val;
	[SerializeField]
	float speed;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("rotObj");
		y_val = transform.localEulerAngles.y;
		print (y_val);
		speed = 1;
	
	}

	
	IEnumerator rotObj()
	{
		float xCount=0;
		float yCount=0;

		while(yCount < 10 )
		{
			
			//transform.RotateAround (this.transform.position, this.transform.up, speed);
			transform.Rotate(this.gameObject.transform.up,speed);
			yCount += speed * Time.deltaTime;
			//print (yCount);
			yield return new WaitForEndOfFrame();
		}

		while(xCount < 10)
		{

			transform.RotateAround (this.transform.position, this.transform.right, speed);
			xCount += speed*Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		yield return null;
	}
}
