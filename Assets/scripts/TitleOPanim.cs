using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleOPanim : MonoBehaviour
{

    [SerializeField] GameObject OPt1;
    [SerializeField] GameObject OPt2;
    [SerializeField] GameObject OPt3;
    [SerializeField] GameObject OPt4;
    [SerializeField] GameObject OPt5;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        StartCoroutine("OPanimation");
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fateout()
    {
        this.gameObject.AddComponent<TitleOPfade>();
    }

    IEnumerator OPanimation()
    {
        yield return new WaitForSeconds(0.5f);
        yield return null;
        OPt1.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        yield return null;
        OPt1.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        yield return null;
        OPt2.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        yield return null;
        OPt2.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        yield return null;

        OPt3.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        yield return null;
        OPt4.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        yield return null;
        OPt3.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        yield return null;
        OPt4.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        yield return null;

        OPt5.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        yield return null;
        
        yield return new WaitForSeconds(0.3f);
        yield return null;
        GetComponent<SpriteRenderer>().material.color = Color.white;
        
        animator.SetTrigger("Trigger");
        yield return new WaitForSeconds(0.5f);
        OPt5.SetActive(false);

        yield break;


    }
}
