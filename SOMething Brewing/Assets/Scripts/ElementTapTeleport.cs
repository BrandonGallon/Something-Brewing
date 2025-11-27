using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PotionTapTeleport : MonoBehaviour
{
    private Camera cam;
    private InputAction positionAction;
    private InputAction pressAction;

    [Header("Element Slots")]
    public Transform[] slots = new Transform[4];

    // Backing field
    private List<Transform> currentPotions = new List<Transform>();

    // Property die van buitenaf toegankelijk is
    public List<GameObject> CurrentPotions
    {
        get
        {
            List<GameObject> potions = new List<GameObject>();
            foreach (var t in currentPotions)
                potions.Add(t.gameObject);
            return potions;
        }
    }

    // Original positions of all elements (for returning to shelves)
    private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();

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

        // Store original position if not already stored
        if (!originalPositions.ContainsKey(potion))
            originalPositions[potion] = potion.position;

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

    // Moves all current potions back to their original shelf positions
    public void ResetSlotsToShelves()
    {
        foreach (Transform potion in currentPotions)
        {
            if (potion != null && originalPositions.ContainsKey(potion))
            {
                potion.position = originalPositions[potion];
            }
        }
        ClearSlots();
    }

    public void ClearSlots()
    {
        currentPotions.Clear();
    }
}
