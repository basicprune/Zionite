using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChildGrabInteractableToPlayer : MonoBehaviour
{
    [Tooltip("you need to place your object in a parent so you can set the parent back to it's original parent")] public GameObject grabObjectOriginalParent;
    [Tooltip("if your object is childed")] public GameObject grabObjectParent;
    public GameObject grabObject;
    public XRGrabInteractable grabInteractable;
    public GameObject PlayerRig;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = grabObject.GetComponent<XRGrabInteractable>();   
    }

    // Update is called once per frame
    void Update()
    {
     if (grabInteractable.isSelected == true)
		{
            if (grabObjectParent != null)
			{
                grabObjectParent.transform.SetParent(PlayerRig.transform);
			} else if (grabObjectParent == null && grabObject != null)
			{
                grabObject.transform.SetParent(PlayerRig.transform);
			}
		} else if(grabInteractable.isSelected != true)
		{
            if (grabObjectParent != null)
            {
                grabObjectParent.transform.SetParent(grabObjectOriginalParent.transform);
            }
            else if (grabObjectParent == null && grabObject != null)
            {
                grabObject.transform.SetParent(grabObjectOriginalParent.transform);
            }
        }  
    }
}
