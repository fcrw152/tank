using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite Breakhome;
    public GameObject explosion1;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
   
    public void die()
    {
        sr.sprite=Breakhome;
        Instantiate(explosion1, transform.position, transform.rotation);
    }
}
