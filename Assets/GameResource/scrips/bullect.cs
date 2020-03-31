using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullect : MonoBehaviour
{
    public float speed=10;
    public bool isplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up*speed*Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isplayer)
                {  collision.SendMessage("Die"); }
                break;
            case "Home":
                collision.SendMessage("die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isplayer)
                { collision.SendMessage("Die"); }
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
            default:
                break;

        }
    }
}
