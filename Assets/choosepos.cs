using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class choosepos : MonoBehaviour
{
    private int chiose = 1;
    public Transform pos1;
    public Transform pos2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.W)) { chiose = 1;transform.position = pos1.position; }
        if (Input.GetKeyDown(KeyCode.S)) { chiose = 2; transform.position = pos2.position; }
        if (chiose == 1 && Input.GetKeyDown(KeyCode.Space)) { SceneManager.LoadScene("SampleScene"); }
    }
}
