using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertSpawner : MonoBehaviour
{

    private int rand;

    public Sprite[] Sprite_Pic;


    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // Detect collision with invader
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Invader"))
        {
            Change(); 
        }
    }

    void Change()
    {
        rand = Random.Range(0, Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
    }
}
