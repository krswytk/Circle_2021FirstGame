using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    public Text GoScore_Text;//Goscoreテキスト
    public GameObject Goal_Obj;//Goaltextobject
    private bool isgole;
    private float speed = 1.0f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        Goal_Obj.SetActive(false);//goaltextを非表示にする
        GoScore_Text = this.gameObject.GetComponent<Text>();
        isgole = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isgole)
        {
            GoScore_Text.color = GetAlphaColor(GoScore_Text.color);
        }
        if (Input.GetKeyDown(KeyCode.Return) && isgole)
        {
            SceneManager.LoadScene("result");
        }
    }
    public Color GetAlphaColor(Color color)/*参考サイト
                                        https://goodlucknetlife.com/unity-2daction-blinker/
                                      */
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time);
        return color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Goal_Obj.SetActive(true);//goaltextを表示にする
            isgole = true;
        }
    }
}
