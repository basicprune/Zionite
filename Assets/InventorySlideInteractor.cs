using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventorySlideInteractor : MonoBehaviour
{
	public InputAction ScrollInput;
	public InventorySlider myInventorySliderScript;

	public bool Right;
	public bool Left;
	private void Start()
	{
		ScrollInput.Enable();
	}
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name);
		if (other.gameObject.tag == "InventoryScrollButtonRight")
		{
			Right = true;

		}
		else if (other.gameObject.tag == "InventoryScrollButtonLeft")
		{
			Left = true;

		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "InventoryScrollButtonRight")
		{
			Right = false;
		}
		else if (other.gameObject.tag == "InventoryScrollButtonLeft")
		{
			Left = false;

		}
	}

	// Update is called once per frame
	void Update()
	{
		if (ScrollInput.WasPressedThisFrame() == true && Right == true)
		{
			
			myInventorySliderScript.scrollRight();
		}
		else if (ScrollInput.WasPressedThisFrame() == true && Left == true)
		{
			Debug.Log("LeftSlide");
			myInventorySliderScript.scrollLeft();
		}
	}
}
