using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float scrollSpeed = 10f;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        float newX = Mathf.Clamp(transform.position.x + scroll * scrollSpeed, 0f,GameData.gridLenght-10);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}