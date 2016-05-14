using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ViewState
{
	INSPECTING,
	IMENU,
	FREE
};
	

public class M : MonoBehaviour 
{
	public GameObject Reticle;
	public GameObject C;
	public GameObject Camera;
	public Vector3 initposn;
	public bool object_is_being_viewed;
	public int object_posn_move_counter;
	public GameObject threeD_Object;
	public GameObject Slot;


	[SerializeField]
	Image oblixHealth;

	[SerializeField]
	Image oblixHealth_burnt;

	[SerializeField]
	Slider progressBar;

//	[SerializeField]
//	GameObject killedText;


	[SerializeField]
	Image Health;


	[SerializeField]
	Slider health;

	[SerializeField]
	float current_health_value;

	[SerializeField]
	ViewState currentState;

	CardboardHead head;


	public bool use_obj;
	public bool drop_obj;

	string[] stateList;

	[SerializeField] 
	float[] animChangePoints;

	[SerializeField]
	CanvasGroup blackScreen;


	Material existingMaterial;


	public slot slotScript;

	//List --> to collect all the GameObjects placed in the slot
	public List<GameObject> GO_List;

	public GameObject placeHolder;

	[SerializeField]
	Animator jailUp;




	[SerializeField]
	Text killed;

//	[SerializeField]
//	GameObject fading_Image_containing_Canvas;


	[SerializeField]
	MeleeAIScript mas;

	GameObject currentInsObj;


	string BBB;

	[SerializeField]
	GameObject Dynamic_objects;


	[SerializeField]
	Autowalk autowalk;

	[SerializeField]
	GameObject Orb;


	bool reduceHealth;

	[SerializeField]
	Sprite[] loadingScreen;

	[SerializeField]
	Image LS;

	[SerializeField]
	bool loadingScreenDone;

	[SerializeField]
	Sprite End_of_Game;

	[SerializeField]
	CanvasGroup instructionSlide;

	[SerializeField]
	float gemMovSpeed=1;
	public static bool isInstructionFinished;

	float max_health_value;

	float health_value_in_percentage;


	[SerializeField]
	GameObject NFCContainer;

	void Awake()
	{
		isInstructionFinished=false;
	}
	void Start () 
	{

		C.SetActive (false);
		object_is_being_viewed = false;
		object_posn_move_counter = 0;
		use_obj = false;
		drop_obj = false;
		currentState = ViewState.FREE;
		GO_List = new List<GameObject>();
		if (instructionSlide != null)
		instructionSlide.alpha=0;
		fadeSystem.fadeCanvGrp (blackScreen, true);
//		killed.enabled = false;
		StartCoroutine(instructionRoutine());
		reduceHealth=true;

		GameManager.previousLevel = SceneManager.GetActiveScene().name;

		LS.enabled = false;
		loadingScreenDone = false;
		max_health_value = current_health_value;

	}
	

	void Update () 
	{
		if (C.activeSelf) 
		{
			C.transform.rotation = new Quaternion (0, C.transform.localEulerAngles.y, 0, 0);
			C.transform.LookAt (Camera.transform, C.transform.up);
		}

		if(QuizMaster.levelCleared)
		{
			showPath();
		}
	}


	void FixedUpdate()
	{
		if(reduceHealth && currentState == ViewState.FREE && isInstructionFinished && Health!=null && health !=null)
		{
			current_health_value -= Time.fixedDeltaTime;

			oblixHealth.fillAmount = current_health_value / max_health_value;
			oblixHealth_burnt.fillAmount = 1-oblixHealth.fillAmount;
			health.value = (current_health_value/max_health_value) * 100;


			//health.value = current_health_value;

			if (health.value <= 80) 
			{
				Health.color = Color.Lerp (Health.color, new Color32(176,232,75,225), 2 * Time.fixedDeltaTime);
			}

			if (health.value <= 50) 
			{
				Health.color = Color.Lerp (Health.color, Color.yellow, 2 * Time.fixedDeltaTime);
			}

			if (health.value <= 20) 
			{
				Health.color = Color.Lerp (Health.color, Color.red, 2 * Time.fixedDeltaTime);

			}

			if(health.value <= 0)
			{
				reduceHealth=false;
				jailUp.SetBool ("isOpen", true);
			}

		}
		if (currentState == ViewState.IMENU) {
			print ("HUD OFF");
			if(NFCContainer!=null)
			NFCContainer.SetActive (false);
		}

		if(currentState != ViewState.FREE && autowalk.isWalking)
		{

			Drop_Object ();
		}


	}


	public void showPath()
	{
		QuizMaster.levelCleared = false;
		Orb.SetActive(true);
	}


	public void Bring_Objects_Closer(GameObject Go)
	{
			
		
			if (currentState == ViewState.FREE && Go != null && Go.layer != LayerMask.NameToLayer ("Ignore Raycast") && Go.tag == "collectableObjects" ) 
			{

				initposn = Go.transform.position;
				Go.transform.position = placeHolder.transform.position;
				Go.transform.LookAt (Camera.transform);
				Go.transform.GetComponent<Rigidbody> ().isKinematic = true;
				Go.AddComponent<ObjRot> ();
				currentInsObj = Go;
				showMenu (currentInsObj);

			if(autowalk.isWalking)
				autowalk.isWalking = false;
		
			} 

	



			

	}

