using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class ObjectGrabHandler : XRGrabInteractable
{
    public InputAction trigger;
	// Override the method to customize the interaction
	private void Start()
	{
        trigger.Enable();
	}
	
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
    }

    void Update()
    {
        if (isSelected)
        {
            // Check if the trigger button is pressed
            if (trigger.triggered)
            {
                Debug.Log("Object grabbed with trigger.");
            }
            else
            {
                Debug.Log("Object grabbed with grip.");
            }
        }
    }
}
