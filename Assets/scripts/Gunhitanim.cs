using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunhitanim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();

        int hit = animator.GetInteger("hit");

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            hit++;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            hit--;
        }

        animator.SetInteger("hit", hit);
    }
}
