using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1SButton : MonoBehaviour
{
    Animator animator;
    public AudioClip Select;
    public AudioClip Decision;
    public AudioClip CannotPlay;
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
        
    }

    void OnMouseEnter()
    {
        audioSource.PlayOneShot(Select);
        animator.SetTrigger("OverCursor");
    }

    void OnMouseDown()
    {
        audioSource.PlayOneShot(Decision);
        //audioSource.PlayOneShot(CannotPlay);
        FadeManager.Instance.LoadScene("Stage1", 1f);
    }
    void OnMouseExit()
    {
        animator.SetTrigger("OutCursor");
    }
}
