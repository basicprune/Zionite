using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Belt : MonoBehaviour
{
    private GameObject Holster;
    private Collider HolsterCollider;
    public MeshRenderer HolsterMesh;

    public InputAction showBelt;
    // Start is called before the first frame update
    void Start()
    {
        showBelt.Enable();
        Holster = gameObject;
        HolsterCollider = gameObject.GetComponent<Collider>();
        //HolsterCollider.isTrigger = false;
        HolsterMesh = gameObject.GetComponent<MeshRenderer>();
        HolsterMesh.enabled = false;
        HolsterCollider.enabled = false;
    }
    public void HolsterShow()
	{
        if (showBelt.inProgress == true && HolsterMesh.enabled == false)
        {
            Debug.Log("PRESSED");
            HolsterMesh.enabled = true;
            HolsterCollider.enabled = true;

        }
    }
    public void HolsterHide()
	{
        if (showBelt.inProgress != true && HolsterMesh.enabled == true)
        {
           HolsterMesh.enabled = false;
            HolsterCollider.enabled = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        HolsterShow();
        HolsterHide();
    }
}
