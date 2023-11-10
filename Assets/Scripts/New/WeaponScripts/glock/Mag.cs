using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mag : MonoBehaviour
{
    public int ammunitionAmount;

    private Collider myColl;

    [HideInInspector] public bool inMagWell;

    [HideInInspector] public bool canShoot;

    private XRGrabInteractable myXRGrab;

    

    // Start is called before the first frame update
    void Start()
    {
        myColl = gameObject.GetComponent<Collider>();
        myXRGrab = gameObject.GetComponent<XRGrabInteractable>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
