using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main class which calculates collisions, draw texture and save it
/// </summary>
public class PointCloud : MonoBehaviour
{
    /// <summary>
    /// Frequency of sending rays
    /// </summary>
    public int rayAngle = 10;

    /// <summary>
    /// Max distance to object
    /// </summary>
    public int maxDistance = 12;

    /// <summary>
    /// Texture drawer on runtime in the lower right area of the camera
    /// </summary>
    public DepthTexture drawer;

    /// <summary>
    /// Array stores ray distance
    /// </summary>
    private ushort[,] pointsTab;

    /// <summary>
    /// Width of the camera
    /// </summary>
    private int width;

    /// <summary>
    /// Height of the camera
    /// </summary>
    private int height;

    /// <summary>
    /// Initialization function 
    /// </summary>
    void Start()
    {
        width = Camera.main.pixelWidth / rayAngle;
        height = Camera.main.pixelHeight / rayAngle;
        pointsTab = new ushort[width, height];
    }

    /// <summary>
    /// Function updated once per frame
    /// </summary>
    void Update()
    {
        RaycastHit hit;
        for (int i = 0, x = 0; x < width; i += rayAngle, x++)
        {
            for (int j = 0, y = 0; y < height; j += rayAngle, y++)
            {
                pointsTab[x, y] = ushort.MaxValue;
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(i, j));
                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    float angle = Vector3.Angle(hit.transform.position - Camera.main.transform.position, Camera.main.transform.right);
                    if (angle > 90) angle = 180 - angle;
                    pointsTab[x, y] = (ushort)((hit.distance * System.Math.Sin((angle * Mathf.PI) / 180)) * ushort.MaxValue / maxDistance);
                }
            }
        }
        drawer.DrawDepthTexture(pointsTab);
        if (Input.GetKeyDown(KeyCode.I))
        {
            PGMGenerator.SaveMap(pointsTab);
        }
    }
}


