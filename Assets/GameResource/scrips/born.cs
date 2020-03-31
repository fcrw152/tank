using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class born : MonoBehaviour
{
    public GameObject play1;
    public GameObject[] enemylist;
    public bool isbornplayer; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("borntank",1.5f);
        Destroy(gameObject, 1.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void borntank()
    {
        if (!isbornplayer)
        {
            int num = Random.Range(0, 2);
            Instantiate(enemylist[num], transform.transform.position, transform.rotation);
        }
        else
        { Instantiate(play1, transform.position, transform.rotation); }
        
    }
}
