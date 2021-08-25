using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public static int Result;
    public GameObject GoalText;
    
    // Use this for initialization
    void Start()
    {

        GoalText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GoalText.SetActive(true);
            Result = 1;
            Invoke("DelayMethod", 3.5f);
        }
    }

    void DelayMethod()
    {
         SceneManager.LoadScene("result");
    }
}