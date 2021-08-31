using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCG : MonoBehaviour
{
    public Material E;
    public Material G;
    public Material R;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if(S1result.HR == 2)
        {
            GetComponent<Renderer>().material = E;
        }else if(S1result.HR == 1)
        {
            GetComponent<Renderer>().material = G;
        }else
        {
            GetComponent<Renderer>().material = R;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
