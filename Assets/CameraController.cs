using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for controlling the camera
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Field specyfying how fast the camera move
    /// </summary>
    public float speed;

    /// <summary>
    /// Function updated once per frame which controlling the camera
    /// </summary>
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float mouseVertical = Input.GetAxis("Mouse Y");
        float mouseHorizontal = Input.GetAxis("Mouse X");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * speed);
        transform.Rotate(mouseVertical, mouseHorizontal, 0);
    }
}
