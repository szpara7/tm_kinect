using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PGMGenerator
{
    public static void SaveMap(ushort[,] pointsTab)
    {
        int width = pointsTab.GetLength(0);
        int height = pointsTab.GetLength(1);
 
        if (!Directory.Exists(DateTime.Now.ToString("dd-MM-yyyy")))
        {
            Directory.CreateDirectory((DateTime.Now.ToString("dd-MM-yyyy")));
        }

        FileStream file = new FileStream(DateTime.Now.ToString("dd-MM-yyyy") + "/" + "PGM - " + DateTime.Now.ToString("HH-mm-ss-fff") + ".pgm"
        , FileMode.Create, FileAccess.Write);


        using (var writer = new StreamWriter(file))
        {
            writer.Write("P2" + " ");
            writer.Write(width.ToString() + " " + height.ToString() + " ");
            writer.WriteLine(ushort.MaxValue.ToString());

            for (int y = height - 1; y >= 0 ; y--)
            {
                for (int x = 0; x < width; x++)
                {
					if(x != width - 1)
                    writer.Write(ushort.MaxValue - pointsTab[x, y] + "\t");
					else writer.Write(ushort.MaxValue - pointsTab[x, y] + "\n");
                };
            }
        }
    }
}