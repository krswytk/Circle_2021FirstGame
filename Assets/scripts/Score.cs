using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int PlayerScore_int;
    public GameObject Text_Obj;
    public Text TextScore_Text;
    public bool isclear_bool;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScore_int = 0;
        Text_Obj.SetActive(true);
        isclear_bool = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score();
    }
    public static int getscore()
    {
        return PlayerScore_int;
    }
    public static void plusscore(int plus)
    {
        PlayerScore_int += plus;
    }
    void score()
    {
        
        if (isclear_bool)
        {
            TextScore_Text.text = "Score " + PlayerScore_int;
        }
        else
        {
            PlayerScore_int++;
            TextScore_Text.text = "Score " + PlayerScore_int;
        }
    }
}
