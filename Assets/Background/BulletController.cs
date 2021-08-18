using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
	void Update()
	{
		transform.Translate(0, 0.02f, 0);

		if (transform.position.y > 6)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		GameObject.Find("Canvas").GetComponent<UIController>().AddScore();
		Destroy(gameObject);
		Destroy(coll.gameObject);
	}
}

