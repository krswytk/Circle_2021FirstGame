using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1score : MonoBehaviour
{
    public static int S1score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int gets1score()
    {
        return S1score;
    }
}
