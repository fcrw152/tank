using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    //属性
    public float moveSpeed = 3;
    private Vector3 bullectEulerangles;
    public float timeVal;
    private bool isDefended=true;
    private float isDefendedtimeVal=3;
    //
    private SpriteRenderer sr;
    public Sprite[] tankSprite;
    public GameObject bullect1;
    public GameObject explosionPrefab;
    public GameObject shiedeffect;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDefended)
        {
            shiedeffect.SetActive(true);
            isDefendedtimeVal -= Time.deltaTime;
            if (isDefendedtimeVal<=0) {
                isDefended = false;
                shiedeffect.SetActive(false);
            }
        }
        //攻击CD
        
    }
    private void FixedUpdate()
    {
        if (playmanager.Instance.shibai == true) { return ; }
        Move();
        if (timeVal >= 0.5f)
        {
            atk();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }
    //攻击
    private void atk()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullect1, transform.position,Quaternion.Euler(bullectEulerangles));
            timeVal = 0;
        }
    }
    //移动
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
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
        if (h != 0)
        {
            return;
        }
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerangles = new Vector3(0, 0, -180);
        }
        if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerangles = new Vector3(0, 0,0);
        }
    }
    //坦克死亡
    private void Die()
    {
        if (isDefended) { return; }
        //爆炸特效
        Instantiate(explosionPrefab,transform.position,transform.rotation);
        //坦克死亡
        Destroy(gameObject);
        playmanager.Instance.isdead = true;
    }
}
