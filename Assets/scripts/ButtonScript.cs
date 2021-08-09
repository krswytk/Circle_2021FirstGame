using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private GameObject stage_Serect;
    // Start is called before the first frame update
    void Start()
    {
        stage_Serect = GameObject.Find("stage_Serect");//stageSelect‚ÉˆÚ“®
    }

    public void change_stage_Serect()
    {
        Invoke("stage_Serect", 1.5f);
        SceneManager.LoadScene("Stage_select");
    }
    public void change_RunGame()
    {
        Invoke("RunGame", 1.5f);
        SceneManager.LoadScene("RunGame");
    }
}
