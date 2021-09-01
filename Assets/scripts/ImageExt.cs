//ImageExt.cs
// author: trpla226
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class ImageExt
{

    // Start is called before the first frame update

    /// <summary>
    /// Imageの不透明度を設定する
    /// </summary>
    /// <param name="image">設定対象のImageコンポーネント(this)</param>
    /// <param name="alpha">不透明度。0=透明 1=不透明</param>
    public static void SetOpacity(this Image image, float alpha)
    {
        Application.targetFrameRate = 60;
        var c = image.color;
        image.color = new Color(c.r, c.g, c.b, alpha);
    }
}
