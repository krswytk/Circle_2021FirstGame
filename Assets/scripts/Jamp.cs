using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jamp : MonoBehaviour

{
    private Rigidbody2D rb;
    private Vector3 force;
    Ray ray;
    public bool isGround;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        isGround = false;
        rb = this.GetComponent<Rigidbody2D>();
        force = new Vector3(1.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        force = new Vector3(force.x, 0f, 0f);
        int layerMask=1<<6;
        layerMask= ~layerMask;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            force.y += 250.0f;
            isGround = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask);
        }
        /*if (Input.GetKey(KeyCode.Space))
        {
            this.gameObject.transform.Translate(0f, 0.1f, 0f);
        }

        
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(-0.1f, 0f, 0f);
        }*/
        

        rb.AddForce(force);
     
        
    }

}