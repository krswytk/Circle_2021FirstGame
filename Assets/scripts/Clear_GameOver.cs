using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Clear_GameOver : MonoBehaviour
{
    public GameObject TextGameover_Obj;//gameoverテキスト
    private Score score;
    private Transform TextScore_Tran;//Scoreテキスト
    public GameObject canvas_Obj;
    public Text GoScore_Text;//Goscoreテキスト
    public Text Gameover_Text;//Gameoverテキスト
    public GameObject Goal_Obj;//Goaltextobject
    public GameObject GoScore_Obj;//Goscoreobject
    private bool isgole_bool;
    private static float speed = 1.0f;
    private static float time;
    private bool isgameover_bool;
    private bool isPushEnter_bool;
    AudioSource audioSource;
    public AudioClip Gameover_sound;
    public AudioClip Clear_sound;
    public GameObject music_Obj;
    player_script p1 ;
    // Start is called before the first frame update
    void Start()
    {
        TextGameover_Obj.SetActive(false);//textgameoverを非表示にする
        TextScore_Tran = canvas_Obj.transform.Find("Score");//scoreを探す
        TextScore_Tran.gameObject.SetActive(true);//textscoreを表示する
        canvas_Obj = GameObject.Find("Canvas");
        Goal_Obj.SetActive(false);//goaltextを非表示にする
        score = TextScore_Tran.GetComponent<Score>();
        isgole_bool = false;
        isPushEnter_bool = true;
        SceneManager.sceneUnloaded += SceneUnloaded;
        p1 = GetComponent<player_script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isgole_bool)
        {
            GoScore_Text.color = GetAlphaColor(GoScore_Text.color);
        }
        if (Input.GetKeyDown(KeyCode.Return) && isgole_bool&&isPushEnter_bool)
        {
            isPushEnter_bool = false;
            FadeManager.Instance.LoadScene("result", 2.0f);
        }
        if (isgameover_bool)
        {
            Gameover_Text.color = GetAlphaColor(Gameover_Text.color);
        }
        if (Input.GetKeyDown(KeyCode.Return) && isgameover_bool)
        {
            isPushEnter_bool = false;
            FadeManager.Instance.LoadScene("result", 2.0f);
        }
    }
    public static Color GetAlphaColor(Color color)
    {
        /*参考サイト
         https://goodlucknetlife.com/unity-2daction-blinker/
        */
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time);
        return color;
    }
    void Gameover()
    {
        TextGameover_Obj.SetActive(true);//GameOverを表示する
        isgameover_bool = true;
        score.isclear_bool = true;
        audioSource = music_Obj.GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.PlayOneShot(Gameover_sound);
        GoScore_Obj.SetActive(true);//goaltextを表示にする
        p1.gameover();
    }
    void OnTriggerEnter2D(Collider2D collision)//何かに触れたとき
    {
        if (collision.gameObject.tag == "hawk")
        {
            Gameover();
        }
        if (collision.gameObject.tag == "Goal")
        {
            isgole_bool = true;
            goal();
        }
    }
    
    void goal()
    {
        if (isgole_bool)
        {
            audioSource = music_Obj.GetComponent<AudioSource>();//AudioSourceを探す
            audioSource.Stop();//今再生している音楽を止めるb
            audioSource.PlayOneShot(Clear_sound);//クリアした時の音を鳴らす
            Goal_Obj.SetActive(true);//goaltextを表示にする
            GoScore_Obj.SetActive(true);//goaltextを表示にする
            score.isclear_bool = true;
            player_script.speed_f = 0f;
            p1.cliar();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "wall")
        {
            Gameover();
        }
        if (collision.gameObject.tag == "Fall")
        {
            Gameover();
        }
        
    }
    void SceneUnloaded(Scene clear_gameoverScene)
    {
        Debug.Log("clear");
        isPushEnter_bool = true;
    }
}
