using UnityEngine;

public class CanGive : MonoBehaviour
{
    public Transform realpos;
    public Usable passport;
    public GameManager game;
    
    Vector3 pos;

    private void Update()
    {
        //check if can drop
        pos = realpos.transform.position;
        if (pos.y> -2.5 && pos.x<-4.2)
        {
            passport.canGive = true;
        }
        else
        {
            passport.canGive = false;
        }
        if (passport.isDropped && passport.canGive)
        {
            game.wasGiven = true;
        }
    }
}
