using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject player;
    public GameObject score;
    public GameObject frog;
    public Text CountText;
    public GameObject CountOvject;//gameoverテキスト
    float countdown = 4f;
    int count;
    // Start is called before the first frame update
    void Start()
    {

    }

        // Update is called once per frame
        void Update()
        {
            if (countdown >= 0)
            {
                countdown -= Time.deltaTime;
                count = (int)countdown;
                CountText.text = count.ToString();
            }else{
                player.GetComponent<player_script>().enabled = true;
                score.GetComponent<Score>().enabled = true;
                frog.GetComponent<frog_script>().enabled = true;
                CountOvject.SetActive(false);//textgameoverを非表示にする
            }
        }   
}
