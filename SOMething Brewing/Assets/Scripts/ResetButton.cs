using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public PotionTapTeleport teleporter;

    public void OnReset()
    {
        teleporter.ResetPotions();
        Debug.Log("Elements put back on shelves.");
    }
}
