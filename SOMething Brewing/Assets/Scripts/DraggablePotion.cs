using UnityEngine;

public class DraggablePotion : MonoBehaviour
{
    public void StartDragging()
    {
       
        Debug.Log("Picked up potion: " + name);
    }

    public void StopDragging()
    {
        Debug.Log("Dropped potion: " + name);
    }
}
