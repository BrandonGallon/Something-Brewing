//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.Controls;

//public class PotionDragController : MonoBehaviour
//{
//    private TouchControls controls;
//    private Camera cam;
//    private Element currentElement;

//    // Plane at table depth (adjust in Inspector)
//    public Transform dragPlane;

//    private Plane plane;

//    private void Awake()
//    {
//        controls = new TouchControls();
//        cam = Camera.main;
//    }

//    private void OnEnable()
//    {
//        controls.Enable();

//        // Create a plane from the dragPlane transform
//        plane = new Plane(dragPlane.forward, dragPlane.position);
//    }

//    private void Update()
//    {
//        bool touching = controls.Touch.PrimaryTouchContact.ReadValue<float>() > 0.5f;
//        Vector2 screenPos = controls.Touch.PrimaryTouchPosition.ReadValue<Vector2>();

//        if (touching)
//        {
//            if (currentElement == null)
//            {
//                TryPickUp(screenPos);
//            }
//            else
//            {
//                DragPotion(screenPos);
//            }
//        }
//        else
//        {
//            DropPotion();
//        }
//    }

//    void TryPickUp(Vector2 screenPos)
//    {
//        Ray ray = cam.ScreenPointToRay(screenPos);
//        Debug.Log("Trying to pick up at screenPos: " + screenPos);

//        if (Physics.Raycast(ray, out RaycastHit hit))
//        {
//            Debug.Log("Hit: " + hit.collider.name);

//            currentElement = hit.collider.GetComponent<Element>();

//            if (currentElement != null)
//            {
//                Debug.Log("Picked up potion");
//                currentElement.StartDragging();
//            }
//            else
//            {
//                Debug.Log("Object hit, but NOT draggable.");
//            }
//        }
//        else
//        {
//            Debug.Log("No collider hit.");
//        }
//    }


//    void DragPotion(Vector2 screenPos)
//    {
//        Ray ray = cam.ScreenPointToRay(screenPos);

//        if (plane.Raycast(ray, out float distance))
//        {
//            Vector3 worldPoint = ray.GetPoint(distance);
//            currentElement.transform.position = worldPoint;
//        }
//    }

//    void DropPotion()
//    {
//        if (currentElement != null)
//        {
//            currentElement.StopDragging();
//            currentElement = null;
//        }
//    }
//}
