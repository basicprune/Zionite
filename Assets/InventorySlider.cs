using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventorySlider : MonoBehaviour
{
    public List<GameObject> beltObjects = new List<GameObject>();
    public List<GameObject> beltObjects2 = new List<GameObject>();
    public List<GameObject> beltObjects3 = new List<GameObject>();
    public GameObject Right;
    public GameObject Left;

    public InputAction TestButton;
    public InputAction TestButton2;
    
    public int invWindow;
    public int numberOfBeltLists;
    // Start is called before the first frame update
    void Start()
    {
        TestButton.Enable();
        TestButton2.Enable();
    }
    public void scrollLeft() // if left then add 1
	{
        if (invWindow == 1)
		{
            invWindow = 2;
            foreach (GameObject myBelt1 in beltObjects)
			{
                if (myBelt1.active == true)
				{
                    myBelt1.active = false;
                }
			}
            foreach (GameObject myBelt2 in beltObjects2)
			{
                if (myBelt2.active == false)
				{
                    myBelt2.active = true;
                }
			}
                
		}
        else if (invWindow == 2)
		{
            invWindow = 3;
            foreach (GameObject myBelt2 in beltObjects2)
            {
                if (myBelt2.active == true)
                {
                    myBelt2.active = false;
                }
            }
            foreach (GameObject myBelt3 in beltObjects3)
            {
                if (myBelt3.active == false)
                {
                    myBelt3.active = true;
                }
            }
        }
    }
    public void scrollRight() // if i scroll right then minus 1 if // the window on the righter most side is the higher in and the left is the lower
	{
        if (invWindow == 3)
        {
            invWindow = 2;
            foreach (GameObject myBelt3 in beltObjects3)
            {
                if (myBelt3.active == true)
                {
                    myBelt3.active = false;
                }
            }
            foreach (GameObject myBelt2 in beltObjects2)
            {
                if (myBelt2.active == false)
                {
                    myBelt2.active = true;
                }
            } 
        }
        else if (invWindow == 2)
        {
            invWindow = 1;
            foreach (GameObject myBelt2 in beltObjects2)
            {
                if (myBelt2.active == true)
                {
                    myBelt2.active = false;
                }
            }
            foreach (GameObject myBelt1 in beltObjects)
			{
                if (myBelt1.active == false)
                {
                    myBelt1.active = true;
                }
            }       
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TestButton.WasPressedThisFrame() == true)
	    {
            scrollRight();
	    }  
        if (TestButton2.WasPressedThisFrame() == true)
		{
            scrollLeft();
		}
    }
}
