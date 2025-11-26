//using UnityEngine;
//using UnityEngine.InputSystem;

//public class ScreenTapLogger : MonoBehaviour
//{
//    void Update()
//    {
//        if (Touchscreen.current == null) return;

//        var touch = Touchscreen.current.primaryTouch;

//        if (touch.press.isPressed)
//        {
//            Vector2 position = touch.position.ReadValue();
//            Debug.Log("Touch at: " + position);
//        }
//    }
//}
