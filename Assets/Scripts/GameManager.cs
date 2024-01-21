using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform passPos;
    public Usable passport;

    public Sprite sprtieRedC;
    public Sprite sprtieBlueC;
    public Sprite sprtieYellowC;

    public Sprite sprtieRedO;
    public Sprite sprtieBlueO;
    public Sprite sprtieYellowO;

    public SpriteRenderer boothFace;

    

    public Sprite faceM;
    public Sprite faceM_BNW;
    public Sprite faceF;
    public Sprite faceF_BNW;



    public bool wasGiven;
    public Transform spawnPos;
    public Transform hidePos;

    public Clock time;

    int rnd;

    //random tv info

    int tvrnd;
    public TextMeshPro tvN;
    public TextMeshPro tvS;
    public TextMeshPro tvT;
    public TextMeshPro tvC;
    public TextMeshPro tvD;
    private bool N;
    private bool S;
    private bool T;
    private bool C;
    private bool D;


    public TextMeshPro score;

    public int cor=0;
    public int wrong=0;



    private void Start()
    {
        passport.textSex.text = "M";
    }


    void Update()
    {
        if (time.timeHor >= time.shift)
        {
            SceneManager.LoadScene("GameEnd");
        }
        if (wasGiven)
        {
            if (N && S && T && C && D && passport.isaprooved)
            {
                cor += 1;
            }
            else if ((!N || !S || !T || !C || !D) && passport.isdenyed ) 
            {
                cor += 1;
            }
            else
            {
                wrong += 1;
            }
            score.text = "Corret: " + cor.ToString() + " Wrong: " + wrong.ToString();


            boothFace.sortingOrder = -20;
            ResetPass();
            wasGiven = false;
            passPos = hidePos;
            Invoke("ShowUp",1f);
            
        }
    }
    void ResetPass()
    {
        passPos = hidePos;
        passport.isaprooved = false;
        passport.isdenyed = false;
        passport.RandomPassport();
        rnd = Random.Range(1,4);
        if (rnd==1)
        {
            passport.opend = sprtieRedO;
            passport.closed = sprtieRedC;
        }
        else if (rnd == 2)
        {
            passport.opend = sprtieBlueO;
            passport.closed = sprtieBlueC;
        }
        else
        {
            passport.opend = sprtieYellowO;
            passport.closed = sprtieYellowC;
        }
    
    }
    void ShowUp()
    {
        passPos = spawnPos;
        boothFace.sortingOrder = -1;
        if (passport.textSex.text == "M")
        {
            passport.photo.sprite = faceM_BNW;
            boothFace.sprite = faceM;
        }
        else
        {
            passport.photo.sprite = faceF_BNW;
            boothFace.sprite = faceF;
        }

    }

    void GenerateTV()
    {
        tvrnd = Random.Range(0,11);
        if (tvrnd<=5)
        {
            //viskas ok
            tvN.text = passport.textName.text;
            N = true;
            tvS.text = passport.textSex.text;
            S = true;
            tvT.text = passport.textCity.text;
            T = true;
            tvC.text = passport.textCode.text;
            C = true;
            tvD.text = passport.textDate.text;
            D = true;
        }
        else
        {
            //fake
            if (tvrnd == 6)
            {
                //name
                while (passport.textName.text == tvN.text)
                {
                    var rand = Random.Range(0, 3);
                    if (rand == 0)
                    {
                        tvN.text = "vardas1";
                    }
                    else if (rand == 1)
                    {
                        tvN.text = "vardas2";
                    }
                    else
                    {
                        tvN.text = "vardas3";
                    }
                }
                N = false;
                tvS.text = passport.textSex.text;
                S = true;
                tvT.text = passport.textCity.text;
                T = true;
                tvC.text = passport.textCode.text;
                C = true;
                tvD.text = passport.textDate.text;
                D = true;
            }
            else if (tvrnd == 7)
            {
                //sex
                tvN.text = passport.textName.text;
                N = true;

                if (passport.textSex.text == "M")
                {
                    passport.textSex.text = "F";
                }
                else
                {
                    passport.textSex.text = "M";
                }

                S = false;
                tvT.text = passport.textCity.text;
                T = true;
                tvC.text = passport.textCode.text;
                C = true;
                tvD.text = passport.textDate.text;
                D = true;
            }
            else if (tvrnd == 8)
            {
                //city
                tvN.text = passport.textName.text;
                N = true;
                tvS.text = passport.textSex.text;
                S = true;

                var rand = Random.Range(0, 3);

                while (tvT.text == passport.textCity.text)
                {
                    if (rand == 0) tvT.text = "Miestas1";
                    else if (rand == 1) tvT.text = "Miestas2";
                    else if (rand == 2) tvT.text = "Miestas3";
                }
                T = false;
                tvC.text = passport.textCode.text;
                C = true;

                tvD.text = passport.textDate.text;
                D = true;
            }
            else if (tvrnd == 9)
            {
                //code
                tvN.text = passport.textName.text;
                N = true;
                tvS.text = passport.textSex.text;
                S = true;
                tvT.text = passport.textCity.text;
                T = true;
                int rnd = Random.seed;
                if (rnd < 0)
                {
                    rnd *= -1;
                }
                tvC.text = rnd.ToString();
                C = false;

                tvD.text = passport.textDate.text;
                D = true;
            }
           
                
            
            
        }
    }

}
