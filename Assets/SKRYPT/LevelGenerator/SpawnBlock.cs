using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] Jungle;
    public GameObject[] JungleCorner;
    public GameObject[] JungleGrzes2;
    public GameObject[] JungleGrzes1;
    public GameObject[] JungleGrzes1a;
    public GameObject[] JungleGrzesD;
    public GameObject[] JungleGrzesC;
    public GameObject[] JungleGrzesB;
    public GameObject[] JungleGrzes3;
    public GameObject[] JungleGrzes0a;
    public GameObject[] JungleGrzes0b;
    public GameObject[] JungleGrzes0c;

    


    public GameObject[] Gods;
    public GameObject[] GodsCorner;

    public GameObject[] Underground;
    public GameObject[] UndergroundCorner;
    public GameObject[] UndergroundGrzes2;
    public GameObject[] UndergroundGrzes1;
    public GameObject[] UndergroundGrzes1a;
    public GameObject[] UndergroundGrzesD;
    public GameObject[] UndergroundGrzesC;
    public GameObject[] UndergroundGrzesB;
    public GameObject[] UndergroundGrzes3;
    public GameObject[] UndergroundGrzes0a;
    public GameObject[] UndergroundGrzes0b;
    public GameObject[] UndergroundGrzes0c;


    public GameObject[] Sky;
    public GameObject[] SkyCorner;
    public GameObject[] SkyGrzes2;
    public GameObject[] SkyGrzes1;
    public GameObject[] SkyGrzes1a;
    public GameObject[] SkyGrzesD;
    public GameObject[] SkyGrzesC;
    public GameObject[] SkyGrzesB;
    public GameObject[] SkyGrzes3;
    public GameObject[] SkyGrzes0a;
    public GameObject[] SkyGrzes0b;
    public GameObject[] SkyGrzes0c;

    public GameObject Klocek;
    public GameObject KlocekNiebo;
    
    public LayerMask floor;

    public float range;
    public bool[] Hit = new bool [10];

    bool corner=false;
    bool klocek = false; 
    bool grzes2 = false;
    bool grzes1 = false;
    bool grzes1a = false;
    bool grzesD = false;
    bool grzesC = false;
    bool grzesB = false;
    bool grzes3 = false;
    bool grzes0a = false;
    bool grzes0b = false;
    bool grzes0c = false;



    public int Level=1;
    public int Magnitude;
    Vector3 myVector;
    Vector3 myVector1;
    Vector3 myVector2;
    Vector3 myVector3;
    Quaternion spawnRotation;

    private void Start()
    {

        Level = GameController.instance.DataStorage.PlayerInfo.level;

        Wektors();
        Rotacja();


        if ( transform.position.y > 390 )
        {
            Magnitude = 1;
        }
        else if (transform.position.y < -10 )
        {
            Magnitude = 4;
        }
        else
        {
            Magnitude = 2;
        }




        if (Level==0|| Level==1) //// podziemie ///// 
        {
            if ( Magnitude==4)
            {
                if ( corner == true)
                {
                    int rand = Random.Range(0, UndergroundCorner.Length);
                    if (UndergroundCorner.Length != 0)
                    {
                        if(UndergroundCorner[rand] != null)
                        {
                        Instantiate(UndergroundCorner[rand], transform.position, spawnRotation,transform);
                        
                        }
                    }
                }
                else if ( klocek == true)
                {
                    Instantiate(Klocek, transform.position, spawnRotation,transform);
                }
                else if ( grzes2 ==true)
                {               
                    Instantiate(UndergroundGrzes2[Random.Range(0, UndergroundGrzes2.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes1 ==true)
                {
                    Instantiate(UndergroundGrzes1[Random.Range(0, UndergroundGrzes1.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesD ==true)
                {
                    Instantiate(UndergroundGrzesD[Random.Range(0, UndergroundGrzesD.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesC ==true)
                {
                    Instantiate(UndergroundGrzesC[Random.Range(0, UndergroundGrzesC.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesB ==true)
                {
                   Instantiate(UndergroundGrzesB[Random.Range(0, UndergroundGrzesB.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes1a ==true)
                {
                    Instantiate(UndergroundGrzes1a[Random.Range(0, UndergroundGrzes1a.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes0b ==true)
                {
                    Instantiate(UndergroundGrzes0b[Random.Range(0, UndergroundGrzes0b.Length)], transform.position, spawnRotation,transform);             
                }
                else if ( grzes0a ==true)
                { 
                    Instantiate(UndergroundGrzes0a[Random.Range(0, UndergroundGrzes0a.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes3 ==true)
                { 
                    Instantiate(UndergroundGrzes3[Random.Range(0, UndergroundGrzes3.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes0c ==true)
                { 
                    Instantiate(UndergroundGrzes0c[Random.Range(0, UndergroundGrzes0c.Length)], transform.position, spawnRotation,transform);
                }
                else 
                {
                    int rand = Random.Range(0, Underground.Length);
                    if (Underground.Length != 0)
                    {
                        if(Underground[rand] != null)
                        {
                        Instantiate(Underground[rand], transform.position, spawnRotation,transform);
                        }
                    }
                }
            }



            if ( Magnitude == 3 || Magnitude == 2 ) //// jungle /////
            {
               if ( corner == true)
                {
                    int rand = Random.Range(0, JungleCorner.Length);
                    if (JungleCorner.Length != 0)
                    {
                        if(JungleCorner[rand] != null)
                        {
                        Instantiate(JungleCorner[rand], transform.position, spawnRotation,transform);
                        
                        }
                    }
                }
                else if ( klocek == true)
                {
                    Instantiate(Klocek, transform.position, spawnRotation,transform);
                }
                else if ( grzes2 ==true)
                {               
                    Instantiate(JungleGrzes2[Random.Range(0, JungleGrzes2.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes1 ==true)
                {
                    Instantiate(JungleGrzes1[Random.Range(0, JungleGrzes1.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesD ==true)
                {
                    Instantiate(JungleGrzesD[Random.Range(0, JungleGrzesD.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesC ==true)
                {
                    Instantiate(JungleGrzesC[Random.Range(0, JungleGrzesC.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesB ==true)
                {
                   Instantiate(JungleGrzesB[Random.Range(0, JungleGrzesB.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes1a ==true)
                {
                    Instantiate(JungleGrzes1a[Random.Range(0, JungleGrzes1a.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes0b ==true)
                {
                    Instantiate(JungleGrzes0b[Random.Range(0, JungleGrzes0b.Length)], transform.position, spawnRotation,transform);             
                }
                else if ( grzes0a ==true)
                { 
                    Instantiate(JungleGrzes0a[Random.Range(0, JungleGrzes0a.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes3 ==true)
                { 
                    Instantiate(JungleGrzes3[Random.Range(0, JungleGrzes3.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes0c ==true)
                { 
                    Instantiate(JungleGrzes0c[Random.Range(0, JungleGrzes0c.Length)], transform.position, spawnRotation,transform);
                }
                else 
                {
                    int rand = Random.Range(0, Jungle.Length);
                    if (Jungle.Length != 0)
                    {
                        if(Jungle[rand] != null)
                        {
                        Instantiate(Jungle[rand], transform.position, spawnRotation,transform);
                        }
                    }
                }
                
            }


            if ( Magnitude == 1) /// niebo
            {
                if ( corner == true)
                {
                    int rand = Random.Range(0, SkyCorner.Length);
                    if (SkyCorner.Length != 0)
                    {
                        if(SkyCorner[rand] != null)
                        {
                        Instantiate(SkyCorner[rand], transform.position, spawnRotation,transform);
                        }
                    }
                }
                else if ( klocek == true)
                {
                    Instantiate(KlocekNiebo, transform.position, spawnRotation,transform);
                }
                else if ( grzes2 ==true)
                {               
                    Instantiate(SkyGrzes2[Random.Range(0, SkyGrzes2.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes1 ==true)
                {
                    Instantiate(SkyGrzes1[Random.Range(0, SkyGrzes1.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesD ==true)
                {
                    Instantiate(SkyGrzesD[Random.Range(0, SkyGrzesD.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesC ==true)
                {
                    Instantiate(SkyGrzesC[Random.Range(0, SkyGrzesC.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzesB ==true)
                {
                   Instantiate(SkyGrzesB[Random.Range(0, SkyGrzesB.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes1a ==true)
                {
                    Instantiate(SkyGrzes1a[Random.Range(0, SkyGrzes1a.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes0b ==true)
                {
                    Instantiate(SkyGrzes0b[Random.Range(0, SkyGrzes0b.Length)], transform.position, spawnRotation,transform);             
                }
                else if ( grzes0a ==true)
                { 
                    Instantiate(SkyGrzes0a[Random.Range(0, SkyGrzes0a.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes3 ==true)
                { 
                    Instantiate(SkyGrzes3[Random.Range(0, SkyGrzes3.Length)], transform.position, spawnRotation,transform);
                }
                else if ( grzes0c ==true)
                { 
                    Instantiate(SkyGrzes0c[Random.Range(0, SkyGrzes0c.Length)], transform.position, spawnRotation,transform);
                }
                else 
                {
                    int rand = Random.Range(0, Sky.Length);
                    if (Sky.Length != 0)
                    {
                        if(Sky[rand] != null)
                        {
                        Instantiate(Sky[rand], transform.position, spawnRotation,transform);
                        }
                    }
                }
            }
        }
        else  if ( Level ==2 ) // bogowie
        {
            
            if ( Magnitude == 1) /// niebo
            {
                if ( corner == true)
                {
                    int rand = Random.Range(0, SkyCorner.Length);
                    if (SkyCorner.Length != 0)
                    {
                        if(SkyCorner[rand] != null)
                        {
                        Instantiate(SkyCorner[rand], transform.position, spawnRotation,transform);
                        }
                    }
                }
                else if ( klocek == true)
                {
                    Instantiate(KlocekNiebo, transform.position, spawnRotation,transform);
                }
                else 
                {
                    int rand = Random.Range(0, Sky.Length);
                    if (Sky.Length != 0)
                    {
                        if(Sky[rand] != null)
                        {
                        Instantiate(Sky[rand], transform.position, spawnRotation,transform);
                        }
                    }
                }
            }
            
            else 
            {
                int rand = Random.Range(0, Gods.Length);
                if (Gods.Length != 0)
                {
                    if(Gods[rand] != null)
                    {
                    Instantiate(Gods[rand], transform.position, spawnRotation,transform);
                    }
                }
            }



        }
    }
    private void Rotacja()
    {
        // normalne
         if (Hit[1]==false && Hit[3]==true && Hit[5]==true && Hit[7]==true && Hit[4]==true && Hit[6]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             return;
         }
         else if (Hit[1]==true && Hit[3]==false && Hit[5]==true && Hit[7]==true &&  Hit[6]==true && Hit[8]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,270);
             return;
         }
          else if (Hit[1]==true && Hit[3]==true && Hit[5]==false && Hit[7]==true &&  Hit[2]==true && Hit[8]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,180);
             return;
         }
         else if (Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==false &&  Hit[4]==true && Hit[2]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,90);
             return;
         }
         // cornery 
         if (Hit[2]==false && Hit[4]==true && Hit[6]==true && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             corner = true;
             return;
         }
         else if (Hit[2]==true && Hit[4]==false && Hit[6]==true && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,270);
             corner = true;
             return;
         }
         else if (Hit[2]==true && Hit[4]==true && Hit[6]==false && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,180);
             corner = true;
             return;
         }
         else if (Hit[2]==true && Hit[4]==true && Hit[6]==true && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,90);
             corner = true;
             return;
         }
         // klocek 
         else if (Hit[2]==true && Hit[4]==true && Hit[6]==true && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             klocek = true;
             return;
         }
        // grzes 2 
        else if (Hit[1]==false  && Hit[3]==true && Hit[5]==false && Hit[7]==true )
        {
            spawnRotation = Quaternion.Euler(0,0,0);
            grzes2 = true; 
            return; 
        }
        else if (Hit[1]==true  && Hit[3]==false && Hit[5]==true && Hit[7]==false )
        {
            spawnRotation = Quaternion.Euler(0,0,90);
            grzes2 = true; 
            return ;
        }

        // grzes 1
        else if (Hit[1]==false  && Hit[2]==false && Hit[3]==false  && Hit[6]==true    && Hit[5]==true && Hit[7]==true )
        {
            spawnRotation = Quaternion.Euler(0,0,0);
            grzes1 = true; 
            return ;
        }
        else if (Hit[4]==false  && Hit[8]==true && Hit[1]==true  && Hit[3]==false && Hit[5]==false && Hit[7]==true )
        {
            spawnRotation = Quaternion.Euler(0,0,270);
            grzes1 = true; 
            return ;
        }
        else if (Hit[2]==true  && Hit[6]==false && Hit[1]==true  && Hit[3]==true && Hit[5]==false && Hit[7]==false )
        {
            spawnRotation = Quaternion.Euler(0,0,180);
            grzes1 = true; 
            return ;
        }
        else if ( Hit[4]==true  && Hit[8]==false && Hit[1]==false  && Hit[3]==true && Hit[5]==true && Hit[7]==false )
        {
            spawnRotation = Quaternion.Euler(0,0,90);
            grzes1 = true; 
            return ;
        }
        // grzes C
        else if (Hit[2]==false && Hit[4]==false && Hit[6]==false && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzesC = true;
             return;
         }
         else if (Hit[2]==true && Hit[4]==false && Hit[6]==false && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,270);
             grzesC = true;
             return;
         }
         else if (Hit[2]==false && Hit[4]==true && Hit[6]==false && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,180);
             grzesC = true;
             return;
         }
         else if (Hit[2]==false && Hit[4]==false && Hit[6]==true && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,90);
             grzesC = true;
             return;
         }
         else if (Hit[2]==false && Hit[4]==false && Hit[6]==false && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzesC = true;
             return;
         }
         ///grzesB
         else if (Hit[2]==false && Hit[4]==true && Hit[6]==false && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzesB = true;
             return;
         }
         else if (Hit[2]==true && Hit[4]==false && Hit[6]==true && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,90);
             grzesB = true;
             return;
         }
         
         //brakuje grzes0a  grzes 3 grzesC 
         // grzes1a
        else if (Hit[2]==false  && Hit[6]==false  && Hit[1]==false && Hit[3]==false && Hit[5]==true && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzes1a = true;
             return;
         }
         else if (Hit[4]==false  && Hit[8]==false && Hit[1]==true && Hit[3]==false && Hit[5]==false && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,270);
             grzes1a = true;
             return;
         }
         else if (Hit[2]==false &&  Hit[6]==false  && Hit[1]==true && Hit[3]==true && Hit[5]==false && Hit[7]==false)
         {
             spawnRotation = Quaternion.Euler(0,0,180);
             grzes1a = true;
             return;
         }
         else if (Hit[4]==false  && Hit[8]==false && Hit[1]==false && Hit[3]==true && Hit[5]==true && Hit[7]==false )
         {
             spawnRotation = Quaternion.Euler(0,0,90);
             grzes1a = true;
             return;
         }

         // grzes 0b
          if (Hit[1]==false && Hit[3]==true && Hit[5]==true && Hit[7]==true  && Hit[4]==false && Hit[6]==false    )
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzes0b = true;
             return;
         }
         else if (Hit[1]==true && Hit[3]==false && Hit[5]==true && Hit[7]==true &&  Hit[6]==false && Hit[8]==false)
         {
             spawnRotation = Quaternion.Euler(0,0,270);
            grzes0b = true;

             return;
         }
          else if (Hit[1]==true && Hit[3]==true && Hit[5]==false && Hit[7]==true && Hit[2]==false && Hit[8]==false)
         {
             spawnRotation = Quaternion.Euler(0,0,180);
            grzes0b = true;

             return;
         }
         else if (Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==false && Hit[2]==false && Hit[4]==false )
         {
             spawnRotation = Quaternion.Euler(0,0,90);
            grzes0b = true;

             return;
         }
         // klocek 
        //brakuje grzes0a  grzes 3 grzesC grzec0c
        if (Hit[1]==false && Hit[3]==true && Hit[5]==true && Hit[7]==true && Hit[4]==true && Hit[6]==false)
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzes0a=true;
             return;
         }
         else if (Hit[1]==false && Hit[3]==true && Hit[5]==true && Hit[7]==true && Hit[4]==false && Hit[6]==true)
         {
             spawnRotation = Quaternion.Euler(0,180,0);
             grzes0a=true;
             return;
         }


         else if (Hit[1]==true && Hit[3]==false && Hit[5]==true && Hit[7]==true &&  Hit[6]==true && Hit[8]==false)
         {
             spawnRotation = Quaternion.Euler(0,0,270);
             grzes0a=true;
             return;
         }

        else if (Hit[1]==true && Hit[3]==false && Hit[5]==true && Hit[7]==true &&  Hit[6]==false && Hit[8]==true)
         {
             spawnRotation = Quaternion.Euler(180,0,270);
             grzes0a=true;
             return;
         }

          else if (Hit[1]==true && Hit[3]==true && Hit[5]==false && Hit[7]==true &&  Hit[2]==false && Hit[8]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,180);
             grzes0a=true;
             return;
         }

         else if (Hit[1]==true && Hit[3]==true && Hit[5]==false && Hit[7]==true &&  Hit[2]==true && Hit[8]==false)
         {
             spawnRotation = Quaternion.Euler(180,0,0);
             grzes0a=true;
             return;
         }

         else if (Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==false &&  Hit[4]==false && Hit[2]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,90);
             grzes0a=true;
             return;
         }

         
         else if (Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==false &&  Hit[4]==true && Hit[2]==false )
         {
             spawnRotation = Quaternion.Euler(180,0,90);
             grzes0a=true;
             return;
         }
        // grzes 3
        else if(Hit[1]==false && Hit[3]==false && Hit[5]==true  && Hit[7]==false )
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzes3 = true;
             return;
         }
        else if(Hit[1]==false && Hit[3]==false && Hit[5]==false && Hit[7]==true )
          {
             spawnRotation = Quaternion.Euler(0,0,270);
             grzes3 = true;
             return;
         }
        else if(  Hit[1]==true && Hit[3]==false && Hit[5]==false && Hit[7]==false )
          {
             spawnRotation = Quaternion.Euler(0,0,180);
             grzes3 = true;
             return;
         }
        else if( Hit[1]==false && Hit[3]==true && Hit[5]==false && Hit[7]==false )
          {
             spawnRotation = Quaternion.Euler(0,0,90);
             grzes3 = true;
             return;
         }
         //brakuje     grzec0c
        else if(Hit[1]==true && Hit[2]==true && Hit[3]==true && Hit[4]==false && Hit[5]==true && Hit[6]==false && Hit[7]==true  && Hit[8]==true  )
        {
           spawnRotation = Quaternion.Euler(0,0,0);
             grzes0c = true;
             return; 
        }
         else if(Hit[1]==true && Hit[2]==false && Hit[3]==true && Hit[4]==false && Hit[5]==true && Hit[6]==true && Hit[7]==true  && Hit[8]==true  )
        {
           spawnRotation = Quaternion.Euler(0,0,90);
             grzes0c = true;
             return; 
        }
         else if(Hit[1]==true && Hit[2]==false && Hit[3]==true && Hit[4]==true && Hit[5]==true && Hit[6]==true && Hit[7]==true  && Hit[8]==false  )
        {
           spawnRotation = Quaternion.Euler(0,0,180);
             grzes0c = true;
             return; 
        }
         else if(Hit[1]==true && Hit[2]==true && Hit[3]==true && Hit[4]==true && Hit[5]==true && Hit[6]==false && Hit[7]==true  && Hit[8]==false  )
        {
           spawnRotation = Quaternion.Euler(0,0,270);
             grzes0c = true;
             return; 
        }
    }
    private void Wektors()
    {
        if (Physics2D.Raycast(transform.position,Vector3.up , range,floor))
        {
            Hit[1]=true;
        }
        else
        {
            Hit[1]=false;
        }
        if (Physics2D.Raycast(transform.position, myVector = new Vector3(0.5f, 0.5f, 0.0f), range, floor))
        {
            Hit[2] = true;
        }
        else
        {
            Hit[2] = false;
        }
        if (Physics2D.Raycast(transform.position, Vector3.right, range, floor))
        {
            Hit[3] = true;
        }
        else
        {
            Hit[3] = false; 
        }
        if (Physics2D.Raycast(transform.position, myVector1 = new Vector3(0.5f, -0.5f, 0.0f), range, floor))
        {
            Hit[4] = true;
        }
        else
        {
            Hit[4] = false;
        }
        if (Physics2D.Raycast(transform.position, Vector3.down, range, floor))
        {
            Hit[5] = true;
        }
        else
        {
            Hit[5] = false;
        }
        if (Physics2D.Raycast(transform.position, myVector2 = new Vector3(-0.5f, -0.5f, 0.0f), range, floor))
        {
            Hit[6] = true;
        }
        else
        {
            Hit[6] = false;
        }
        if (Physics2D.Raycast(transform.position, Vector3.left, range, floor))
        {
            Hit[7] = true;
        }
        else
        {
            Hit[7] = false;
        }
        if (Physics2D.Raycast(transform.position, myVector3 = new Vector3(-0.5f, 0.5f, 0.0f), range, floor))
        {
            Hit[8] = true;
        }
        else
        {
            Hit[8] = false;
        }

    }

   // [ContextMenu("Reset")]
    public void Restart()
    {
        Start();
    }
}
