using UnityEngine;

[CreateAssetMenu(menuName = "Alchemy/Potion")]
public class Potion : ScriptableObject
{
    public string potionName;
    public GameObject prefab; // Must be assigned in the asset

    // Optional: Helper to check if the prefab is assigned
    public bool HasPrefab()
    {
        return prefab != null;
    }
}
