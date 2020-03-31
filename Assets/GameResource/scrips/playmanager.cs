using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmanager : MonoBehaviour
{
    private int lifes=3;
    public int score = 0;
    public bool isdead;
    public bool shibai=false;
    public GameObject born;
    private static playmanager instance;

    public static playmanager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    private void Awake()
        {
        Instance= this;
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isdead) { fuhuo(); }
    }
    private void fuhuo()
    {
        if (lifes < 0)
        {
            //游戏结束
            shibai = true;
        }
        else
        {
            lifes--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<born>().isbornplayer = true;
            isdead = false;
        }
    }
}
