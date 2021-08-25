using UnityEngine;


// Start is called before the first frame update
public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 playerpos;

    void Start()
    {
        player = GameObject.Find("rocket");

    }

    // Update is called once per frame
    void Update()
    {
        playerpos = player.transform.position;
        transform.position = new Vector3(transform.position.x, playerpos.y+4, transform.position.z);
    }

}