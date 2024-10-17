using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class BaseballController : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasBeenHit = false;
    private bool firstImpactWithGround = false;
    public Scoring score;

    private Vector3 initialPosition;

    public GameObject NotBadText;
    public GameObject GoodHitText;
    public GameObject WowText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // start as kinematic
        initialPosition = transform.position; // store the initial position
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision happened
        if (collision.gameObject.CompareTag("Bat") && !hasBeenHit)
        {
            rb.isKinematic = false; // non-kinematic
            hasBeenHit = true;
            StartCoroutine(RespawnBall());
        }
        if (collision.gameObject.CompareTag("Plane") && hasBeenHit && !firstImpactWithGround)
        {
            firstImpactWithGround = true;
            Vector3 collisionPoint = collision.contacts[0].point;
            /*UnityEngine.Debug.Log("Initial position: " + initialPosition);
            UnityEngine.Debug.Log("Collision point: " + collisionPoint);*/
            float distanceX = Mathf.Abs(initialPosition.x - collisionPoint.x);
            float distanceY = Mathf.Abs(initialPosition.z - collisionPoint.z);
            /*UnityEngine.Debug.Log("Distance on X-axis: " + distanceX);
            UnityEngine.Debug.Log("Distance on Y-axis: " + distanceY);*/

            // Display message based on the distance 
            if ((distanceX >= 1.0f && distanceX < 2.0f) || (distanceY >= 1.0f && distanceY < 2.0f))
            {
                StartCoroutine(DisplayMessage(GoodHitText));
                score.AddScore(50);
            }
            else if (distanceX < 1.0f && distanceY < 1.0f)
            {
                StartCoroutine(DisplayMessage(NotBadText));
                score.AddScore(10);
            }
            else
            {
                StartCoroutine(DisplayMessage(WowText));
                score.AddScore(100);
            }
        }
    }

    private IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(5f);
        rb.isKinematic = true; // start as kinematic
        hasBeenHit = false;
        firstImpactWithGround = false;
        transform.position = initialPosition; // reset the position to the initial position
    }

    private IEnumerator DisplayMessage(GameObject message)
    {
        message.SetActive(true);
        yield return new WaitForSeconds(3f);
        message.SetActive(false);
    }
}
