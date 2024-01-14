using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InscpectButton : MonoBehaviour
{
    bool inspect=false;
    Vector2 ogSize;

    public BoxCollider2D passportCol;
    public GameObject darken;


    private void Start()
    {
        ogSize = passportCol.size;
    }


    private void OnMouseDown()
    {
        if (!inspect)
        {
            passportCol.size = Vector2.zero;
            darken.SetActive(true);
        }
        else
        {
            passportCol.size = ogSize;
            darken.SetActive(false);
        }
        inspect = !inspect;
    }
}
