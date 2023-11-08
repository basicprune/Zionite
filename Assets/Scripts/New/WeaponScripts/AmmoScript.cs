using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class AmmoScript : MonoBehaviour
{
    public Shoot shootScript;
    public XRSocketInteractor mySocket;

    private XRGrabInteractable myGrab;

    public Text ammoText;
    public int ammo;

    public InputActionReference RTrigger;
    public InputAction RTriggers;

    public AudioSource Source;

    public AudioClip slide;
    public AudioClip magEnter;
    public AudioClip shootAudio;

    public Magazine magazine;

    public BarrelFix myBarrelFixScript;

    private bool isInserted;

    public bool myIsSlided;
    public bool minusWhenPullSlide;

    private float timer;
    public float shootDelay;

    public void insertMag(XRBaseInteractable interactable)
	{
        minusWhenPullSlide = false;
        myBarrelFixScript.canSlide = false;
        myBarrelFixScript.canShoot = false;
        myBarrelFixScript.run = false;
        magazine = interactable.GetComponent<Magazine>();
        //magazine.magRB.isKinematic = true;
        isInserted = true;
        Source.PlayOneShot(magEnter);
        Debug.Log("L");
	}
    public void removeMag(XRBaseInteractable interactable)
    {
        minusWhenPullSlide = true;
        magazine.numOfBullet = ammo - 1;
        if (ammo > 0)
        {
            ammo = 1;
        }
        isInserted = false;
        myBarrelFixScript.canShoot = false;
        myBarrelFixScript.run = false;

        magazine = null;
        Source.PlayOneShot(magEnter);
    }
    public void slideAudio()
    {
        Source.PlayOneShot(slide);
    }

    void Start()
    {
        myGrab = gameObject.GetComponent<XRGrabInteractable>();
        

        mySocket.onSelectEntered.AddListener(insertMag);
        mySocket.onSelectExited.AddListener(removeMag);
        
    }
    public void Shoot()
	{
       
        if (ammo > 0)
		{
            shootScript.raycastShoot();
            ammo--;
            Source.PlayOneShot(shootAudio);
        }
         
	}
        
    

    // Update is called once per frame
    void Update()
    {
     
     
        if (myBarrelFixScript.canSlide == true && myIsSlided == false)
        {
            slideAudio();
            myIsSlided = true;
            if (ammo >= 1 && magazine == null)
			{
                ammo--;
			}
            if (ammo > 1 && magazine.isLoaded == true)
			{
                magazine.numOfBullet--;
			}
        }
        if (myBarrelFixScript.canSlide == false && myIsSlided == true)
		{
            myIsSlided = false;
        }
        
        ammoText.text = "Ammo: " + ammo.ToString();
        RTriggers.Enable();
        timer += Time.deltaTime;
        if (myGrab.isSelected == true)
		{
            if (RTriggers.WasPressedThisFrame() == true && timer > shootDelay)
            {
                Shoot();
                timer = 0f;
                Debug.Log("PRSSED");
            }
        }
        
    }
}
