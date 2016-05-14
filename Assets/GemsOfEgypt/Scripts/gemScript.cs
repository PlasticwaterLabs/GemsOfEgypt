using UnityEngine;
using System.Collections;

public class gemScript : MonoBehaviour {

	Rigidbody rgbd;
	// Use this for initialization
	void Start () {
		rgbd = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void resetKinamatism()
	{
		StartCoroutine ("becomeKinamatic");
	}

	IEnumerator becomeKinamatic()
	{

		yield return new WaitForSeconds (3);
		rgbd.isKinematic = true;
	}
}
