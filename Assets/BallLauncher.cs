using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform firePoint;
    public float power = 6.0f;
    public float interval = 3.0f;

    [Header("회전 설정")]
    public float topSpinPower = 50f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        if (ballPrefab == null) return;

        GameObject newBall = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);

        Rigidbody rb = newBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 dir = transform.forward + (transform.up * 0.15f);
            rb.velocity = dir * power;

            rb.maxAngularVelocity = 100f;

            rb.AddTorque(transform.right * topSpinPower, ForceMode.VelocityChange);
        }

        Destroy(newBall, 5.0f);
    }
}