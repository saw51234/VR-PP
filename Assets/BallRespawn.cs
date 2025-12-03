using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    private Vector3 startPos;
    private Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            ResetBall();
        }
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}