using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ObjectForHolster : MonoBehaviour
{
    public GameObject ObjForHolsterParent;

    private Belt BeltScript;
    private GameObject forHolsterObject;
    private Collider forHolsterCollider;
    private XRGrabInteractable GrabI;
    private GameObject HolsterObject;
    private bool inHolster;
    private bool ShowHolster;

    private bool ReleaseGrab;
    private bool ReleasedInHolster;


  

    private MeshRenderer objectMeshRenderer;
    // Start is called before the first frame update


    public InputAction Grip;

    // fix gameobject




    
    private Transform myTransform;
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        myTransform = gameObject.transform;
        Grip.Enable();
        forHolsterCollider = gameObject.GetComponent<Collider>();
        GrabI = gameObject.GetComponent<XRGrabInteractable>();
        ShowHolster = false;
        ReleaseGrab = false;
        inHolster = false;
        ReleaseGrab = false;
        ReleasedInHolster = false;


        objectMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        ObjForHolsterParent = gameObject.transform.parent.gameObject;
    }

	public void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "HolsterTag")
        {
            HolsterObject = other.gameObject;
           
            inHolster = true;
            if (GrabI.isSelected == true)
            {
                Debug.Log("isSelected");
                BeltScript = other.gameObject.GetComponent<Belt>();
            }
        }	
	}
	public void OnTriggerExit(Collider other)
	{
        
        BeltScript = null;
        HolsterObject = null;
        inHolster = false;
        
	}
   
	public void GrabRelease()
	{
            if (inHolster == true)
		    {
                if (Grip.inProgress == true)
                {
                    if (gameObject.tag == "HolsterItemTag")
                    {
                        ReleaseGrab = true;
                        ReleasedInHolster = true;
                    }
                }

               // else
               // {
                //    ReleaseGrab = false;
               //     ReleasedInHolster = false;

               // }
            }
           
            
           

    }
    public void showObject()
	{
        if (BeltScript.HolsterMesh.enabled == true)
		{
            objectMeshRenderer.enabled = true;
            forHolsterCollider.enabled = true;
            ShowHolster = true;
        }
	}
    public void hideObject()
    {
        if (BeltScript.HolsterMesh.enabled == false)
        {
            objectMeshRenderer.enabled = false;
            forHolsterCollider.enabled = false;
            ShowHolster = false;
        }
    }
    public void InteractStateCheck()
	{
        if (Grip.inProgress != true)
        {
            if (ShowHolster == true)
            {
               
                if (inHolster == true)
                {
                    
                    if (gameObject.tag == "HolsterItemTag")
                    {                    
                        gameObject.transform.position = HolsterObject.gameObject.transform.position;
                    }

                }
            }
            Debug.Log("UP");
           
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        


        GrabRelease();
        
        
        if (ReleasedInHolster == true && inHolster == true) //HolsterObject != null &&
        {
            gameObject.transform.SetParent(HolsterObject.transform);
            hideObject();
            showObject();
        } 
        else if (BeltScript == null)
        {
            ReleasedInHolster = false;
            inHolster = false;
            gameObject.transform.SetParent(ObjForHolsterParent.transform);
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        if (BeltScript == true)
		{
            Debug.Log("S");
		}

        

        
      
    }
}
