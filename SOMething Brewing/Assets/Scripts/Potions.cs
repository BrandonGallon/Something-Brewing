using UnityEngine;

public class Potions : MonoBehaviour
{
    public string potionName;
    public Color potionColor;
    public float DamageDuration;

    public virtual void ApplyEffect(GameObject Enemy)
    {
        Debug.Log($"{potionName} applied to {Enemy}");
    }
    // roep dit aan op enemy voor damage
}
