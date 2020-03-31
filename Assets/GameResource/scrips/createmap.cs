using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createmap : MonoBehaviour
{
    //用于存放预制体
    //0.家1.墙2.铁墙3.出生4.河流5.草6.空气墙
    public GameObject[] item;
    private List<Vector3> itempositionlist = new List<Vector3>();
    private void Awake()
    {
        careteitem(item[0],new Vector3(0,-8,0),Quaternion.identity);
        careteitem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        careteitem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        
        int i;
        for (i = -1; i < 2; i++) { careteitem(item[1], new Vector3(i, -7, 0), Quaternion.identity); }
        //生成空气墙
        for (i = -17; i <= 17; i++) { careteitem(item[6], new Vector3(i, -9, 0), Quaternion.identity); }
        for (i = -17; i <= 17; i++) { careteitem(item[6], new Vector3(i, 9, 0), Quaternion.identity); }
        for (i = -9; i < 9; i++) { careteitem(item[6], new Vector3(18, i, 0), Quaternion.identity); }
        for (i = -9; i < 9; i++) { careteitem(item[6], new Vector3(-18, i, 0), Quaternion.identity); }
        //生产玩家
        GameObject go = Instantiate(item[3], new Vector3(-2,-8,0), Quaternion.identity);
        go.GetComponent<born>().isbornplayer = true;
        itempositionlist.Add(new Vector3(-2, -8, 0));
        //产生敌人
        InvokeRepeating("createenemy",0,4);
        //随机产生地图块
        chanshengsuijikuai();
    }
    private void careteitem(GameObject creategameObject, Vector3 createposition, Quaternion createquaternion)
    {
        GameObject realitem = Instantiate(creategameObject, createposition, createquaternion);
        realitem.transform.SetParent(gameObject.transform);
        itempositionlist.Add(createposition);
    }
  

    //产生随机位置
    private Vector3 createrandomposition()
    {
        //x轴 -16到16，y轴-8到8
        while (true)
        {
            Vector3 createposition = new Vector3(Random.Range(-17, 18), Random.Range(-8, 9), 0);
            if (isinpositionlist(createposition)==false) { return createposition;}
            
        }
    }
    //判断随机位置在不在列表里
    private bool isinpositionlist(Vector3 Vposition)
    {
        int i = 0;
        for (i = 0; i < itempositionlist.Count; i++)
        {
            if (Vposition == itempositionlist[i]) { return true; }
        }
        return false;
    }
    //产生随机地图块的函数
    private void chanshengsuijikuai()
    {
        int i;
        for (i = 0; i < 60; i++) { careteitem(item[1], createrandomposition(), Quaternion.identity); }
        for (i = 0; i < 20; i++) { careteitem(item[2], createrandomposition(), Quaternion.identity); }
        for (i = 0; i < 20; i++) { careteitem(item[4], createrandomposition(), Quaternion.identity); }
        for (i = 0; i < 20; i++) { careteitem(item[5], createrandomposition(), Quaternion.identity); }
    }
    //产生敌人的函数
    private void createenemy()
    {
        int i;
        i = Random.Range(0, 3);
        if (i == 0) { careteitem(item[3], new Vector3(-17, 8, 0), Quaternion.identity); }
        if (i == 1) { careteitem(item[3], new Vector3(0, 8, 0), Quaternion.identity); }
        if (i == 2) { careteitem(item[3], new Vector3(17, 8, 0), Quaternion.identity); }
    }
}
