using UnityEngine;

public class CraftButton : MonoBehaviour
{
    public Mixer mixer;
    public PotionTapTeleport teleporter;
    public Transform spawnPoint;

    public void OnCraft()
    {
        if (teleporter.CurrentPotions.Count == 0)
        {
            Debug.Log("No potions to craft.");
            return;
        }

        // Gather elements from the current potions
        Element[] elements = new Element[teleporter.CurrentPotions.Count];
        for (int i = 0; i < teleporter.CurrentPotions.Count; i++)
        {
            ElementHolder holder = teleporter.CurrentPotions[i].GetComponent<ElementHolder>();
            if (holder != null)
                elements[i] = holder.element;
            else
                Debug.LogWarning("Potion in slot " + i + " has no ElementHolder.");
        }

        // Mix elements to get the resulting potion
        Potion result = mixer.Mix(elements);

        if (result == null)
        {
            Debug.Log("Geen match gevonden! Returning elements to shelves.");
            teleporter.ResetSlotsToShelves(); // put elements back
            return;
        }

        if (result.prefab == null)
        {
            Debug.LogError("Prefab is missing on potion: " + result.potionName);
            return;
        }

        // Instantiate the crafted potion
        Instantiate(result.prefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Potion gemaakt: " + result.potionName);

        // Return all used elements back to shelves
        teleporter.ResetSlotsToShelves();

        // Clear the slots list (optional, depends on your system)
        teleporter.ClearSlots();
    }
}
