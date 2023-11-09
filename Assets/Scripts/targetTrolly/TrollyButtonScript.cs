using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrollyButtonScript : MonoBehaviour
{
	private TrollyButtonInteractor myTrollyButtonInteractor;

	public InputAction pressButton;
	public InputAction pressButtonL;
	private GameObject TrollyButton;
	public Animator TrollyAnimator;
	
	public int trollyStageInt = 1; // start is 1, 0.75 is 2, 0.50 is 3, 0.25 is 4, and 0 is 5 
	public string nameOfButton;
	private float trollyStageFloat;


	

	public TrollyStage myTrollyStageScript;


	public void OnTriggerEnter(Collider other)
	{
		//Debug.Log("HI");
		//Debug.Log(other.gameObject.tag);
		
		TrollyButton = other.gameObject;
		myTrollyButtonInteractor = other.gameObject.GetComponent<TrollyButtonInteractor>();
		myTrollyButtonInteractor.nameOfButtonOnInteractor = nameOfButton;
	}
	private void OnTriggerExit(Collider other)
	{
		myTrollyButtonInteractor.nameOfButtonOnInteractor = "";
		TrollyButton = null;
	}
	// Start is called before the first frame update
	void Start()
    {
		TrollyAnimator.enabled = true;
		TrollyAnimator.Play("BringToPlayer", 0, 1f);
		pressButton.Enable();   
		pressButtonL.Enable();   
    }
	public void TrollyEnd()
	{
		if (nameOfButton == myTrollyButtonInteractor.nameOfButtonOnInteractor)
		{
			if (pressButton.WasPerformedThisFrame() == true)
			{
				if (myTrollyStageScript.myStageInt == 5)
				{
					TrollyAnimator.Play("BringToPlayer", 0, 0f);
					myTrollyStageScript.myStageInt = 1;
				}
				else if (myTrollyStageScript.myStageInt == 4)
				{
					TrollyAnimator.Play("BringToPlayer", 0, 0.25f);
					myTrollyStageScript.myStageInt = 1;
				}
				else if (myTrollyStageScript.myStageInt == 3)
				{
					TrollyAnimator.Play("BringToPlayer", 0, 0.31f);
					myTrollyStageScript.myStageInt = 1;
				}
				else if (myTrollyStageScript.myStageInt == 2)
				{
					TrollyAnimator.Play("BringToPlayer", 0, 0.75f);
					myTrollyStageScript.myStageInt = 1;
				}


				//Debug.Log("PRESSED");
				
			}
		}
	}
	public void TrollyStart()
	{
		if (nameOfButton == myTrollyButtonInteractor.nameOfButtonOnInteractor)
		{
			if (pressButton.WasPerformedThisFrame() == true)
			{
				
				if (myTrollyStageScript.myStageInt == 1)
				{
					
					TrollyAnimator.Play("FullAnim", 0, 0f);
					myTrollyStageScript.myStageInt = 5;
				}
				else if (myTrollyStageScript.myStageInt == 2)
				{
					TrollyAnimator.Play("FullAnim", 0, 0.25f);
					myTrollyStageScript.myStageInt = 5;
				}
				else if (myTrollyStageScript.myStageInt == 3)
				{
					TrollyAnimator.Play("FullAnim", 0, 0.50f);
					myTrollyStageScript.myStageInt = 5;
				}
				else if (myTrollyStageScript.myStageInt == 4)
				{
					TrollyAnimator.Play("FullAnim", 0, 0.75f);
					myTrollyStageScript.myStageInt = 5;
				}
				

				
				
				
			}
		}
	}
	public void TrollyQuater()
	{
		if (nameOfButton == myTrollyButtonInteractor.nameOfButtonOnInteractor)
		{
			if (pressButton.WasPerformedThisFrame() == true)
			{

				if (myTrollyStageScript.myStageInt == 1)
				{
					TrollyAnimator.Play("5Meter", 0, 0f);
					myTrollyStageScript.myStageInt = 2;
				} else if (myTrollyStageScript.myStageInt == 5)
				{
					TrollyAnimator.Play("FromBack5M", 0, 0f);
					myTrollyStageScript.myStageInt = 4;
				}

					
			} 
		
		} 
	}
	public void TrollyHalf()
	{
		if (nameOfButton == myTrollyButtonInteractor.nameOfButtonOnInteractor)
		{
			if (pressButton.WasPerformedThisFrame() == true)
			{

				if (myTrollyStageScript.myStageInt == 1)
				{
					TrollyAnimator.Play("20Metre", 0, 0f);
					myTrollyStageScript.myStageInt = 3;
				}
				else if (myTrollyStageScript.myStageInt == 5)
				{
					TrollyAnimator.Play("FromBack20M", 0, 0f);
					myTrollyStageScript.myStageInt = 3;
				}else if (myTrollyStageScript.myStageInt == 2)
				{
					TrollyAnimator.Play("20Metre", 0, 0.30f);
					myTrollyStageScript.myStageInt = 4;
				}else if (myTrollyStageScript.myStageInt == 4)
				{
					TrollyAnimator.Play("FromBack20M", 0, 0.50f);
					myTrollyStageScript.myStageInt = 4;
				}


			}

		}
	}
    // Update is called once per frame
    void Update()
    {
		if (nameOfButton == "End" && pressButton.WasPerformedThisFrame() == true)
		{
			TrollyEnd();
		}
		if (nameOfButton == "Start" && pressButton.WasPerformedThisFrame() == true)
		{
			TrollyStart();
		}
		if (nameOfButton == "Quater" && pressButton.WasPerformedThisFrame() == true)
		{
			TrollyQuater();
		} 
		if (nameOfButton == "Half" && pressButton.WasPerformedThisFrame() == true)
		{
			TrollyHalf();
		}
		Debug.Log(myTrollyStageScript.myStageInt); // change so it check a string on the TrollyButtonInteractor.cs for the right or left controller and then only allow for right trigger if string == right :)
	}
}
