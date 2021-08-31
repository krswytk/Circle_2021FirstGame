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
        Invoke("PlaySE", 8.210f);
        Invoke("PlaySE", 21.458f);
        Invoke("PlaySE", 34.706f);
        Invoke("PlaySE", 38.018f);
        Invoke("PlaySE", 41.330f);
        Invoke("PlaySE", 47.954f);
        Invoke("PlaySE", 54.578f);
        Invoke("PlaySE", 67.826f);
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
