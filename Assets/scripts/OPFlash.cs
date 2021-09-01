using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ImageExt;

public class OPFlash : MonoBehaviour
{
    int i;
    int c;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        Invoke("Destroy", 0.4f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Flash = GameObject.Find("Flash");
        Image image = Flash.GetComponent<Image>();
        image.SetOpacity(i+0.0016f);

    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
