using UnityEngine;
using TMPro;

public class Usable : MonoBehaviour
{
    public float opeinningPoint;

    public Sprite closed;
    public float closedSize;
    public Sprite opend;
    public float opendSize;
    //public TextMeshPro textCode;
    public TextMeshPro textSex;
    public TextMeshPro textCity;
    public TextMeshPro textDate;

    SpriteRenderer spr;
    void Start()
    {
        RandomPassport();
        spr = GetComponent<SpriteRenderer>();
        
    }
    void Update()
    {
        
        if (transform.position.x>opeinningPoint)
        {
            transform.localScale = new Vector3(opendSize, opendSize, opendSize);
            spr.sprite = opend;
            ShowText(true);
        }
        else
        {
            transform.localScale = new Vector3(closedSize,closedSize,closedSize);
            spr.sprite = closed;
            ShowText(false);
        }
    }
    void ShowText(bool doShow)
    {
        if (doShow)
        {
            textCity.enabled = true;
            textDate.enabled = true;
            textSex.enabled = true;
        }
        else
        {
            textCity.enabled = false;
            textDate.enabled = false;
            textSex.enabled = false;
        }
    }
    void RandomPassport()
    {
        int rngS = Random.Range(0, 10);
        int rngC = Random.Range(0, 3);
        int rngD = Random.Range(0, 10);

        if (rngS >= 5f) textSex.text = "M";
        else textSex.text = "F";

        if (rngC == 0) textCity.text = "Miestas1";
        else if (rngC == 1) textCity.text = "Miestas2";
        else if (rngC == 2) textCity.text = "Miestas3";
        else textCity.text = "ERROR";
        print(rngC);
        // dar Date reikia

        

    }
}
