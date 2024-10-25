using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites = new Sprite[2];
    public float animationTime;

    public Color hitColor = Color.red;  // Color to apply when the invader gets hit
    public float hitColorDuration = 0.5f; // Duration to show the hit color

    private SpriteRenderer spRend;
    private int animationFrame;
    private bool isHit = false;
    private Color originalColor; // Store the original color

    private void Awake()
    {
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = animationSprites[0];

        // Store the original color
        originalColor = spRend.color;
    }

    void Start()
    {
        // Start the sprite animation
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    // Animates between different sprites for the invader
    private void AnimateSprite()
    {
        animationFrame++;
        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }
        spRend.sprite = animationSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If hit by a laser
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            if (isHit) return; // If already hit, do nothing

            // Destroy the laser immediately
            Destroy(collision.gameObject);

            // Mark the invader as hit
            isHit = true;

            // Notify GameManager
            GameManager.Instance.OnInvaderKilled(this);

            // Change the color to indicate hit
            StartCoroutine(FlashColor(hitColor, hitColorDuration));

            // Start the destruction process with a delay
            StartCoroutine(DestroyAfterDelay(0.5f));
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Boundary"))
        {
            GameManager.Instance.OnBoundaryReached();
        }
    }

    // Coroutine to flash color when hit
    private IEnumerator FlashColor(Color newColor, float duration)
    {
        spRend.color = newColor; // Change to the hit color
        yield return new WaitForSeconds(duration);
        spRend.color = originalColor; // Revert to the original color
    }

    // Coroutine to destroy the invader after a delay
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);  // Destroy the invader after the delay
    }
}
