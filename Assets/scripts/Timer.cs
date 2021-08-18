using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject player_Obj;
    public GameObject score_Obj;
    public GameObject frog_Obj;
    public Text Count_Text;
    public GameObject Count_Obj;//gameoverテキスト
    public GameObject music_Obj;
    float countdown = 4f;
    public AudioClip countdown_sound;
    AudioSource audiosource;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(countdown_sound);
    }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (countdown >1)
            {
                countdown -= Time.deltaTime;
                count = (int)countdown;
                Count_Text.text = count.ToString();
            }else {
                player_Obj.GetComponent<player_script>().enabled = true;
                player_Obj.GetComponent<Clear_GameOver>().enabled = true;
                score_Obj.GetComponent<Score>().enabled = true;
                frog_Obj.GetComponent<frog_script>().enabled = true;
                music_Obj.GetComponent<Main_Game_Music>().enabled = true;
                Count_Obj.SetActive(false);//textgameoverを非表示にする
            }
        }   
}
