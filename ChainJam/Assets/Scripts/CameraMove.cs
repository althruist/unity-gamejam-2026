using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float scrollSpeed = 10f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Move camera on X axis based on scroll
        transform.position += new Vector3(scroll * scrollSpeed, 0f, 0f);
    }
}