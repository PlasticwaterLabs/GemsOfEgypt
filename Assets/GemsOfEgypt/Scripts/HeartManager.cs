using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour 
{
	public GameObject MC;
	public float time_counter;
	Vector3 MC_new_posn;
	public float move_speed;

	Quaternion rot;

	public static bool remove_init_screen;

	public GameObject Heart;

	public GameObject Menu_btn;
	public GameObject Transperency_btn;
	public GameObject Quit_btn;
	public GameObject Opaque_btn;
	public GameObject bf_btn;
	public GameObject PartSys;
	public GameObject disp;
	//public GameObject PartName;


	public Material HNM;
	public Material TM;
	public Material OPNM;

	public GameObject Entire_Heart;
	public GameObject Vein_Set1;
	public GameObject Vein_Set2;
	public GameObject Vein_Set3;
	public GameObject Vein_Set4;


	public Slider tranp_btn_Slider;
	public Slider bloodflow_btn_Slider;
	public Slider opaque_btn_Slider;
	//public Slider quit_btn_Slider;


	public  bool is_transparent;
	public  bool blood_flowing;


	public PointShowData PSD;
	public float toggle_timer;
	public float blood_flow_toggle_timer;
	public bool f_TT;
	public bool f_BT;


	void Start () 
	{
		InputTracking.Recenter ();

		time_counter = 0;

		MC_new_posn = new Vector3 (580, 91, 0);

		remove_init_screen = false;

		Heart.SetActive (false);
		Transperency_btn.SetActive (false);
		Quit_btn.SetActive (false);
		Opaque_btn.SetActive (false);
		bf_btn.SetActive (false);
		PartSys.SetActive (false);
		//Menu_btn.SetActive (false);

		disp.SetActive (true);
		//PartName.SetActive (true);

		is_transparent = false;
		blood_flowing = false;

		toggle_timer = 1.49f;
		blood_flow_toggle_timer = 0;
	}
	


	void Update () 
	{
		time_counter += Time.time;

		if(time_counter >= 3)
		{
			MC.transform.position = Vector3.Lerp(MC.transform.position, MC_new_posn, move_speed * Time.deltaTime);
		}

		if(MC.transform.position.x >= 575 )
		{
			
			if(MC.activeSelf)
			{
				MC.SetActive (false);
			}
			if(!remove_init_screen)
				rem_screen ();
			
			return;
		}
			

	}

	public void rem_screen()
	{
		
		remove_init_screen = true;

		Heart.SetActive (true);

		//rot = Heart.transform.rotation;
		Transperency_btn.SetActive (true);
		Quit_btn.SetActive (true);
		bf_btn.SetActive (false);
		Opaque_btn.SetActive (false);
		disp.SetActive (true);
		//PartName.SetActive (true);

		Heart.transform.rotation = Quaternion.identity;
		Heart.transform.position = new Vector3 (2.2f, 1.8f, 8.4f);



		Entire_Heart.GetComponent<Renderer> ().material = HNM;
		Vein_Set1.GetComponent<Renderer> ().material = OPNM;
		Vein_Set2.GetComponent<Renderer> ().material = OPNM;
		Vein_Set3.GetComponent<Renderer> ().material = OPNM;
		Vein_Set4.GetComponent<Renderer> ().material = OPNM;	


		if (MC.activeSelf) 
		{
			MC.SetActive (false);
		}

		PartSys.SetActive (false);
		is_transparent = true;
		InfoProvider.clearAll ();
			

	}




	public void makeHeartTransperent()
	{
//		if (!is_transparent) 
//		{
//			is_transparent = true;
//		} 
//		else if (is_transparent) 
//		{
//			is_transparent = false;
//		}

		is_transparent = !is_transparent;

		Opaque_btn.SetActive (true);
		bf_btn.SetActive (true);


		if (!is_transparent) 
		{
			
			Entire_Heart.GetComponent<Renderer> ().material = TM;
			Vein_Set1.GetComponent<Renderer> ().material = TM;
			Vein_Set2.GetComponent<Renderer> ().material = TM;
			Vein_Set3.GetComponent<Renderer> ().material = TM;
			Vein_Set4.GetComponent<Renderer> ().material = TM;
			disp.SetActive (false);
		//	PartName.SetActive (false);

			PartSys.SetActive (false);

		}

		if(is_transparent)
		{
			
			Entire_Heart.GetComponent<Renderer> ().material = HNM;
			Vein_Set1.GetComponent<Renderer> ().material = OPNM;
			Vein_Set2.GetComponent<Renderer> ().material = OPNM;
			Vein_Set3.GetComponent<Renderer> ().material = OPNM;
			Vein_Set4.GetComponent<Renderer> ().material = OPNM;

			Opaque_btn.SetActive (false);
			bf_btn.SetActive (false);

			disp.SetActive (true);
		//	PartName.SetActive (true);



		}

	}


	public void makeHeartOpaque()
	{

			
			Opaque_btn.SetActive (false);
			bf_btn.SetActive (false);
			
			
			Quit_btn.SetActive (true);
			Transperency_btn.SetActive (true);

			remove_init_screen = false;


			Entire_Heart.GetComponent<Renderer> ().material = HNM;
			Vein_Set1.GetComponent<Renderer> ().material = OPNM;
			Vein_Set2.GetComponent<Renderer> ().material = OPNM;
			Vein_Set3.GetComponent<Renderer> ().material = OPNM;
			Vein_Set4.GetComponent<Renderer> ().material = OPNM;			

	}


	public void showBloodFlow()
	{
		blood_flowing = !blood_flowing;
		if (blood_flowing) 
		{
			PartSys.SetActive (true);
		} 
		else 
		{
			PartSys.SetActive (false);
		}

	}


	public void quitHeartApp()
	{
		Application.Quit ();
	}
}
