using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{

	public GameObject bulletPrefab;

	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-0.01f, 0, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(0.01f, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		}
        if (Input.GetKey(KeyCode.UpArrow))
        {
			transform.Translate(0, 0.01f, 0);
        }
		if (Input.GetKey(KeyCode.DownArrow))
        {
			transform.Translate(0, -0.01f, 0);
        }

		if(transform.position.y > 20)
        {
			GameObject.Find("Canvas").GetComponent<UIController>().Clear();
			Time.timeScale = 0f; 
		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		this.gameObject.SetActive(false);
		GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
	}
}