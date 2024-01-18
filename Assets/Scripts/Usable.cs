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

    public bool isaprooved=false;
    public bool isdenyed= false;

    
    public SpriteRenderer render;
   

    //public TextMeshPro textCode;
    public TextMeshPro textSex;
    public TextMeshPro textCity;
    public TextMeshPro textDate;
    public TextMeshPro textCode;
    public TextMeshPro textName;


    private BoxCollider2D bc;

    SpriteRenderer spr;
    void Start()
    {
        
        RandomPassport();
        spr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }
    
     
    private void OnMouseDrag()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

    }
    
    
    
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


        if (isdenyed)
        {
            
            render.color = Color.red;
        }
        if (isaprooved)
        {
            
            render.color = Color.green;

        }
        
        
        
    }
    void ShowText(bool doShow)
    {
        // kad ant uzdaryto paso nerodytu teksto
        if (doShow)
        {
            textCity.enabled = true;
            textDate.enabled = true;
            textSex.enabled = true;
            textCode.enabled = true;
            textName.enabled = true;
            render.enabled = true;

        }
        else
        {
            textCity.enabled = false;
            textDate.enabled = false;
            textSex.enabled = false;
            textCode.enabled = false;
            textName.enabled = false;
            render.enabled = false;
            
        }
    }
    void RandomPassport()
    {
        //kuriami atsitiktiniai duomenys pasui
        int rngS = Random.Range(0, 10);
        int rngC = Random.Range(0, 3);
        int rngD = Random.Range(0,35);
        int rngN = Random.Range(0,3);
        int rngT = Random.seed *-1;

        
        

        if (rngS >= 5f) textSex.text = "M";
        else textSex.text = "F";

        if (rngC == 0) textCity.text = "Miestas1";
        else if (rngC == 1) textCity.text = "Miestas2";
        else if (rngC == 2) textCity.text = "Miestas3";

        if (rngD>30f)
        {
            var temporry = rngD - 30f;
            textDate.text = "1999.07.0" +temporry;
        }
        else
        {
            if (rngD>10)
            {
                textDate.text = "1999.06." + rngD;
            }
            else
            {
                textDate.text = "1999.06.0" + rngD;
            }
            
        }
        textCode.text = rngT.ToString();
        //textName no workey
        if (rngN == 0)
        {
            textName.text = "vardas1";
        }
        else if (rngN == 1)
        {
            textName.text = "vardas2";
        }
        else
        {
            textName.text = "vardas3";
        }
    }
}