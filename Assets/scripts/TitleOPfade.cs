using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOPfade : MonoBehaviour
{
    public float fadeTime = 0.5f;

    private float currentRemainTime;
    private SpriteRenderer spRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        currentRemainTime = fadeTime;
        spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentRemainTime -= Time.deltaTime;

        if (currentRemainTime <= 0f)
        {
            // 残り時間が無くなったら自分自身を消滅
            GameObject.Destroy(gameObject);
            return;
        }
        float alpha = currentRemainTime / fadeTime;
        var color = spRenderer.color;
        color.a = alpha;
        spRenderer.color = color;
    }
}
