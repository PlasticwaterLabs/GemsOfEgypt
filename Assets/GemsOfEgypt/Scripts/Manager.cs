using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Required to load a different scene  
using UnityEngine.UI;

//Enumeration to move a planet closer to the player   --> bringPlanetsCloser() is making use of this enumeration
public enum planetViewState
{	
	Orbiting,
	rotating,
	arrange
};

public class Manager : MonoBehaviour 
{
	[SerializeField]
	GameObject placeHolder; // objects out of its orbit comes to this position.

	[SerializeField]
	string currentPlanet; // current planet that is out of its orbit.

	[SerializeField]
	Vector3 initialScale; // Holds inital scale of the object which is pulled out of its orbit. 

	[SerializeField]
	CanvasGroup blackScreen;

	[SerializeField]
	Slider progressBar;


	GameObject planetOutOfOrbit; // will hold the refrernce of the game object which will be passed out as an argument 
								//	during the first click of the mouse and using this game object the second click --> rotates the object
								//	retains the game object collected during the first click and sends it back to orbit (3rd click)					
		



	//user defined datatypes
	[SerializeField]
	planetViewState currentState;


	void Start()
	{
		print("Started manager");
		currentState = planetViewState.Orbiting;
		fadeSystem.fadeCanvGrp(blackScreen,true);

	}

	//Method Invoked by CardBoardReticle script while Trigger is Down
	public void bringPlanetsCloser(GameObject GO)
	{
			if (currentState == planetViewState.Orbiting && GO.tag == "SolarSystemObjects") 
			{
				currentPlanet = GO.name;
				GO.transform.GetComponent<SgtSimpleOrbit> ().enabled = false;
				initialScale = GO.transform.localScale;
				GO.transform.localScale = new Vector3 (3, 3, 3);
				GO.transform.position = placeHolder.transform.position;
				planetOutOfOrbit = GO;
				currentState = planetViewState.rotating;
			} 


			else if (currentState == planetViewState.rotating && planetOutOfOrbit != null) 
			{
				planetOutOfOrbit.transform.GetComponent<Planet_Y_Rot> ().enabled = true;
				currentState = planetViewState.arrange;
			} 


			else if (currentState == planetViewState.arrange && planetOutOfOrbit != null) 
			{
				planetOutOfOrbit.transform.localScale = initialScale;
				planetOutOfOrbit.transform.GetComponent<Planet_Y_Rot> ().enabled = false;
				planetOutOfOrbit.transform.GetComponent<SgtSimpleOrbit> ().enabled = true;
				currentState = planetViewState.Orbiting;
			}
		
	}



	//Mehod Invoked by Canvas button elements 
	public void exploreTerrain(GameObject Terrain)
	{
		print("hi");

		string terrain_name = Terrain.name;
		switch(terrain_name)
		{
			case "Earth":
			MySceneManager.loadLevelAsync("Earth",progressBar,blackScreen);

				break;

			case "Mars":
			MySceneManager.loadLevelAsync("Mars",progressBar,blackScreen);
				break;

			case "Moon":
			MySceneManager.loadLevelAsync("Moon",progressBar,blackScreen);
				break;

			case "Europa":
			MySceneManager.loadLevelAsync("Europa",progressBar,blackScreen);
				break;

		}
	}

	public void quitToJacket()
	{
		MySceneManager.loadLevelAsync("JacketScene",progressBar,blackScreen);
	}
}
