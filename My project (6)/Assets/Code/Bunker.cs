using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bunker : MonoBehaviour
{

    readonly AudioManager audioManager;

    int nrOfHits = 0;
    public Sprite bunk1, bunk2, bunk3, bunk4;
    public GameObject bunk; 
    SpriteRenderer spRend;
    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log(nrOfHits);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            //Ändrar färgen beroende på antal träffar.

            audioManager.PlaySFX(audioManager.TableSFX);
            nrOfHits++;
            /*Color oldColor = spRend.color;

            Color newColor = new Color(oldColor.r +(nrOfHits*0.1f), oldColor.g + (nrOfHits * 0.1f), oldColor.b + (nrOfHits * 0.1f));
            
            spRend.color = newColor;*/
            
            if (nrOfHits == 4)
            {
                GetComponent<SpriteRenderer>().sprite = bunk4;
                GetComponent<BoxCollider2D>().enabled = false; 
            }
            
        }
    }

    public void ResetBunker()
    {
        gameObject.SetActive(true);
    }
}
