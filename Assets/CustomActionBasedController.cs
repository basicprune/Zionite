using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class CustomActionBasedController : ActionBasedController
{
    [SerializeField]
    InputActionProperty m_SelectAction = new InputActionProperty(new InputAction("Select", type: InputActionType.Button));

    public InputActionProperty selectAction
    {
        get => m_SelectAction;
        set => m_SelectAction = value; // Assign directly without SetInputActionProperty
    }

    protected override void UpdateController()
    {
        base.UpdateController();

        if (selectAction.action.ReadValue<float>() > 0.5f)
        {
            // Check if the trigger is pressed

            // Custom logic to determine if the XRGrabInteractable should be selected
            if (CanPickUpWithTrigger())
            {
                // Attempt to grab the interactable
                TryGrabInteractable();
            }
        }
    }

    private bool CanPickUpWithTrigger()
    {
        // Add your conditions here
        return GetInteractableObject() != null && GetInteractableObject().CompareTag("PickupWithTrigger");
    }

    private void TryGrabInteractable()
    {
        XRBaseInteractable interactable = GetInteractableObject();
        if (interactable != null)
        {
            // Implement your logic to grab the interactable here
            // For example, you might call interactable.Select() to initiate grabbing

            // Example: interactable.Select();
        }
    }

    private XRBaseInteractable GetInteractableObject()
    {
        // Implement logic to retrieve the currently selected interactable
        // For example, you might use the selection interactable of the controller

        // Example: return selectedInteractable;
        return null; // Placeholder, replace with actual logic
    }
}
