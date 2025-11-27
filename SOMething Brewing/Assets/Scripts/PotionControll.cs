using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElementTapTeleport : MonoBehaviour
{
    private Camera cam;
    private InputAction positionAction;
    private InputAction pressAction;

    [Header("Element Slots")]
    public Transform[] slots = new Transform[4];

    private List<Transform> currentPotions = new List<Transform>();

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

        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;

        if (!hit.collider.CompareTag("Element"))
            return;

        Transform potion = hit.collider.transform;

        // Als potion al in de lijst zit → niets doen
        if (currentPotions.Contains(potion))
            return;

        // Als we al 4 potions hebben → stoppen
        if (currentPotions.Count >= 4)
            return;

        // Voeg de nieuwe potion toe
        currentPotions.Add(potion);

        // Update posities van ALLE potions
        UpdatePotionSlots();
    }

    private void UpdatePotionSlots()
    {
        for (int i = 0; i < currentPotions.Count; i++)
        {
            Transform potion = currentPotions[i];
            potion.position = slots[i].position; // Teleport naar dat slot
        }
    }
}
