using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class slot : MonoBehaviour {
	[System.Serializable]
	class onObjectPlaced:UnityEvent<GameObject>
	{
		
	}

	[SerializeField]
	 onObjectPlaced placedEvent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public  void sendToSlot(GameObject other)
	{
		
		placedEvent.Invoke (other.gameObject);
	}
}
