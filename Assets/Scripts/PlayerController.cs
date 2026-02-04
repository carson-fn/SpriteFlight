using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject boosterFlame;

    public float thrustForce = 1.0f;
    public float maxSpeed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            // convert mouse position to world coordinates
            // different from screen coordinates
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

            // calculate direction vector from player to mouse 
            // .normalized makes it a unit vector (length of 1)
            Vector2 direction = (mousePos - transform.position).normalized;

            // point the up direction of the player towards the mouse
            transform.up = direction;

            // apply a force in the direction of the mouse
            rb.AddForce(direction * thrustForce);

            // limit the max speed
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }

        // set the booster flame
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                boosterFlame.SetActive(true);
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                boosterFlame.SetActive(false);
            }
    }

    // Unity calls this method when this object has a collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy this game object
        Destroy(gameObject);
    }
}
