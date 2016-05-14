using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
public class ApplicationManager : MonoBehaviour 
{


	public UnityEvent onTiltedRight;
	public UnityEvent onTiltedLeft;
	bool tiltOneFrame=true;
	[SerializeField]
	int tiltThreshold;
	Transform camTrans;
	[SerializeField]
	Text debugText;
	float tiltAngle;

			// Use this for initialization
	void Start () {
		StartCoroutine(moniterTilt());
	}
	void FixedUpdate()
	{


		//Tilt Detection 


	

	}
	IEnumerator moniterTilt()
	{
		while(this.enabled)

		{
			Vector3 crossPrd;
			crossPrd=Vector3.Cross (Camera.main.transform.forward,-Vector3.up);
			tiltAngle=Mathf.Floor(AngleSigned(crossPrd,Camera.main.transform.right,Camera.main.transform.forward));
			if(tiltAngle>=tiltThreshold)
			{
				onTiltedRight.Invoke();
			}
			if(tiltAngle<=-tiltThreshold)
			{
				onTiltedLeft.Invoke();
			}
			if(debugText!=null)
			debugText.text=tiltAngle.ToString();
			yield return new WaitForSeconds(0.5f);
		}
	}
	void tilted()
	{
		print("tilted");
	}

	public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
	{
		return  Mathf.Atan2(
			Vector3.Dot(n, Vector3.Cross(v1, v2)),
			Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
	}
}
		

