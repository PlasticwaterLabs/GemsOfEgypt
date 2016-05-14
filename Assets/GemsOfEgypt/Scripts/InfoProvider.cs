using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoProvider : MonoBehaviour {
	const string leftVentricle="Ventricle is one of two large chambers that collect and expel blood received from an atrium towards the peripheral beds within the body and lungs.Ventricles have thicker walls than atria and generate higher blood pressures. The left ventricle has thicker walls than the right because it needs to pump blood to most of the body while the right ventricle fills only the lungs.(Systemic Circulation)";
	const string rightVentricle="Ventricle is one of two large chambers that collect and expel blood received from an atrium towards the peripheral beds within the body and lungs.Ventricles have thicker walls than atria and generate higher blood pressures.The right ventricle has thinner walls compared to left since it has to pump blood only to the lungs.(Pulmonary Circulation)";
	const string rightAtrium = "The atrium (plural: atria) is one of the two blood collection chambers of the heart.The atrium is a chamber in which blood enters the heart, as opposed to the ventricle, where it is pushed out of the organ. The right atrium receives and holds deoxygenated blood from the superior vena cava, inferior vena cava.";
	const string leftAtrium="The atrium is one of the two blood collection chambers of the heart.The atrium is a chamber in which blood enters the heart, as opposed to the ventricle, where it is pushed out of the organ.The left atrium receives the oxygenated blood from the left and right pulmonary veins.";
	const string aorta="The aorta is the main artery in the human body, originating from the left ventricle of the heart and extending down to the abdomen, where it splits into two smaller arteries (the common iliac arteries). The aorta distributes oxygenated blood to all parts of the body through the systemic circulation.";
	const string pulmonaryArtery="The pulmonary artery carries deoxygenated blood from the heart to the lungs. It is one of the only arteries (other than the umbilical arteries in the fetus) that carries deoxygenated blood.";
	const string pulmonaryVien="The pulmonary veins are large blood vessels that receive oxygenated blood from the lungs and drain into the left atrium of the heart. There are four pulmonary veins, two from each lung. The pulmonary veins are among the few veins that carry oxygenated blood.";
	const string superiorVenacava="The superior vena cava (SVC) is the superior of the two venae cavae, the great venous trunks that return deoxygenated blood from the systemic circulation to the right atrium of the heart. It is a large-diameter (24 mm), yet short, vein that receives venous return from the upper half of the body, above the diaphragm.";
	const string inferiorVenacava="The inferior vena cava (or IVC) (Latin: vena, vein, cavus, hollow), is the inferior of the two venae cavae, the large veins that carry deoxygenated blood from the body into the right atrium of the heart. The inferior vena cava carries blood from the lower half of the body whilst the superior vena cava carries blood from the upper half of the body.";
	[SerializeField]
	static Text partName;
	[SerializeField]
	static Text desc;
	static GameObject partNameObj;
	static GameObject descObj;



	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public static string returnDesc(string partName)
	{
		
		switch (partName) {
		case "LeftVentricle":
			return leftVentricle;
		
		case "RightVentricle":
			return rightVentricle;
	
		case "RightAtrium":
			return rightAtrium;
		
		case "LeftAtrium":
			return leftAtrium;
	
		case "PulmonaryArtery":
			return pulmonaryArtery;

		case "PulmonaryVein0":
			return pulmonaryVien;
		case "PulmonaryVein1":
			return pulmonaryVien;
		case "PulmonaryVein2":
			return pulmonaryVien;
		case "PulmonaryVein3":
			return pulmonaryVien;

		case "SupiriorVenacava":
			return superiorVenacava;

		case "InferiorVenacava":
			return  inferiorVenacava;

		case "Aorta":
			return aorta;

		default:
			return "This text should not be shown";
	
		}
	}
	public static int getHeartPartIndex(string partName)
	{
		switch (partName) {
		case "LeftVentricle":
			return 0;

		case "RightVentricle":
			return 1;

		case "RightAtrium":
			return 2;

		case "LeftAtrium":
			return 3;

		case "PulmonaryArtery":
			return 4;

		case "PulmonaryVein0":
			return 5;

		case "PulmonaryVein1":
			return 6;
	
		case "PulmonaryVein2":
			return 7;

		case "PulmonaryVein3":
			return 8;

		case "SupiriorVenacava":
			return 9;

		case "InferiorVenacava":
			return  10;

		case "Aorta":
			return 11;

		default:
			Debug.LogError ( partName+"Untagged part is bieng pointed at");
			return -1;

		}
	}


//	public static void  setSomething(string nameStr)
//	{
//		
//
//		{
//			partName = GameObject.FindGameObjectWithTag ("partName").GetComponent<Text> ();
//			desc = GameObject.FindGameObjectWithTag ("desc").GetComponent<Text> ();
//			if (partName!=null && desc!=null) {
//				
//			
//				desc.text = returnDesc (nameStr);
//				partName.text = nameStr;
//			}
//		}
//
//	}
//	public static void  clearAll()
//	{
//
//
//		{
//			partName = GameObject.FindGameObjectWithTag ("partName").GetComponent<Text> ();
//			desc = GameObject.FindGameObjectWithTag ("desc").GetComponent<Text> ();
//			if (partName!=null && desc!=null) {
//
//
//				desc.text = "";
//				partName.text = "";
//			}
//		}
//
//	}








	public static void  setSomething(string nameStr)
	{

	
	}
	public static void  clearAll()
	{


		{
			partNameObj = GameObject.FindGameObjectWithTag ("partName");
			descObj = GameObject.FindGameObjectWithTag ("desc");
			if (partNameObj!=null && descObj!=null) {


				descObj.GetComponent<Text> ().text = "";
				partNameObj.GetComponent<Text> ().text = "";
			}
		}

	}
}
