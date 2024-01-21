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

    public bool canGive;
    public bool isDropped;

    
    public SpriteRenderer aprovedArt;
    public SpriteRenderer denyedArt;

    //Give Pop Up
    public GameObject popup;



    //public TextMeshPro textCode;
    public TextMeshPro textSex;
    public TextMeshPro textCity;
    public TextMeshPro textDate;
    public TextMeshPro textCode;
    public TextMeshPro textName;
    public SpriteRenderer photo;
    public GameObject photoObj;


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

    private void OnMouseUp()
    {
        isDropped = true;
    }

    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        if (isdenyed)
        {
            aprovedArt.enabled = false;
            denyedArt.enabled = true;

        }
        else if (isaprooved)
        {
            aprovedArt.enabled = true;
            denyedArt.enabled = false;

        }

        //kad pasas atidarytu, uzsidarytu jei yra tam tikroje vietoje
        if (transform.position.x>opeinningPoint)
        {
            transform.localScale = new Vector3(opendSize, opendSize, opendSize);
            spr.sprite = opend;
            ShowText(true);
            popup.gameObject.SetActive(false);
        }
        else
        {
            transform.localScale = new Vector3(closedSize,closedSize,closedSize);
            spr.sprite = closed;
            ShowText(false);
            if (canGive)
            {
                popup.gameObject.SetActive(true);
            }
            else
            {
                popup.gameObject.SetActive(false);
            }

        }
        if (isDropped)
        {
            Invoke("DropCoold",0.001f);
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
            photoObj.gameObject.SetActive(true);
            if (isdenyed)
            {
                aprovedArt.enabled = false;
                denyedArt.enabled = true;
            }
            else if (isaprooved)
            {
                aprovedArt.enabled = true;
                denyedArt.enabled = false;
            }

        }
        else
        {
            textCity.enabled = false;
            textDate.enabled = false;
            textSex.enabled = false;
            textCode.enabled = false;
            textName.enabled = false;
            denyedArt.enabled = false;
            aprovedArt.enabled = false;
            photoObj.gameObject.SetActive(false);
        }
    }
    public void RandomPassport()
    {
        //kuriami atsitiktiniai duomenys pasui
        int rngS = Random.Range(0, 10);
        int rngC = Random.Range(0, 3);
        int rngD = Random.Range(0,38);
        int rngN = Random.Range(0,3);
        int rngT= Random.seed;
        if (rngT<0)
        {
            rngT *= -1;
        }

        
        

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

    public void DropCoold()
    {
        isDropped = false;
    }
}