using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class TerrainManager : MonoBehaviour 
{
	[SerializeField]
	Slider slider_Indicating_Players_Oxygen_Level;
	[SerializeField]
	Slider progressBar;

	[SerializeField]
	CanvasGroup blackScreen;

	void Start () 
	{
		slider_Indicating_Players_Oxygen_Level.value = 100;
		fadeSystem.fadeCanvGrp(blackScreen,true);
		slider_Indicating_Players_Oxygen_Level.gameObject.SetActive(true);
	}

	void FixedUpdate()
	{
		slider_Indicating_Players_Oxygen_Level.value -= Time.fixedDeltaTime;
		if(slider_Indicating_Players_Oxygen_Level.value <= 95)
		{
			SceneManager.LoadScene ("LivingRoom");
		}
	}
}
