using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_GunmanBGM : MonoBehaviour
{
    public AudioClip GunmanBGM;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlayBGM", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayBGM()
    {
        audioSource.PlayOneShot(GunmanBGM);
    }
}
