using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isUp = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        GetComponent<Button>().onClick.AddListener(OnImageClick);
    }

    void OnImageClick()
    {
        animator.enabled = true;
        isUp = !isUp;
        animator.SetBool("IsUp", isUp);
        Debug.Log("IsUp changed to: " + isUp);
    }
}
