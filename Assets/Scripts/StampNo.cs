using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampYes : MonoBehaviour
{
    //gamemanager gali pasakyti koki passport duoda or smth
    public Usable passport;
    public void OnMouseDown()
    {
        
            passport.isdenyed = !passport.isdenyed;
            passport.isaprooved = false;
    }
}
