using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Magazine : MonoBehaviour
{

    public int numOfBullet = 16;
	public AmmoScript myAmmoScript;
	public BarrelFix myBarrelFixScript;

	private XRGrabInteractable myGrab;

	private Collider myCollider;

	public XRSocketInteractTag myScoket;

	public bool isEmpty;
	public bool isLoaded;

	public bool isSlided;

	public Rigidbody magRB;

	void Start()
	{
		myGrab = gameObject.GetComponent<XRGrabInteractable>();
		myCollider = gameObject.GetComponent<Collider>();
		magRB = gameObject.GetComponent<Rigidbody>();
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "MagWell")
		{
			if (isEmpty == false)
			{
				isEmpty = true;
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		
			if (other.gameObject.tag == "MagWell")
			{
				if (isEmpty == true)
				{
					isEmpty = false;
					isLoaded = false;
				}
			}
		
	}

	void Update()
	{
		
		if (isEmpty == true)
		{
			if (myBarrelFixScript.canShoot == true && isLoaded == false)
			{
				Debug.Log("Loaded?");
				myAmmoScript.ammo = numOfBullet; 
				isLoaded = true;	
			}

		}
	}
}
