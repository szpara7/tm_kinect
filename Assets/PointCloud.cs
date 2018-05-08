using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCloud : MonoBehaviour
{

    private int rayAngle = 20;
    private List<Vector3> pointList;
    // Use this for initialization
    void Start()
    {
        pointList = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        pointList.Clear();
        for (int i = 0; i < Camera.main.pixelWidth - 1; i += rayAngle)
        {
            for (int j = 0; j < Camera.main.pixelHeight - 1; j += rayAngle)
            {
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(i, j));
                if (Physics.Raycast(ray, out hit))
                {
                    // Debug.DrawLine(ray.origin, hit.point, Color.red, 1);
                    pointList.Add(hit.point);
                }
            }

        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (pointList != null)
        {
            foreach (var i in pointList)
            {
                Gizmos.DrawSphere(i, 0.01f);
            }
        }
    }
}
