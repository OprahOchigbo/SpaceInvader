using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Invader : MonoBehaviour
{
    AudioManager audioManager;

    public Sprite[] animationSprites = new Sprite[2];
    public float animationTime;
    public GameObject Particle;

    SpriteRenderer spRend;
    int animationFrame;
    // Start is called before the first frame update

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spRend = GetComponent<SpriteRenderer>();
        spRend.sprite = animationSprites[0];
    }

    void Start()
    {
        //Anropar AnimateSprite med ett visst tidsintervall
        InvokeRepeating( nameof(AnimateSprite) , animationTime, animationTime);
    }

    //pandlar mellan olika sprited f�r att skapa en animation
    private void AnimateSprite()
    {
        animationFrame++;
        if(animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }
        spRend.sprite = animationSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            audioManager.PlaySFX(audioManager.Death);
            GameManager.Instance.OnInvaderKilled(this);

            Instantiate(Particle, collision.transform.position, Quaternion.identity);

            Destroy(Particle);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Boundary")) //n�tt nedre kanten
        {
            GameManager.Instance.OnBoundaryReached();
        }
    }

}