	void showMenu(GameObject Go)
	{
		
		//print (initposn);
		C.SetActive (true);
		C.transform.position = new Vector3 (Go.transform.position.x, Go.transform.position.y + 1f, Go.transform.position.z);
		C.transform.LookAt (Camera.transform, C.transform.up);
		C.transform.rotation = new Quaternion (0, C.transform.localEulerAngles.y, 0, 0);

		Go.transform.GetComponent<Rigidbody> ().isKinematic = true;
		threeD_Object = Go;
		currentState=ViewState.IMENU;
	}


	public void Use_Object()
	{
		Destroy (threeD_Object.GetComponent<ObjRot> ());

			StartCoroutine (moveObjectToSlot ());

	}
	IEnumerator moveObjectToSlot()
	{

		float startTime = Time.time;
		float journeyLength = Vector3.Distance(this.transform.position,Slot.transform.position);
		TrailRenderer trail = threeD_Object.GetComponent<TrailRenderer> ();
		trail.enabled = true;
		while ((threeD_Object.transform.position - Slot.transform.position).magnitude >= 0.2f) {
			float distCovered = (Time.time - startTime) * gemMovSpeed;
			float fracJourney = distCovered / journeyLength;
			threeD_Object.transform.position = Vector3.Lerp (threeD_Object.transform.position, Slot.transform.position,fracJourney);
			yield return new WaitForEndOfFrame();
		}
		trail.enabled = false;
		use_obj = true;

		C.SetActive (false);

		if (threeD_Object.transform.position == Slot.transform.position) 
		{
			threeD_Object.tag = "reachedSlot";
			GO_List.Add (threeD_Object);
		}

		currentState = ViewState.FREE;

		if (currentState==ViewState.FREE) 
		{
			use_obj = false;
		}
		slotScript.sendToSlot (threeD_Object);
	}


	public void Drop_Object()
	{
		drop_obj = true;
		threeD_Object.transform.GetComponent<Rigidbody> ().isKinematic = false;
		threeD_Object.transform.GetComponent<Rigidbody> ().useGravity = true;
		if(threeD_Object.GetComponent<ObjRot>() != null)
		{
			Destroy(threeD_Object.GetComponent<ObjRot>());
		}
		C.SetActive (false);

		currentState = ViewState.FREE;

		if (currentState==ViewState.FREE) 
		{
			drop_obj = false;

		}
	}



	void OnCollisionEnter(Collision collision)
	{
		print (collision.collider.name);
		print (collision.gameObject.name);
	}
		

	void OnTriggerEnter(Collider col)
	{
		



	

		if (col.name == "MissionAccomplished") 
		{
			print ("Here");
		
			if(SceneManager.GetActiveScene ().name=="Level1")
			{
				if(fadeSystem.isFaded)
				{	
					LS.enabled = true;
					StartCoroutine("animateLoaginScreen");
					loadingScreenDone = true;
				}	

				if(loadingScreenDone)
				{

					MySceneManager.loadLevelAsync("Level2",progressBar,blackScreen);
				}

			}

			if(SceneManager.GetActiveScene ().name=="Level2")
			{

				if(fadeSystem.isFaded)
				{	
					LS.enabled = true;
					StartCoroutine("animateLoaginScreen");
					loadingScreenDone = true;
				}	

				if(loadingScreenDone)
				{
			
					MySceneManager.loadLevelAsync("Level3",progressBar,blackScreen);
				}
			}


			if(SceneManager.GetActiveScene ().name == "Level3")
			{
				StartCoroutine (quitAppGracious ());
			}

			//SceneManager.LoadScene (2);
		}
		//print (other.name);
		if (col.name == "mummy" && mas.curState==AIState.ISBITING) 
		{

			killed.enabled = true;
			gameOver();
			GameManager.previousLevel = SceneManager.GetActiveScene ().name;
		}

	}




	void gameOver()
	{
		MySceneManager.loadLevelAsync("GameOver",progressBar,blackScreen);
	}



	IEnumerator animateLoaginScreen()
	{
		while(this.enabled)
		{
			for(int i=0; i<4; i++)
			{
				LS.sprite = loadingScreen[i];
				yield return new WaitForSeconds(0.2f);
			}

		}

	}
	IEnumerator instructionRoutine()
	{
		if (instructionSlide != null) {
			isInstructionFinished = false;
			fadeSystem.fadeCanvGrp (instructionSlide, false);
			while (!Cardboard.SDK.Triggered)
				yield return null;
			while (!fadeSystem.isFaded)
				yield return null;
			fadeSystem.fadeCanvGrp (instructionSlide, true);
	
			while (!fadeSystem.isFaded)
				yield return null;
			fadeSystem.fadeCanvGrp (blackScreen, true);
			isInstructionFinished = true;
		}
	}
	public void moveToMainLevel()
	{
		MySceneManager.loadLevelAsync ("Level1", progressBar, blackScreen);
	}

	IEnumerator quitAppGracious()
	{
		
		fadeSystem.fadeCanvGrp (blackScreen, false);
		while (!fadeSystem.isFaded) {
			print ("Screen is not fading");
			yield return new WaitForEndOfFrame ();
		}
		SceneManager.UnloadScene (SceneManager.GetActiveScene ().buildIndex);
		StopAllCoroutines ();
		Application.Quit ();
	}

}
