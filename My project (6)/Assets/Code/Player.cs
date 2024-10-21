using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public Laser laserPrefab;
    public Animator Animator;
    Laser laser;
    float speed = 5f;
    float horizontalMove = 0f; 

    // Update is called once per frame
    void Update()
    {
        Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        Vector3 position = transform.position;

        position.x += horizontalMove * Time.deltaTime;

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        else if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
        }

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        transform.position = position;
        

        if (Input.GetKeyDown(KeyCode.Space) && laser == null)
        {
            laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile") || collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            GameManager.Instance.OnPlayerKilled(this);
        }
    }

}
