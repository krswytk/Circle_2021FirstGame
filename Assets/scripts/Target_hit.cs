using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_hit : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Invoke("TargetDestroy", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerStay(Collider collider)
    {
        //Debug.Log("1");
        if(collider.tag == "Aim")
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(gameObject);
            }
        }
    }

    void TargetDestroy()
    {
        Destroy(gameObject);
    }

}
