using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{

    private IEnumerator ThrowDessert;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public Laser laserPrefab;
    public Animator Animator;
    Laser laser;
    Rigidbody2D rbody;
    float speed = 5f;
    float horizontalMove = 0f;
    bool Throwing = false;
    bool Moving = true;

    private void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetButtonDown("Jump") && !Throwing)
        {
            Animator.Play("Throw");

            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Moving = false;
            Throwing = true;

            Invoke("FinishThrow", Animator.GetCurrentAnimatorStateInfo(0).length-0.1f);
            
        }

        /*IEnumerator ThrowDessert()
        {

            Throwing = true;
            Animator.SetBool("Throw", true);
            Moving = false;
        }*/

        if (Moving)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
            Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            Vector3 position = transform.position;
            position.x += horizontalMove * Time.deltaTime;
            transform.position = position;



            if (horizontalMove < 0)        //move left
            {
                transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            }
            else if (horizontalMove > 0)    //move right
            {
                transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
            }

            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

            position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);
 
     

        if (Input.GetKeyDown(KeyCode.Space) && laser == null)
        {
            audioManager.PlaySFX(audioManager.PlayerThrow);
            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        }

    }
    public void FinishThrow()
    {
        Throwing = false;
        Moving = true;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile") || collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            audioManager.PlaySFX(audioManager.PlayerDeath);
            GameManager.Instance.OnPlayerKilled(this);
        }
    }

}
