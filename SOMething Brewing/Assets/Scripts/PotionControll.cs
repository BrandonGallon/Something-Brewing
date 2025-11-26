using UnityEngine;
using UnityEngine.InputSystem;

public class PotionTapTeleport : MonoBehaviour
{
    private Camera cam;
    private InputAction positionAction;
    private InputAction pressAction;

    [Header("Waar moeten potions heen teleporteren?")]
    public Transform teleportTarget;   // Sleep hier je doel-locatie heen in de Inspector

    void Awake()
    {
        cam = Camera.main;

        var playerInput = FindFirstObjectByType<PlayerInput>();
        positionAction = playerInput.actions["TouchPosition"];
        pressAction = playerInput.actions["TouchPress"];
    }

    void OnEnable()
    {
        pressAction.performed += OnPress;
    }

    void OnDisable()
    {
        pressAction.performed -= OnPress;
    }

    private void OnPress(InputAction.CallbackContext ctx)
    {
        Vector2 screenPos = positionAction.ReadValue<Vector2>();

        Ray ray = cam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Element"))
            {
                // Teleporteer naar exacte positie
                hit.collider.transform.position = teleportTarget.position;
            }
        }
    }
}
