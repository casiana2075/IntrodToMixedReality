using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dodge : MonoBehaviour
{
    private Animator animator;
    public Transform cactusObject;
    public float triggerDistance = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null && cactusObject != null)
        {
            float distance = Vector3.Distance(transform.position, cactusObject.position);
            
            if (distance <= triggerDistance)
            {
                animator.SetBool("dodge", true);
            }
            else
            {
                animator.SetBool("dodge", false);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.SetBool("dodge", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("dodge", false);
            }
        }
    }
}
