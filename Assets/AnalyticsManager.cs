using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;
public class AnalyticsManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float temp = Random.value;
		print (temp);


		Analytics.Transaction("startGamePotion",10m,"INR", null,null);

		Gender gender = Gender.Female;
		Analytics.SetUserGender(gender);

		int birthYear = 1993;
		Analytics.SetUserBirthYear(birthYear);
	}
	//A function that creates a custom event which can be accessed by any script.
	//Used in unity analytics
	public static void sendCustomEvent(string eventName,string propertyName=null,object propertyValue=null)
	{
		if (propertyName != null && propertyValue != null) {
			Analytics.CustomEvent (eventName, new Dictionary<string,object> {
				{ propertyName,propertyValue }

			});
		} 
		else {
			Analytics.CustomEvent (eventName, new Dictionary<string,object> {});
		}
	}
}
