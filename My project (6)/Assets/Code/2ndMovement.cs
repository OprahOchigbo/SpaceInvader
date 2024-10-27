using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    AudioManager audioManager;
    public Animator Animator;
    public Laser laserPrefab;
    Laser laser;
    readonly float speed = 5f;
    float horizontalMove = 0f;
    bool Throwing = false;
    bool Moving = true;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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

            //audioManager.PlaySFX(audioManager.PlayerThrow);

            Invoke(nameof(FinishThrow), Animator.GetCurrentAnimatorStateInfo(0).length - 0.1f);
            Debug.Log("Animation Length: " + Animator.GetCurrentAnimatorStateInfo(0).length);


        }
            
        
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
<<<<<<< HEAD:My project (6)/Assets/Code/Player.cs

        }

        if (Input.GetKeyDown(KeyCode.Space) && laser == null)
        {
            audioManager.PlaySFX(audioManager.PlayerThrow);
            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
=======
>>>>>>> 36fc68feb9a2d1278d9fd1e529992497fcfabdc4:My project (6)/Assets/Code/2ndMovement.cs

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
            GameManager.Instance.OnPlayerKilled(this);
        }
    }
}
