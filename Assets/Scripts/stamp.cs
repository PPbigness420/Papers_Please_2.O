using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stamp : MonoBehaviour
{
    bool isextended = false;
    public float distance;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (!isextended)
        {
            transform.position = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }
        isextended = !isextended;
    }
}
