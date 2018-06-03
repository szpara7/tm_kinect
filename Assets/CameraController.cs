using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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
