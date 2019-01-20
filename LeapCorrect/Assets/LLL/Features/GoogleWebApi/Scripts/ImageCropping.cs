using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImageCropping : MonoBehaviour {

    public TextAsset imageByte;
    public int cropSize = 40;
    public ImageRecognizer imgRec;

	public void ImageCrop()
    {
        string originalByte = imageByte.text;

        byte[] imageByteOriginal= System.Convert.FromBase64String(originalByte);

        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(imageByteOriginal);
        tex = ApplyCrop(tex);
        Renderer rend = GetComponent<Renderer>();
        rend.sharedMaterial.mainTexture = tex;

        imgRec.UpdloadScreen (tex.EncodeToJPG());
    }

    public Texture2D ApplyCrop(Texture2D original)
    {
        Color[] textureData = original.GetPixels();
        int index = 0;
        Vector2 center = new Vector2(original.height / 2, original.width/2);
        Debug.Log(center);

        for (int y = 0; y < original.height; y++)
        {
            for (int x = 0; x < original.width; x++)
            {
                Vector2 point = new Vector2(y, x);
                if (Vector2.Distance(point, center) > cropSize)
                {
                   textureData[index] = Color.black;
                }
                //if (y < cropSize && x < cropSize) {
                //    textureData[index] = Color.black;
                //}
                index++;
            }

        }
        original.SetPixels(textureData,0);
        original.Apply();
        return original;
    }
}
