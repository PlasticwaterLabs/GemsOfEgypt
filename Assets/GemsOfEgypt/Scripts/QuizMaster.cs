using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class QuizMaster : MonoBehaviour 
{
	[SerializeField]
	string[] questions;
	[SerializeField]
	string[] answers;
	[SerializeField]
	List<string> askingQeue;
	[SerializeField]
	List<string> answerQeue;
	[SerializeField]
	int curQuestion;
	[SerializeField]
	Text chatBubbleQue;

	[SerializeField]
	 List<string> slots;
	[SerializeField]
	Animator doorAnim;
	[SerializeField]
	GameObject currentSlotObj;

	public static bool wrong_answer;

	public static bool levelCleared;

	public void startQuizAfterDelay()
	{
		print ("Starting quiz");
		StartCoroutine (quizRoutine ());

	}
	void Awake()
	{
		M.isInstructionFinished=false;
	}
	// Use this for initialization
	void Start () 
	{
		M.isInstructionFinished=false;
		slots = new List<string> ();
		askingQeue = new List<string> ();
		answerQeue = new List<string> ();
		foreach (string q in questions)
			askingQeue.Add (q);
		foreach (string q in answers)
			answerQeue.Add (q);
		print(curQuestion+" "+askingQeue.Count);
		//slotScript.placedEvent.AddListener (enlistObject);
		levelCleared = false;
		//doorAnim.SetBool ("doorOpen", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator quizRoutine()
	{
		M.isInstructionFinished=false;
		while(!M.isInstructionFinished)
		{

			yield return null;
		}
		askRandomQuestion ();
	}

	void askRandomQuestion()
	{
		//print ("Called");
		curQuestion = Random.Range (0, askingQeue.Count);
	
		print(SceneManager.GetActiveScene().name+" "+askingQeue.Count);

		chatBubbleQue.text = askingQeue [curQuestion];

	}

	bool checkAnswer(string answer)
	{
		print (answers [curQuestion] + " " + answer);
		if (answerQeue [curQuestion] == answer)
			return true;
		else
			return false;
	}

	public void enlistObject(GameObject gameObj)
	{
		slots.Add (gameObj.name);
		currentSlotObj = gameObj;

		updateQuestion ();
	}

	void setLevelFinishedMessage()
	{
		levelCleared = true;
		chatBubbleQue.text="You have done well, Go through the door to finish the level.";

	}

	public void updateQuestion()
	{
		if (checkAnswer (slots [slots.Count - 1])) {
			correctAnswer ();
			askingQeue.RemoveAt(curQuestion);
			answerQeue.RemoveAt(curQuestion);
			if (askingQeue.Count > 0) 
			{
				askRandomQuestion ();
			} else 
			{
				print ("Opening door");
				setLevelFinishedMessage();
				doorAnim.SetBool ("doorOpen", true);

			}
		}
		else
			wrongAnswer ();
	}
	void wrongAnswer()
	{
		
		print ("Wrong answer");
		Rigidbody selectedRgbd = currentSlotObj.GetComponent<Rigidbody> ();
		selectedRgbd.isKinematic = false;
		selectedRgbd.AddExplosionForce (800, this.transform.position + (new Vector3 (Random.Range (-2, 2), Random.Range (-2, 2), Random.Range (-2, 2))),3);
		selectedRgbd.tag = "collectableObjects";
		currentSlotObj.GetComponent<gemScript> ().resetKinamatism ();
	}
	void correctAnswer()
	{
		StartCoroutine ("DisableAfterDelay", 3);
		print ("The path is open for my followers");
	}
	IEnumerator DisableAfterDelay(int sec)
	{
		yield return new WaitForSeconds (sec);
		currentSlotObj.SetActive (false);
		currentSlotObj = null;
	}

}
