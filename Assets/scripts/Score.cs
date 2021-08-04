using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int PlayerScore;
    private int ClearScore;
    public GameObject Text;
    public Text TextScore;
    public bool isclear;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
        Text.SetActive(true);
        isclear = false;
    }

    // Update is called once per frame
    void Update()
    {
        score();
    }
    void score()
    {
        
        if (isclear)
        {
            ClearScore = PlayerScore;
            TextScore.text = "Score" + ClearScore;
        }
        else
        {
            PlayerScore++;
            TextScore.text = "Score" + PlayerScore;
        }
    }
}
