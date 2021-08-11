using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1_Spawn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Target1R", 0.375f);
        Invoke("Target1R", 1.125f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Target1R()
    {
        GameObject TargetR = (GameObject)Resources.Load("Target1_R");
        GameObject instance = (GameObject)Instantiate(TargetR,new Vector3(17.0f, 0.0f, 4.0f),Quaternion.identity);
    }

    void Target1L()
    {
        GameObject TargetL = (GameObject)Resources.Load("Target1_L");
        GameObject instance = (GameObject)Instantiate(TargetL, new Vector3(-17.0f, 0.0f, 4.0f), Quaternion.identity);
    }
}
