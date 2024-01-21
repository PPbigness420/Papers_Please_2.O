using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshPro clock;

    float timeMin=0;
    public int timeHor=8;
    bool isDayOver=false;
    public float shift;
    float aproxmin;
    
    private void Update()
    {
        timeMin += Time.deltaTime;
        aproxmin = Mathf.Ceil(timeMin);
      
        if (aproxmin >=60)
        {
            timeHor += 1;
            timeMin = 0;
            aproxmin = 0;
        }

        
        if (timeHor < 10)
        {
            if (aproxmin<10)
            {
                clock.text = "0" + timeHor.ToString() + ":0" + aproxmin.ToString();
            }
            else
            {
                clock.text = "0" + timeHor.ToString() + ":" + aproxmin.ToString();
            }
            
        }
        else
        {
            if (aproxmin < 10)
            {
                clock.text = timeHor.ToString() + ":0" + aproxmin.ToString();
            }
            else
            {
                clock.text =  timeHor.ToString() + ":" + aproxmin.ToString();
            }
        }


        if (timeHor >= shift)
        {
            isDayOver = true;
        }
    }
}
