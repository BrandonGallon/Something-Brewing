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

        // Get elements
        Element[] elements = new Element[teleporter.CurrentPotions.Count];
        for (int i = 0; i < teleporter.CurrentPotions.Count; i++)
        {
            ElementHolder holder = teleporter.CurrentPotions[i].GetComponent<ElementHolder>();
            if (holder != null)
                elements[i] = holder.element;
        }

        Potion result = mixer.Mix(elements);

        // No result → DO NOT craft, return items
        if (result == null)
        {
            Debug.Log("Geen match gevonden!");
            teleporter.ResetPotions(); // ❗ Return elements
            return;
        }

        // Missing prefab safety
        if (result.prefab == null)
        {
            Debug.LogError("Prefab missing on potion: " + result.potionName);
            teleporter.ResetPotions(); // ❗ Return elements
            return;
        }

        // Craft the potion prefab
        Instantiate(result.prefab, spawnPoint.position, Quaternion.identity);

        Debug.Log("Potion gemaakt: " + result.potionName);

        teleporter.ResetPotions(); // ❗ Return elements after successful craft
    }
}
