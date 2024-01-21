using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampNo : MonoBehaviour
{
    //gamemanager gali pasakyti koki passport duoda or smth
    public Usable passport;
    public void OnMouseDown()
    {
        
            passport.isaprooved = !passport.isaprooved;
            passport.isdenyed = false;


    }
}
