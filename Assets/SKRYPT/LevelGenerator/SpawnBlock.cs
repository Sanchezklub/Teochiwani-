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
    


    public GameObject[] Gods;
    public GameObject[] GodsCorner;

    public GameObject[] Underground;
    public GameObject[] UndergroundCorner;

    public GameObject[] Sky;
    public GameObject[] SkyCorner;

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




        if (Level==0) //// podziemie ///// 
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
                        GameObject obj = Instantiate(UndergroundCorner[rand], transform.position, spawnRotation);
                        obj.transform.parent = this.gameObject.transform;
                        }
                    }
                }
                else if ( klocek == true)
                {
                    GameObject obj = Instantiate(Klocek, transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;
                }
                else 
                {
                    int rand = Random.Range(0, Underground.Length);
                    if (Underground.Length != 0)
                    {
                        if(Underground[rand] != null)
                        {
                        GameObject obj = Instantiate(Underground[rand], transform.position, spawnRotation);
                        obj.transform.parent = this.gameObject.transform;
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
                        GameObject obj = Instantiate(JungleCorner[rand], transform.position, spawnRotation);
                        obj.transform.parent = this.gameObject.transform;
                        }
                    }
                }
                else if ( klocek == true)
                {
                    GameObject obj = Instantiate(Klocek, transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;
                }
                else if ( grzes2 ==true)
                {
                    
                    GameObject obj = Instantiate(JungleGrzes2[Random.Range(0, JungleGrzes2.Length)], transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;


                }
                else if ( grzes1 ==true)
                {
                    
                    GameObject obj = Instantiate(JungleGrzes1[Random.Range(0, JungleGrzes1.Length)], transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;


                }
                else if ( grzesD ==true)
                {
                    
                    GameObject obj = Instantiate(JungleGrzesD[Random.Range(0, JungleGrzesD.Length)], transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;


                }
                else if ( grzesB ==true)
                {
                    
                    GameObject obj = Instantiate(JungleGrzesB[Random.Range(0, JungleGrzesB.Length)], transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;


                }
                else if ( grzes1a ==true)
                {
                    
                    GameObject obj = Instantiate(JungleGrzes1a[Random.Range(0, JungleGrzes1a.Length)], transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;


                }
                else if ( grzes0b ==true)
                {
                    
                    GameObject obj = Instantiate(JungleGrzes0b[Random.Range(0, JungleGrzes0b.Length)], transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;


                }

                else 
                {
                    int rand = Random.Range(0, Jungle.Length);
                    if (Jungle.Length != 0)
                    {
                        if(Jungle[rand] != null)
                        {
                        GameObject obj = Instantiate(Jungle[rand], transform.position, spawnRotation);
                        obj.transform.parent = this.gameObject.transform;
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
                        GameObject obj = Instantiate(SkyCorner[rand], transform.position, spawnRotation);
                        obj.transform.parent = this.gameObject.transform;
                        }
                    }
                }
                else if ( klocek == true)
                {
                    GameObject obj = Instantiate(KlocekNiebo, transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;
                }
                else 
                {
                    int rand = Random.Range(0, Sky.Length);
                    if (Sky.Length != 0)
                    {
                        if(Sky[rand] != null)
                        {
                        GameObject obj = Instantiate(Sky[rand], transform.position, spawnRotation);
                        obj.transform.parent = this.gameObject.transform;
                        }
                    }
                }
            }
        }
        else  if ( Level ==2 ) // bogowie
        {
            if ( Magnitude == 1)
            {
                if ( corner == true)
                {
                    int rand = Random.Range(0, SkyCorner.Length);
                    if (SkyCorner.Length != 0)
                    {
                        if(SkyCorner[rand] != null)
                        {
                        GameObject obj = Instantiate(SkyCorner[rand], transform.position, spawnRotation);
                        obj.transform.parent = this.gameObject.transform;
                        }
                    }
                }
                else if ( klocek == true)
                {
                    GameObject obj = Instantiate(KlocekNiebo, transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;
                }
                else 
                {
                    int rand = Random.Range(0, Sky.Length);
                    if (Sky.Length != 0)
                    {
                        if(Sky[rand] != null)
                        {
                        GameObject obj = Instantiate(Sky[rand], transform.position, spawnRotation);
                        obj.transform.parent = this.gameObject.transform;
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
                    GameObject obj = Instantiate(Gods[rand], transform.position, spawnRotation);
                    obj.transform.parent = this.gameObject.transform;
                    }
                }
            }



        }
    }
    private void Rotacja()
    {
        // normalne
         if (Hit[1]==false && Hit[3]==true && Hit[5]==true && Hit[7]==true  )
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             return;
         }
         else if (Hit[1]==true && Hit[3]==false && Hit[5]==true && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,270);
             return;
         }
          else if (Hit[1]==true && Hit[3]==true && Hit[5]==false && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,180);
             return;
         }
         else if (Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==false)
         {
             spawnRotation = Quaternion.Euler(0,0,90);
             return;
         }

         // cornery 
         else if (Hit[2]==false && Hit[4]==true && Hit[6]==true && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true)
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
        else if (Hit[2]==false && Hit[4]==false && Hit[6]==true   && Hit[3]==false && Hit[5]==true && Hit[7]==true )
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
        // grzes d 
        else if (Hit[2]==false && Hit[4]==false && Hit[6]==false && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzesD = true;
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
         
         //brakuje grzes0a grzes0b grzes 3 grzesC i grzes 1a
         // grzes1a
        else if (Hit[2]==false && Hit[4]==true && Hit[6]==false && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,0);
             grzes1a = true;
             return;
         }
         else if (Hit[2]==true && Hit[4]==false && Hit[6]==true && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,270);
             grzes1a = true;
             return;
         }
         else if (Hit[2]==false && Hit[4]==true && Hit[6]==false && Hit[8]==true && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true)
         {
             spawnRotation = Quaternion.Euler(0,0,180);
             grzes1a = true;
             return;
         }
         else if (Hit[2]==true && Hit[4]==false && Hit[6]==true && Hit[8]==false && Hit[1]==true && Hit[3]==true && Hit[5]==true && Hit[7]==true )
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

    [ContextMenu("Reset")]
    public void Restart()
    {
        Start();
    }
}
