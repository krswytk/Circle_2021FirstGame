using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1StartCount : MonoBehaviour
{
    public AudioClip Count4;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();
        Invoke("StartCount", 1.99f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartCount()
    {
        audioSource.PlayOneShot(Count4);
    }
}
