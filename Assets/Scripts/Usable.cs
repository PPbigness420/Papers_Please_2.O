using UnityEngine;
using TMPro;

public class Usable : MonoBehaviour
{
    //reiketu pervadint i passport
    public float opeinningPoint;

    public Sprite closed;
    public float closedSize;
    public Sprite opend;
    public float opendSize;
    //public TextMeshPro textCode;
    public TextMeshPro textSex;
    public TextMeshPro textCity;
    public TextMeshPro textDate;


    private BoxCollider2D bc;

    SpriteRenderer spr;
    void Start()
    {
        RandomPassport();
        spr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        
    }
    /*
     * reikia normalu mouse pos gaut kad veiktu
    private void OnMouseDrag()
    {
        transform.position = new Vector3(Input.mousePosition.x- bc.bounds.size.x, Input.mousePosition.y- bc.bounds.size.y, 0f);
        
    }
    */
    
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        //kad pasas atidarytu, uzsidarytu jei yra tam tikroje vietoje
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
        //int rngD = Random.Range(0, 10);

        if (rngS >= 5f) textSex.text = "M";
        else textSex.text = "F";

        if (rngC == 0) textCity.text = "Miestas1";
        else if (rngC == 1) textCity.text = "Miestas2";
        else if (rngC == 2) textCity.text = "Miestas3";
        // dar Date ir code reikia
    }
}
