using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_script : MonoBehaviour
{
    private Score score;
    private GameObject TextScore_Obj;//Score�e�L�X�g
    // Start is called before the first frame update
    void Start()
    {
        TextScore_Obj = GameObject.Find("Score");
        score = TextScore_Obj.GetComponent<Score>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)//�����ɐG�ꂽ�Ƃ�
    {
        if (collision.gameObject.tag == "Player")
        {
            Score.plusscore(1000);
            this.gameObject.SetActive(false);
        }


    }
}
