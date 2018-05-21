﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthTexture : MonoBehaviour {

	public RawImage image;

	public void DrawDepthTexture(float[,] pointTab,int maxDistance)
	{
		int width = pointTab.GetLength(0);
		int height = pointTab.GetLength(1);

		Texture2D texture = new Texture2D(width, height);
		Color[] colorMap = new Color[width * height];

		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, pointTab[x, y] / maxDistance);
			}
		}

		texture.SetPixels(colorMap);
		texture.Apply();
		
		image.texture = texture;
	}
}
