using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRefferenceForGrabObject : MonoBehaviour
{
	public enum Controller {Left,Right}
	public Controller orientation;

	private KeepGrabTransform myGrabTransformScript;

	private string CName;
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name);
		if (other.gameObject.tag == "GrabObject")
		{
			myGrabTransformScript = other.gameObject.GetComponent<KeepGrabTransform>();
			myGrabTransformScript.isHovering = true;
			myGrabTransformScript.ControllerName = CName;
			if (CName == "Right")
			{
				myGrabTransformScript.RightController = gameObject;
			} else if (CName == "Left")
			{
				myGrabTransformScript.LeftController = gameObject;
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "GrabObject")
		{
			myGrabTransformScript.ControllerName = null;
			myGrabTransformScript.isHovering = false;
			myGrabTransformScript = null;
		}
	}
	 void Start()
	{
		CName = orientation.ToString();
	}
}
