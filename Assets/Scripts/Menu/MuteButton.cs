using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    
    //public AudioSource audio;
    bool isOn = true;

    private void OnMouseDown()
    {
        if (isOn)
        {
            //audio.Stop();
            print("no sound");
        }
        else
        {
            //audio.Play();
            print("yes sound");
        }
        isOn = !isOn;
    }
}
