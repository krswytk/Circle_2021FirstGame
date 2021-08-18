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
    // Start is called before the first frame update
    private void OnMouseOver()
    {
        //Sphere�̐F��ԐF�ɕω������܂��B
        botton_Obj.GetComponent<Renderer>().material.color = new Color(70f, 70f, 70f,255f); ;
    }

    //�}�E�X�J�[�\����Sphere�̏ォ�痣�ꂽ���̏���
    private void OnMouseExit()
    {
        //Sphere�̐F�����̐F�ɖ߂�܂��B
        botton_Obj.GetComponent<Renderer>().material.color = new Color(255f,255f,255f,255f);
    }
    public void change_stage_Serect()
    {
        Bottonclick_sound = Sound_Obj.GetComponent<AudioSource>();
        Bottonclick_sound.Stop();
        Bottonclick_sound.PlayOneShot(Game_In_sound);
        FadeManager.Instance.LoadScene("stage_Select", 2.0f);
        
    }
    public void change_RunGame()
    {

        Bottonclick_sound = Sound_Obj.GetComponent<AudioSource>();
        Bottonclick_sound.Stop();
        Bottonclick_sound.PlayOneShot(Game_In_sound);
        FadeManager.Instance.LoadScene("RunGame", 2.0f);
    }
}
