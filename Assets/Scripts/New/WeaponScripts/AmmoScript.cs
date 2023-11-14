using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class AmmoScript : MonoBehaviour
{
    public GameObject magParent;

    public Shoot shootScript;
    public XRSocketInteractor mySocket;

    public ActionBasedController ActionBasedController;

    private XRGrabInteractable myGrab;

    public Text ammoText;
    public int ammo;

    //public InputActionReference RTrigger;
    public InputAction RTriggers;

    public InputActionProperty myinputActionPropertyTest;

    public AudioSource Source;

    public AudioClip slide;
    public AudioClip magEnter;
    public AudioClip shootAudio;

    public Magazine magazine;

    public BarrelFix myBarrelFixScript;

    public bool isInserted;

    public bool myIsSlided;
    public bool minusWhenPullSlide;

    private float timer;
    public float shootDelay;

    public ParticleSystem gunFlash;

    private GameObject mag;
    public XRGrabInteractable grabInteractable;
 
   
    void Start()
    {
        myGrab = gameObject.GetComponent<XRGrabInteractable>();
        mySocket.onSelectEntered.AddListener(insertMag);
        mySocket.onSelectExited.AddListener(removeMag);
    }

   

    public void insertMag(XRBaseInteractable interactable) // make mag child of gun so it won't move 
	{
        mag = interactable.GetComponent<GameObject>();
        minusWhenPullSlide = false;
        myBarrelFixScript.canSlide = false;
        myBarrelFixScript.canShoot = false;
        myBarrelFixScript.run = false;
        magazine = interactable.GetComponent<Magazine>();
        //magazine.magRB.isKinematic = true;
        isInserted = true;
        Source.PlayOneShot(magEnter);
        Debug.Log("L");
        //mag.transform.SetParent(gameObject.transform);
	}
    public void removeMag(XRBaseInteractable interactable)
    {
       
        magazine.myCollider.enabled = true;
        minusWhenPullSlide = true;
        magazine.numOfBullet = ammo - 1;
        if (ammo > 0)
        {
            ammo = 1;
        }
        isInserted = false;
        myBarrelFixScript.canShoot = false;
        myBarrelFixScript.run = false;
        //mag.transform.SetParent(magParent.transform);

        Source.PlayOneShot(magEnter);
    }
    public void slideAudio()
    {
        Source.PlayOneShot(slide);
    }


    public void Shoot()
	{
       
        if (magazine.numOfBullet > 0)
		{
            if (magazine != null)
			{
                magazine.numOfBullet--;
			}
            shootScript.raycastShoot();
            ammo--;
            Source.PlayOneShot(shootAudio);
            gunFlash.Play();
        }
         
	}

 

    // Update is called once per frame
    void Update()
    {
     
     if (myGrab.isSelected == true && magazine != null)
		{
            magazine.myCollider.enabled = true;
        } else
		{
            magazine.myCollider.enabled = false;
        }
        if (myBarrelFixScript.canSlide == true && myIsSlided == false)
        {
            slideAudio();
            myIsSlided = true;
            if (ammo >= 1 && magazine == null)
			{
                ammo--;
			}
            else if (ammo > 1 && magazine.isLoaded == true)
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
        ActionBasedController.selectAction = myinputActionPropertyTest;
        
       
    }
}
