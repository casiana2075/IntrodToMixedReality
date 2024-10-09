using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public Transform robotObject;
    public float triggerDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null && robotObject != null)
        {
            float distance = Vector3.Distance(transform.position, robotObject.position);

            if (distance <= triggerDistance)
            {
                animator.SetBool("attack", true);
            }
            else
            {
                animator.SetBool("attack", false);
            }

            if (Input.GetKeyDown(KeyCode.H)) 
            {
                animator.SetBool("attack", true);
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                animator.SetBool("attack", false);
            }
        }           
    }
}
