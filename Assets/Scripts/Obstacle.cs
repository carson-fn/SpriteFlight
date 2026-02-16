using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject collisionEffectPrefab;

    public float minSize = 0.5f;
    public float maxSize = 2.5f;

    public float minSpeed = 50f;
    public float maxSpeed = 200f;

    public float maxSpinSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);

        rb = GetComponent<Rigidbody2D>();
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);

        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomTorque);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point;
        GameObject bounceEffect = Instantiate(collisionEffectPrefab, contactPoint, Quaternion.identity);

        // destroy the effect after 1 second
        Destroy(bounceEffect, 0.2f);
    }
}
