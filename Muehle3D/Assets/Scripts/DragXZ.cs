using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragXZ : MonoBehaviour 
{
    Vector3 dist;
    Vector3 startPos;
    float posX;
    float posZ;
    float posY;


    public static Vector3 nextPos;
    Vector3 orgPos;


    void OnMouseDown()
    {
        startPos = transform.position;
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
        posZ = Input.mousePosition.z - dist.z;

        orgPos = transform.position;
    }

    void OnMouseDrag()
    {
        float disX = Input.mousePosition.x - posX;
        float disY = Input.mousePosition.y - posY;
        float disZ = Input.mousePosition.z - posZ;
        Vector3 lastPos = Camera.main.ScreenToWorldPoint(new Vector3(disX, disY, disZ));
        transform.position = new Vector3(lastPos.x, startPos.y, lastPos.z);
    }

    private void OnMouseUp()
    {
        if (Drop.colTrue == true)
        {
            transform.position = nextPos;
            Drop.colTrue = false;

        }
        else
        {
            transform.position = orgPos;
        }

    }
}
