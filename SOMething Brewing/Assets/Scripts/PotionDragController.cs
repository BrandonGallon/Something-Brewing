using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PotionDragController : MonoBehaviour
{
    private TouchAction controls;
    private Camera cam;
    private DraggablePotion currentPotion;

    // Plane at table depth (adjust in Inspector)
    public Transform dragPlane;

    private Plane plane;

    private void Awake()
    {
        controls = new TouchAction();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();

        // Create a plane from the dragPlane transform
        plane = new Plane(dragPlane.forward, dragPlane.position);
    }

    private void Update()
    {
        bool touching = controls.Touch.PrimaryTouchContact.ReadValue<float>() > 0.5f;
        Vector2 screenPos = controls.Touch.PrimaryTouchPosition.ReadValue<Vector2>();

        if (touching)
        {
            if (currentPotion == null)
            {
                TryPickUp(screenPos);
            }
            else
            {
                DragPotion(screenPos);
            }
        }
        else
        {
            DropPotion();
        }
    }

    void TryPickUp(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            currentPotion = hit.collider.GetComponent<DraggablePotion>();
            if (currentPotion != null)
                currentPotion.StartDragging();
        }
    }

    void DragPotion(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 worldPoint = ray.GetPoint(distance);
            currentPotion.transform.position = worldPoint;
        }
    }

    void DropPotion()
    {
        if (currentPotion != null)
        {
            currentPotion.StopDragging();
            currentPotion = null;
        }
    }
}
