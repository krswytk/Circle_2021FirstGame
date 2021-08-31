using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStartSwitch : MonoBehaviour
{
    Animator animator;
    public AudioClip Decision;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.localScale = new Vector2(3f, 1f);
    }

    void OnMouseEnter()
    {
        animator.SetTrigger("OverCursor");
    }

    void OnMouseDown()
    {
        audioSource.PlayOneShot(Decision);
        FadeManager.Instance.LoadScene("StageSelect", 1f);
    }
    void OnMouseExit()
    {
        animator.SetTrigger("OutCursor");
    }
}
