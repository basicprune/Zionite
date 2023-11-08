using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BarrelFix : MonoBehaviour
{
	public bool canShoot;

	public AmmoScript myAmmoScript;

	private XRGrabInteractable myGrab;
	private Rigidbody rb;

	public bool isDone;

	public float timer;
	public float delay = 1f;

	public float slideDelay;


	public bool run;


	public bool canSlide;
	 void Start()
	{
		myGrab = gameObject.GetComponent<XRGrabInteractable>();
		rb = gameObject.GetComponent<Rigidbody>();
		//rb.isKinematic = true;
		
	}

	public void isGrabbed()
	{
	
	}
	
	void Update()
	{
	
		timer += Time.deltaTime;
		if (timer > delay && run == true)
		{
			rb.isKinematic = true;
			canShoot = true;
			canSlide = false;
		}
		if (myGrab.isSelected == true)
		{
			Debug.Log("ISGRAB");
			canSlide = false;
			canShoot = false;
			timer = 0f;
			run = true;
		}
		
		if (timer < delay && run == true)
		{
			Debug.Log("yes");
			rb.isKinematic = false;
		}
		if (timer > slideDelay && run == true)
		{
			canSlide = true;
		} 
	
	
		
		
		
		
		// on grab start delay after delay then kin can be true
		
		//if (timer <= delay)
		//{
		//	isDone = false;
		//}

		
	}
}
