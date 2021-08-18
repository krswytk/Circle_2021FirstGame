using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour
{

	float fallSpeed;
	float rotSpeed;

	void Start()
	{
		this.fallSpeed = 0.01f + 0.0001f * Random.value;
		this.rotSpeed = 0.5f + 0.3f * Random.value;
	}

	void Update()
	{
		transform.Translate(0, -fallSpeed, 0, Space.World);
		transform.Rotate(0, 0, rotSpeed);

		if (transform.position.y < -5.5f)
		{
			GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
			Destroy(gameObject);
		}
	}
}
	
	