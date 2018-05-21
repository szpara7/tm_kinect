using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCloud : MonoBehaviour
{
    public int rayAngle = 10;
    public int maxDistance = 12;
    public DepthTexture drawer;

    private float[,] pointsTab; 
    private List<Vector3> pointList;
   

    // Use this for initialization
    void Start()
    {
       // pointList = new List<Vector3>();
        pointsTab = new float[Camera.main.pixelWidth / rayAngle, Camera.main.pixelHeight / rayAngle];
    }

    // Update is called once per frame
    void Update()
    {  
        RaycastHit hit;
       // pointList.Clear();
        
        for (int i = 0, x = 0; x < pointsTab.GetLength(0); i += rayAngle, x++)
        {
            for (int j = 0, y = 0; y < pointsTab.GetLength(1) ; j += rayAngle, y++)
            {
                pointsTab[x, y] = 0;
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(i, j));
                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    pointsTab[x,y] = hit.distance;
                   // pointList.Add(hit.point);
                }
            }
        }
        drawer.DrawDepthTexture(pointsTab, maxDistance);
    }
    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     if (pointList != null)
    //     {
    //         foreach (var i in pointList)
    //         {
    //             Gizmos.DrawSphere(i, 0.01f);
    //         }
    //     }
    // }
}
