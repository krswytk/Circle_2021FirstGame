using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targethit1R : MonoBehaviour
{
    float seconds1R;
    // Start is called before the first frame update
    void Start()
    {
        seconds1R = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seconds1R += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if(seconds1R < 0.375)
            {
                if(seconds1R >= 0.325)
                {
                    seconds1R = 0;
                    Destroy(gameObject);
                }
            }
            if(seconds1R == 0.375)
            {
                seconds1R = 0;
                Destroy(gameObject);
            }
            if(seconds1R > 0.375)
            {
                if(seconds1R <= 0.425)
                {
                    seconds1R = 0;
                    Destroy(gameObject);
                }
            }
        }
    }
}
