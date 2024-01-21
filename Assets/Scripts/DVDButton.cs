using UnityEngine;

public class DVDButton : MonoBehaviour
{
    public GameObject gameplay;
    public AudioSource music;
    bool isOn=false;
    private void OnMouseDown()
    {
        if (!isOn)
        {
            gameplay.gameObject.SetActive(true);
            music.Pause();
            isOn = !isOn;
        }
        else
        {
            gameplay.gameObject.SetActive(false);
            music.UnPause();
            isOn = !isOn;
        }
        print(isOn);
    }
}
