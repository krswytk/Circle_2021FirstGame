using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeHitSE_Play : MonoBehaviour
{
    public AudioClip ThreeHitSE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>();
        Invoke("PlaySE", 6.210f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaySE()
    {
        audioSource.PlayOneShot(ThreeHitSE);
    }
}
