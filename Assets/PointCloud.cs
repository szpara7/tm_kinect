using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCloud : MonoBehaviour
{
    public int rayAngle = 10;
    public int maxDistance = 12;
    public DepthTexture drawer;

    private ushort[,] pointsTab; 
    private int width;
    private int height;   

    // Use this for initialization
    void Start()
    {
        width = Camera.main.pixelWidth / rayAngle;
        height = Camera.main.pixelHeight / rayAngle;
        pointsTab = new ushort[width, height];
    }

    // Update is called once per frame
    void Update()
    {  
        RaycastHit hit;
        
        for (int i = 0, x = 0; x < width; i += rayAngle, x++)
        {
            for (int j = 0, y = 0; y < height ; j += rayAngle, y++)
            {
                pointsTab[x, y] = ushort.MaxValue;                
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(i, j));
                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    pointsTab[x, y] = (ushort)(hit.distance * ushort.MaxValue / maxDistance);
                }
            }            
        }   
       
        drawer.DrawDepthTexture(pointsTab);
        if(Input.GetKeyDown(KeyCode.I))
        {
            PGMGenerator.SaveMap(pointsTab);
        }
    }
}


