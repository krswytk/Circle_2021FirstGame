using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonScript : MonoBehaviour
{
    public GameObject botton_Obj;
    public GameObject Sound_Obj;
    public AudioClip Game_In_sound;
    AudioSource Bottonclick_sound;
    bool stage_serect_push_bool;
    bool RunGame_push_bool;
    bool RunGame2_push_bool;
    // Start is called before the first frame update
    void Start()
    {
        stage_serect_push_bool = true;
        RunGame_push_bool=true;
        RunGame2_push_bool = true;
        SceneManager.sceneUnloaded += SceneUnloaded;
    }
    private void OnMouseOver()
    {
        //Sphereの色を赤色に変化させます。
        botton_Obj.GetComponent<Renderer>().material.color = new Color(70f, 70f, 70f,255f); ;
    }

    //マウスカーソルがSphereの上から離れた時の処理
    private void OnMouseExit()
    {
        //Sphereの色が元の青色に戻ります。
        botton_Obj.GetComponent<Renderer>().material.color = new Color(255f,255f,255f,255f);
    }
    public void change_stage_Serect()
    {
        if (stage_serect_push_bool)
        {
            Bottonclick_sound = Sound_Obj.GetComponent<AudioSource>();
            Bottonclick_sound.Stop();
            Bottonclick_sound.PlayOneShot(Game_In_sound);
            FadeManager.Instance.LoadScene("stage_Select", 2.0f);
            stage_serect_push_bool = false;
        }
    }
    public void change_RunGame()
    {
        if (RunGame_push_bool)
        {
            Bottonclick_sound = Sound_Obj.GetComponent<AudioSource>();
            Bottonclick_sound.Stop();
            Bottonclick_sound.PlayOneShot(Game_In_sound);
            FadeManager.Instance.LoadScene("RunGame", 2.0f);
            RunGame_push_bool = false;
        }
    }
    public void change_RunGame2()
    {
        if (RunGame2_push_bool)
        {
            Bottonclick_sound = Sound_Obj.GetComponent<AudioSource>();
            Bottonclick_sound.Stop();
            Bottonclick_sound.PlayOneShot(Game_In_sound);
            FadeManager.Instance.LoadScene("RunGame2", 2.0f);
            RunGame2_push_bool = false;
        }
    }
    void SceneUnloaded(Scene buttonScene)
    {
        Debug.Log("botton");
        stage_serect_push_bool = true;
        RunGame_push_bool = true;
    }

}
