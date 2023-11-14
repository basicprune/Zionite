using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class KeepGrabTransform : MonoBehaviour
{

	public ShowHand ShowHandScript;

	public InputAction RightGrip;
	// turn this into a inputactionrefference probs
	public InputAction LeftGrip;


	[HideInInspector]  public GameObject RightController;

	[HideInInspector]  public GameObject LeftController;


	public GameObject myObjectParent; // to reparent the gameobject 

	public GameObject ObjectWithHandParent; // if use hand pose then make that the parent so it sticks to the gameobject

	public GameObject grabPosition;// if using a grabPos it will use the grabPos as a parent // couldn't figure out how to do it another way haha

	[HideInInspector]  public bool isHovering;
	[HideInInspector]  public bool isSelected;

    [HideInInspector] public string ControllerName; // used by ControllerRefferenceForGrabObject.cs for more modularity 
	
	
	void Start()
	{
		LeftGrip.Enable();
		RightGrip.Enable();
	}
	public void GrabLeft()
	{
		if (LeftGrip.inProgress == true && isHovering == true)
		{
			if (ShowHandScript != null)
			{
				ShowHandScript.LeftHand.active = true;
			}
			
			Debug.Log("InProgress");
			//myObject.transform.position = RightController.transform.position;
			//myObject.transform.SetParent(RightController.transform);
			if (grabPosition != null)
			{
				//grabPosition.transform.position = LeftController.transform.position;
				grabPosition.transform.position = LeftController.transform.position;
				grabPosition.transform.rotation = LeftController.transform.rotation;
				grabPosition.transform.SetParent(LeftController.transform);
				
				
			} else if (ObjectWithHandParent != null)
			{
				ObjectWithHandParent.transform.position = LeftController.transform.position;
				ObjectWithHandParent.transform.rotation = LeftController.transform.rotation;
				ObjectWithHandParent.transform.SetParent(LeftController.transform);
			} else if (ObjectWithHandParent == null && grabPosition == null)
			{
				gameObject.transform.position = LeftController.transform.position;
				gameObject.transform.rotation = LeftController.transform.rotation;
				gameObject.transform.SetParent(LeftController.transform);
			}

			isSelected = true;
		}
		else if (LeftGrip.inProgress != true)
		{
			if (grabPosition != null)
			{
				grabPosition.transform.SetParent(myObjectParent.transform);
			}
			else if (ObjectWithHandParent != null)
			{
				ObjectWithHandParent.transform.SetParent(myObjectParent.transform);
			}
			else if (ObjectWithHandParent == null && grabPosition == null)
			{
				gameObject.transform.SetParent(myObjectParent.transform);
			}

			if (ShowHandScript != null)
			{
				ShowHandScript.LeftHand.active = false;
			}
		
			isSelected = false;
			Debug.Log("NotPressed");
			//myObject.transform.SetParent(myObjectParent.transform);
			
		}

		
	}
	public void GrabRight()
	{
		if (RightGrip.inProgress == true && isHovering == true)
		{
			if (ShowHandScript != null)
			{
				ShowHandScript.RightHand.active = true;
			}
			
			Debug.Log("InProgress");
			//myObject.transform.position = RightController.transform.position;
			//myObject.transform.SetParent(RightController.transform);
			if (grabPosition != null)
			{
				//grabPosition.transform.position = LeftController.transform.position;
				grabPosition.transform.position = RightController.transform.position;
				grabPosition.transform.rotation = RightController.transform.rotation;
				grabPosition.transform.SetParent(RightController.transform);


			}
			else if (ObjectWithHandParent != null)
			{
				ObjectWithHandParent.transform.position = RightController.transform.position;
				ObjectWithHandParent.transform.rotation = RightController.transform.rotation;
				ObjectWithHandParent.transform.SetParent(RightController.transform);
			} else if (ObjectWithHandParent == null && grabPosition == null)
			{
				gameObject.transform.position = RightController.transform.position;
				gameObject.transform.rotation = RightController.transform.rotation;
				gameObject.transform.SetParent(RightController.transform);
			}

			isSelected = true;
		}
		else if (RightGrip.inProgress != true)
		{
			if (grabPosition != null)
			{
				grabPosition.transform.SetParent(myObjectParent.transform);
			}
			else if (ObjectWithHandParent != null)
			{
				ObjectWithHandParent.transform.SetParent(myObjectParent.transform);
			}else if (ObjectWithHandParent == null && grabPosition == null)
			{
				gameObject.transform.SetParent(myObjectParent.transform);
			}
			if (ShowHandScript != null)
			{
				ShowHandScript.RightHand.active = false;
			}
			
			isSelected = false;
			Debug.Log("NotPressed");
			//myObject.transform.SetParent(myObjectParent.transform);

		}


	}
	// Update is called once per frame
	void Update()
	{	
		Debug.Log(ControllerName);
		if (ControllerName == "Right")
		{
			GrabRight();
		}else if(ControllerName == "Left")
		{
			GrabLeft();
		}
	}
}
