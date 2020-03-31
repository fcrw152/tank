using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //属性
    public float moveSpeed = 3;
    private Vector3 bullectEulerangles;
    public float timeVal;
    public float changetimeVal=0;
    
    //是否为保护状态
    //private bool isDefended = true;
    //保护时间
    //private float isDefendedtimeVal = 3;
    //
    private SpriteRenderer sr;
    public Sprite[] tankSprite;
    public GameObject bullect1;
    public GameObject explosionPrefab;
    //保护特效
    //public GameObject shiedeffect;
    private float v=-1;
    private float h;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //保护函数
        //if (isDefended)
        //{
          //  shiedeffect.SetActive(true);
            //isDefendedtimeVal -= Time.deltaTime;
           // if (isDefendedtimeVal <= 0)
            //{
              //  isDefended = false;
               // shiedeffect.SetActive(false);
           // }
       // }
        //攻击CD
        if (timeVal >= 2f)
        {
            atk();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Move();

    }
    //攻击
    private void atk()
    {
        
            Instantiate(bullect1, transform.position, Quaternion.Euler(bullectEulerangles));
            timeVal = 0;
        
    }
    //移动
    private void Move()
    {

        if (changetimeVal > 2)
        {
            int num = Random.Range(0, 9);
            if (num >= 6) { v = -1; h = 0; }
            else if (1>=num&&num>=0) { v = 1; h = 0; }
            else if (2 <= num && num <= 3) { v = 0; h = -1; }
            else if (4<= num && num <=5 ) { v = 0; h = 1; }
            changetimeVal = 0;
        }
        else { changetimeVal += Time.fixedDeltaTime; }
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerangles = new Vector3(0, 0, 90);
        }
        if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerangles = new Vector3(0, 0, -90);
        }
       
        
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerangles = new Vector3(0, 0, -180);
        }
        if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerangles = new Vector3(0, 0, 0);
        }
    }
    //坦克死亡
    private void Die()
    {
        //爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //坦克死亡
        Destroy(gameObject);
        playmanager.Instance.score++;
    }
    //碰撞后转换方向
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { changetimeVal = 30; }
        if (collision.gameObject.tag == "Barrier") { changetimeVal = 300; }
        if (collision.gameObject.tag == "River") { changetimeVal = 30; }
    }
}