using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomizeFall : MonoBehaviour
{
    public float driftMagnitude = 2.0f; // Adjust this value to increase/decrease drift

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Random initial force to the left or right
        float sideForce = Random.Range(-driftMagnitude, driftMagnitude);
        rb.AddForce(new Vector2(sideForce, 0), ForceMode2D.Impulse);

        // Optional: Randomize the gravity scale if you want different falls speeds
        rb.gravityScale *= Random.Range(0.8f, 1.2f);
    }

    // Optional: Adjust the object's velocity over time for more dynamic behavior
    void Update()
    {
        Vector2 velocity = rb.velocity;
        float sideForce = Random.Range(-driftMagnitude, driftMagnitude) * Time.deltaTime;
        rb.velocity = new Vector2(velocity.x + sideForce, velocity.y);
    }
}
