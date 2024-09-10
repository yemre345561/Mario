using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float inputX;
    [SerializeField] float speed;
    [SerializeField] private Hook grapplingHook;
    Animator animator;
    public Rigidbody2D rb;
    public float jumpAmount = 8;
    public ScoreCounter scoreCounter;
    public ParticleSystem jumpParticleSystem; // Reference to the jump particle system

    [SerializeField] private float baseSwingingForce = 5f;
    [SerializeField] private float maxSwingingVelocity = 5f;
    [SerializeField] private float offsetBelowAnchor = 1f;

    private float currentSwingingSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentSwingingSpeed = baseSwingingForce;
    }

    void Update()
    {
        if (!IsGrappling())
        {
            inputX = Input.GetAxis("Horizontal");
            animator.SetFloat("speed", Mathf.Abs(inputX));
            rb.velocity = new Vector2(inputX * Time.deltaTime * speed, rb.velocity.y);

            // Check if the player is grounded before allowing a jump
            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);

                // Play the jump particle system
                if (jumpParticleSystem != null)
                {
                    jumpParticleSystem.Play();
                }
            }
        }
        else
        {
            inputX = Input.GetAxis("Horizontal");
            currentSwingingSpeed = Mathf.Clamp(currentSwingingSpeed + inputX, -maxSwingingVelocity, maxSwingingVelocity);

            Vector2 offset = new Vector2(0f, -offsetBelowAnchor);
            Vector2 forceDirection = (grapplingHook.AnchorPosition - (Vector2)transform.position).normalized;
            Vector2 force = forceDirection * currentSwingingSpeed;

            force.x += inputX; // Additional force for horizontal movement

            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSwingingVelocity);
            rb.AddForceAtPosition(force, (Vector2)transform.position + offset);
        }

        if (Input.GetKeyDown(KeyCode.F) && grapplingHook != null)
        {
            grapplingHook.ToggleGrapplingHook();
            currentSwingingSpeed = baseSwingingForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            Debug.Log("Coin collected");
            Destroy(collider.gameObject);
            scoreCounter.ScoreUpdate();

            // Play the coin collection sound
            SpecialEffects.specialEffects.CoinSFX();
        }
    }

    private bool IsGrappling()
    {
        return grapplingHook != null && grapplingHook.IsGrappling;
    }

    // Check if the player is grounded using raycasting
    private bool IsGrounded()
    {
        float raycastDistance = 0.2f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance);
        return hit.collider != null;
    }
}












































