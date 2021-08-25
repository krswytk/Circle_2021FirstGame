using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{

	int score = 0;
	GameObject scoreText;
	GameObject gameOverText;
	GameObject clearText;

	public void GameOver()
    {
		this.gameOverText.GetComponent<Text>().text = "GameOver";
	}
	 
	public void Clear()
    {
		this.clearText.GetComponent<Text>().text = "Clear";
    }

	public void AddScore()
	{
		this.score += 10;
	}

	void Start()
	{
		this.scoreText = GameObject.Find("Score");
		this.gameOverText = GameObject.Find("GameOver");
		this.clearText = GameObject.Find("Clear");
	}

	void Update()
	{
		scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");
	}
}