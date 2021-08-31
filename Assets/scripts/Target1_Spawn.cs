using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1_Spawn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Stage1score.S1score = 0;
        Invoke("Target1R", 4.484f);
        Invoke("Target1R", 6.140f);
        Invoke("Target1R", 7.796f);
        Invoke("Target2R", 8.624f);
        Invoke("Target2L", 9.038f);
        Invoke("Target2R", 9.452f);
        Invoke("Target1R", 11.108f);
        Invoke("Target1R", 12.764f);
        Invoke("Target1R", 14.420f);
        Invoke("Target1L", 16.076f);
        Invoke("Target1R", 17.732f);
        Invoke("Target1R", 19.388f);
        Invoke("Target1R", 21.044f);
        Invoke("Target2R", 21.872f);
        Invoke("Target2R", 22.286f);
        Invoke("Target2L", 22.700f);
        Invoke("Target1R", 24.356f);
        Invoke("Target1R", 26.012f);
        Invoke("Target1R", 27.668f);
        Invoke("Target1R", 29.324f);
        Invoke("Target1L", 30.980f);
        Invoke("Target1L", 32.636f);
        Invoke("Target1L", 34.292f);
        Invoke("Target2R", 35.120f);
        Invoke("Target2L", 35.534f);
        Invoke("Target2R", 35.948f);
        Invoke("Target1R", 36.766f);
        Invoke("Target1R", 37.594f);
        Invoke("Target2R", 38.422f);
        Invoke("Target2L", 38.836f);
        Invoke("Target2R", 39.250f);
        Invoke("Target1L", 40.078f);
        Invoke("Target1L", 40.906f);
        Invoke("Target2L", 41.734f);
        Invoke("Target2R", 42.148f);
        Invoke("Target2L", 42.562f);
        Invoke("TargetSR", 43.390f);
        Invoke("TargetSR", 44.011f);
        Invoke("Target1R", 45.046f);
        Invoke("Target1R", 45.874f);
        Invoke("TargetSR", 46.702f);
        Invoke("TargetSR", 47.323f);
        Invoke("Target2R", 48.358f);
        Invoke("Target2L", 48.772f);
        Invoke("Target2R", 49.186f);
        Invoke("TargetSL", 50.004f);
        Invoke("TargetSL", 50.625f);
        Invoke("Target1L", 51.660f);
        Invoke("Target1L", 52.488f);
        Invoke("TargetSL", 53.316f);
        Invoke("TargetSL", 53.937f);
        Invoke("Target2L", 54.972f);
        Invoke("Target2R", 55.386f);
        Invoke("Target2L", 55.800f);
        Invoke("Target1R", 57.456f);
        Invoke("Target1R", 59.112f);
        Invoke("Target1R", 60.768f);
        Invoke("Target1L", 62.424f);
        Invoke("Target1R", 64.080f);
        Invoke("Target1R", 65.736f);
        Invoke("Target1R", 67.392f);
        Invoke("Target2R", 68.220f);
        Invoke("Target2L", 68.634f);
        Invoke("Target2R", 69.048f);
        Invoke("Gotoresult", 80f);
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
        GameObject instance = (GameObject)Instantiate(Target2L, new Vector3(-17.0f, 0.0f, 4.0f), Quaternion.identity);
    }

    void TargetSR()
    {
        GameObject TargetSR = (GameObject)Resources.Load("TargetS_R");
        GameObject instance = (GameObject)Instantiate(TargetSR, new Vector3(17.0f, 0.0f, 4.0f), Quaternion.identity);
    }

    void TargetSL()
    {
        GameObject TargetSL = (GameObject)Resources.Load("TargetS_L");
        GameObject instance = (GameObject)Instantiate(TargetSL, new Vector3(-17.0f, 0.0f, 4.0f), Quaternion.identity);
    }

    void Gotoresult()
    {
        FadeManager.Instance.LoadScene("Stage1result", 0.5f);
    }
}
