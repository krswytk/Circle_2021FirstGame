using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimhit : MonoBehaviour
{
    Animator animator;
    public AudioClip Gun_hit;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Hit_Trigger");
            audioSource.PlayOneShot(Gun_hit);
        }
    }
}
