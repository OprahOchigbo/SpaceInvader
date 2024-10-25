using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private IEnumerator ThrowDessert;
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
            //StartCoroutine(ThrowDessert());

            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            
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
 
     
        }

    }
    public void FinishThrow()
    {
        Throwing = false;
        Moving = true;
        Animator.SetBool("Throwing", false);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile") || collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            GameManager.Instance.OnPlayerKilled(this);
        }
    }

}
