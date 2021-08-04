using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_script : MonoBehaviour
{
    private Score score;
    private GameObject TextScore;//Scoreテキスト
    // Start is called before the first frame update
    void Start()
    {
        TextScore = GameObject.Find("Score");
        score = TextScore.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)//何かに触れたとき
    {
        if (collision.gameObject.tag == "Player")
        {
            score.PlayerScore += 1000;
            this.gameObject.SetActive(false);
        }


    }
}
