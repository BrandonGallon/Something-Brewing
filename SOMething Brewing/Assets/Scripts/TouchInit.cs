using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchInit : MonoBehaviour
{
    void Awake()
    {

        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();

        void OnDestroy()
        {

            EnhancedTouchSupport.Disable();
            TouchSimulation.Disable();
        }
    }
}
