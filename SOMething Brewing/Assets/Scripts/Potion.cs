using UnityEngine;

public class Potion : MonoBehaviour
{
    public string potionName;
    public Color potionColor;

    public virtual void ApplyEffect(GameObject Enemy)
    {
        Debug.Log($"{potionName} applied to {Enemy}");
    }
    // roep dit aan op enemy voor damage
}
