using UnityEngine;

public class MagnusEffect : MonoBehaviour
{
    [Tooltip("회전 영향력 (0.01 ~ 0.1 추천)")]
    public float magnusPower = 0.02f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.5f) return;

        Vector3 magnusForce = Vector3.Cross(rb.velocity, rb.angularVelocity);

        rb.AddForce(magnusForce * magnusPower * rb.mass);
    }
}