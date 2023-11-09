using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class hands : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject hand;
    public enum handModelType {Left, Right}
    public handModelType handType;
    public XRGrabInteractable gunGrabbed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	 void Update()
	{
        ShowandHideHand();

    }
	public void ShowandHideHand()
	{
        if (gunGrabbed.isSelected == true && hand.active == false)
		{
            hand.active = true;
		} else if(gunGrabbed.isSelected != true)
		{
            hand.active = false;
		}
	}
    
}
