using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class GrabTest : MonoBehaviour
{
    public InputAction leftTrigger;
    public XRGrabInteractable xrGrab;
    // Start is called before the first frame update
    void Start()
    {
        leftTrigger.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
