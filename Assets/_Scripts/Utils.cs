using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Scripts
{
    public class Utils
    {
        public static Color32 AverageColorFromTexture(Texture2D tex)
        {

            Color32[] texColors = tex.GetPixels32();

            int total = texColors.Length;

            float r = 0;
            float g = 0;
            float b = 0;

            for (int i = 0; i < total; i++)
            {

                r += texColors[i].r;

                g += texColors[i].g;

                b += texColors[i].b;

            }

            return new Color32((byte)(r / total), (byte)(g / total), (byte)(b / total), 0);

        }
    }
}
