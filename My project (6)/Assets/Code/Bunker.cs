using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bunker : MonoBehaviour
{

    readonly AudioManager audioManager;

    public int nrOfHits = 0;
    public Sprite[] bunkers = new Sprite[3];
    SpriteRenderer spRend;
    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spRend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
<<<<<<< HEAD
        Debug.Log(nrOfHits);

        if (nrOfHits == 1)
        {
            spRend.sprite = bunkers[0];
        }

        if (nrOfHits == 2)
        {
            spRend.sprite = bunkers[1];
        }

        if (nrOfHits == 4)
        {
            spRend.sprite = bunkers[2];
            GetComponent<BoxCollider2D>().enabled = false;
        }
=======
        
>>>>>>> ec026c1ddf1e6328c229dd04b5b0abf3ec5f1059
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            //Ändrar färgen beroende på antal träffar.

           // audioManager.PlaySFX(audioManager.TableSFX);
            nrOfHits += 1;
            /*Color oldColor = spRend.color;

            Color newColor = new Color(oldColor.r +(nrOfHits*0.1f), oldColor.g + (nrOfHits * 0.1f), oldColor.b + (nrOfHits * 0.1f));
            
            spRend.color = newColor;*/

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Missile") || collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            //Ändrar färgen beroende på antal träffar.

           // audioManager.PlaySFX(audioManager.TableSFX);
            nrOfHits++;
            Color oldColor = spRend.color;

            Color newColor = new Color(oldColor.r +(nrOfHits*0.1f), oldColor.g + (nrOfHits * 0.1f), oldColor.b + (nrOfHits * 0.1f));
            
<<<<<<< HEAD
            spRend.color = newColor;*/

=======
            spRend.color = newColor;
            
            if (nrOfHits == 4)
            {
                GetComponent<SpriteRenderer>().sprite = bunk4;
                this.enabled = false; 
            }
            
>>>>>>> ec026c1ddf1e6328c229dd04b5b0abf3ec5f1059
        }
    }

    public void ResetBunker()
    {
        gameObject.SetActive(true);
    }
}
