using UnityEngine;
using UnityEngine.InputSystem; // heel belangrijk

public class PointerClickDetector : MonoBehaviour
{
    void Update()
    {
        // Check of er een pointer device is (muis of touch)
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            Vector2 pos = Pointer.current.position.ReadValue();
            Debug.Log("Klik / Touch op: " + pos);
        }

            if (Pointer.current == null)
            {
            Debug.Log("Pointer.current is NULL → Unity ziet geen pointer device");                                  
            }
        
    }
}
