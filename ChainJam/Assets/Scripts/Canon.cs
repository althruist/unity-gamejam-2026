using UnityEngine;

public class Canon : MonoBehaviour
{


    void Update()
    {
        PointAtMouse();
    }


        


    public void PointAtMouse()
    {

        Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f); ;


        mousePos.z = transform.position.z;


        transform.up = mousePos - transform.position;
    }

}
