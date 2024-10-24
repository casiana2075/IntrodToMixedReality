using UnityEngine;

public class HandAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the G key is being pressed
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Play the animation forward
            animator.SetBool("grab", true);
            animator.SetFloat("Speed", 1.0f); // Normal playback speed
        }

        // Check if the G key is released
        if (Input.GetKeyUp(KeyCode.G))
        {
            // Play the animation in reverse
            animator.SetBool("grab", true);
            animator.SetFloat("Speed", -1.0f); // Reverse playback speed
        }
    }
}
