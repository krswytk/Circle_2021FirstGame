using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1_Spawn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Invoke("Target1R", 2.484f);
        Invoke("Target1R", 4.140f);
        Invoke("Target1R", 5.796f);
        Invoke("Target2R", 6.624f);
        Invoke("Target2L", 7.038f);
        Invoke("Target2R", 7.452f);
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

    void Target2R()
    {
        GameObject Target2R = (GameObject)Resources.Load("Target2_R");
        GameObject instance = (GameObject)Instantiate(Target2R, new Vector3(17.0f, 0.0f, 4.0f), Quaternion.identity);
    }

    void Target2L()
    {
        GameObject Target2L = (GameObject)Resources.Load("Target2_L");
        GameObject instance = (GameObject)Instantiate(Target2L, new Vector3(17.0f, 0.0f, 4.0f), Quaternion.identity);
    }
}
