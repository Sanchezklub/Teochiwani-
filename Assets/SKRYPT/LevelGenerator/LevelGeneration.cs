using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public int[,] Room = new int[6, 4];
    public int[,] FixedRoom = new int [12,4];
    public int MagnitudeL;
    public float moveAmountx;
    public float moveAmounty;
    public float startTimeBtwSpawn=0.25f;
    public GameObject[] rooms;
    public GameObject Portal1;
    public GameObject Kupiec1;
    public Vector2 StartingPosition;
    public Vector2 TutorialStartingPosition;
    public LevelData levelData;

    public GameObject tutorial;
    //public Vector2 portalPosition;
    //private void Start()
   //{
        /*Vector2 newPos14 = new Vector2(StartingPosition.x,StartingPosition.y);
        transform.position = newPos14;
        int randEndPos = Random.Range(0,4 ); // losuje miejsce przejścia do bossa
        Level3();
        Level4();
        Level2();
        Level1();
        St();*/
        
    //}
    private void Boss()
    {
    Vector2 newPos2 = new Vector2(StartingPosition.x+10*moveAmountx,StartingPosition.y );
    transform.position = newPos2;
        Instantiate(rooms[16], transform.position, Quaternion.identity); // buduje
        FixedRoom[11, 1] = 16;
    }
    private void KupieciPortal()
    {
        
        int randx = Random.Range(0,6);
        int randy = Random.Range(0,3);
        Vector2 newPos2 = new Vector2(StartingPosition.x+randx*moveAmountx,StartingPosition.y+randy*moveAmounty-2 );
        transform.position = newPos2;
        Instantiate(Kupiec1, transform.position, Quaternion.identity);
        int randx1 = Random.Range(0,6);
        int randy1 = Random.Range(0,3);
        if(randx==randx1&& randy==randy1)
        {
                if ( randx1>4)
                randx1-=1;
                else
                {
                randx1+=1; 
                }
        }
        Vector2 newPos3 = new Vector2(StartingPosition.x+randx1*moveAmountx,StartingPosition.y+7+randy1*moveAmounty);
        transform.position = newPos3;
        Instantiate(Portal1, transform.position, Quaternion.identity);
        GameController.instance.DataStorage.PlayerInfo.portalPosition = transform.position;
    }
     private void St()
     {
        Vector2 newPos2 = new Vector2(StartingPosition.x,StartingPosition.y );
        transform.position = newPos2;
        Vector2 newPos1 = new Vector2(transform.position.x-moveAmountx, transform.position.y);
        transform.position = newPos1;
        Instantiate(rooms[15], transform.position, Quaternion.identity); // buduje
        //EventController.instance.levelEvents.CallOnLevelGenerated(Room);
        //levelData.SaveLayout(Room);
     }
    
  private void Level1() // budowa poziomu 1 ( od góry )
    {
        MagnitudeL= 1;
        Vector2 newPos2 = new Vector2(StartingPosition.x,StartingPosition.y );
        transform.position = newPos2;
        Vector2 newPos1 = new Vector2(transform.position.x, transform.position.y + moveAmounty + moveAmounty);
        transform.position = newPos1;
        if (Room[0,2]==10)
        {
            Room[0,3] = 5;
            Instantiate(rooms[5], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos;
        }
        else if (Room[0,2]==5||Room[0,2]==7)
        {
            Room[0,2] = 7;
            Instantiate(rooms[7], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos;
        }
        else
        {
            int rand = Random.Range(0,2);
            if(rand==0)rand = 9;
            if(rand==1)rand = 5;          
            Room[0,3] = rand;
            Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos; // przesuwam    
        }
        for(int i=1;i <5; i++)
        {
            if (Room[i-1,3]<8)
            {
               if(Room[i,2]==0 ||Room[i,2]==1 ||Room[i,2]==4 ||Room[i,2]==6 ||Room[i,2]==8 ||Room[i,2]==10 ||Room[i,2]==11||Room[i,2]==13)
                {
                Room[i,3] = 2;
                Instantiate(rooms[2], transform.position, Quaternion.identity); // buduje 
                Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                transform.position = newPos; // przesuwam    
                    
                }
                else
                {
                    Room[i,3] = 3;
                Instantiate(rooms[3], transform.position, Quaternion.identity); // buduje 
                Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                transform.position = newPos; // przesuwam  
                }

            }
            else
            {
                if(Room[i,2]==0 ||Room[i,2]==1 ||Room[i,2]==4 ||Room[i,2]==6 ||Room[i,2]==8 ||Room[i,2]==10 ||Room[i,2]==11||Room[i,2]==13)
                {
                Room[i,3] = 5;
                Instantiate(rooms[5], transform.position, Quaternion.identity); // buduje 
                Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                transform.position = newPos; // przesuwam    
                    
                }
                else
                {
                    Room[i,3] = 7;
                Instantiate(rooms[7], transform.position, Quaternion.identity); // buduje 
                Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                transform.position = newPos; // przesuwam  
                }
            }
        }
        
        if (Room[5,2]==11 ||Room[5,2]==13||Room[5,2]==10||Room[5,2]==8)
        {
            Room[5,3] = 12;
            Instantiate(rooms[12], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos11 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos11; // przesuwam      
        }
        else
        {
            Room[5,3] = 14;
            Instantiate(rooms[14], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos11 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos11; // przesuwam      
        }


    }

    private void Level2() // budowa poziomu 2 
    {
        MagnitudeL= 2;
        Vector2 newPos2 = new Vector2(StartingPosition.x,transform.position.y );
        transform.position = newPos2;
        Vector2 newPos1 = new Vector2(transform.position.x, transform.position.y + moveAmounty + moveAmounty);
        transform.position = newPos1;

        if( Room[0,1]==1||Room[0,1]==0)
        {
            int rand = Random.Range(0,3);
            if(rand==0)rand = 4;
            if(rand==1)rand = 5;
            if(rand==2)rand = 8; // losuje 
            Room[0,2] = rand;
            Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos; // przesuwam      
        }
        else
        {
            int rand = Random.Range(0,3);
            if(rand==0)rand = 6;
            if(rand==1)rand = 7;
            if(rand==2)rand = 10;
            Room[0,2] = rand;
            Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos; // przesuwam             
        }
        if(Room[1,1]==0||Room[1,1]==1 )
        {
            if(Room[0,2]<8)
            {
                int rand = Random.Range(0,4);
                if(rand==0)rand = 0;
                if(rand==1)rand = 2;
                if(rand==2)rand = 11;
                if(rand==3)rand = 12;
                Room[1,2] = rand;
                Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                transform.position = newPos4; // przesuwam   
                
            }
            else
            {
                int rand = Random.Range(0,4);
                if(rand==0)rand = 4;
                if(rand==1)rand = 5;
                if(rand==2)rand = 8;
                if(rand==3)rand = 9;
                Room[1,2] = rand;
                Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                transform.position = newPos4; 
            }
        }
        else
        {
            switch(Room[0,2])
            {
                case 4:
                {
                    int rand = Random.Range(0,3);
                    if(rand==0)rand = 1;
                    if(rand==1)rand = 3;
                    if(rand==2)rand = 13;
                    Room[1,2] = rand;
                    Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                    Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                    transform.position = newPos4; 
                    break;
                }
                 case 5:
                {
                     int rand = Random.Range(0,3);
                    if(rand==0)rand = 1;
                    if(rand==1)rand = 3;
                    if(rand==2)rand = 13;
                    Room[1,2] = rand;
                    Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                    Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                    transform.position = newPos4; 
                    break;
                }
                 case 6:
                {
                     int rand = Random.Range(0,2);
                    if(rand==0)rand = 1;
                    if(rand==1)rand = 3;
                    Room[1,2] = rand;
                    Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                    Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                    transform.position = newPos4; 
                    break;
                }
                 case 7:
                {
                     int rand = Random.Range(0,3);
                    if(rand==0)rand = 1;
                    if(rand==1)rand = 3;
                    if(rand==2)rand = 13;
                    Room[1,2] = rand;
                    Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                    Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                    transform.position = newPos4; 
                    break;
                }
                 case 8:
                {
                    int rand = Random.Range(0,2);
                    if(rand==0)rand = 6;
                    if(rand==1)rand = 7;
                    Room[1,2] = rand;
                    Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                    Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                    transform.position = newPos4; 
                    break;
                }
                 case 9:
                {
                    int rand = Random.Range(0,2);
                    if(rand==0)rand = 6;
                    if(rand==1)rand = 7;
                    Room[1,2] = rand;
                    Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                    Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                    transform.position = newPos4; 
                    break;
                }
                 case 10:
                {
                    int rand = Random.Range(0,3);
                    if(rand==0)rand = 6;
                    if(rand==1)rand = 7;
                    if(rand==2)rand = 10;
                    Room[1,2] = rand;
                    Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                    Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                    transform.position = newPos4; 
                    break;
                }               
            }

        }

        for (int i=2;i <4; i++)
        {
            if(Room[i,1]==0||Room[i,1]==1 )
            {
                if(Room[i-1,2]<=7)
                {
                    int rand = Random.Range(0,4);
                        if(rand==0)rand = 0;
                        if(rand==1)rand = 2;
                        if(rand==2)rand = 11;
                        if(rand==3)rand = 12;
                        Room[i,2] = rand;
                        Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                        Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                        transform.position = newPos4; 
                }
                else
                {
                    int rand = Random.Range(0,4);
                        if(rand==0)rand = 4;
                        if(rand==1)rand = 5;
                        if(rand==2)rand = 8;
                        if(rand==3)rand = 9;
                        Room[i,2] = rand;
                        Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                        Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                        transform.position = newPos4; 
                }                                
            }
            else 
            {
                 if(Room[i-1,2]<=7)
                {
                        int rand = Random.Range(0,3);
                        if(rand==0)rand = 1;
                        if(rand==1)rand = 3;
                        if(rand==2)rand = 13;
                        Room[i,2] = rand;
                        Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                        Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                        transform.position = newPos4;                         
                }
                else
                {
                        int rand = Random.Range(0,3);
                        if(rand==0)rand = 6;
                        if(rand==1)rand = 10;
                        if(rand==2)rand = 7;
                        Room[i,2] = rand;
                        Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
                        Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
                        transform.position = newPos4;           
                }
            }
        }

        if(Room[3,2]<=7)
        {

            int rand = Random.Range(0,4);
            if(rand==0)rand = 0;
            if(rand==1)rand = 2;
            if(rand==2)rand = 11;
            if(rand==3)rand = 12;
            Room[4,2] = rand;
            Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos4; 
        }
        else
        {

            int rand = Random.Range(0,4);
            if(rand==0)rand = 4;
            if(rand==1)rand = 5;
            if(rand==2)rand = 8;
            if(rand==3)rand = 9;
            Room[4,2] = rand;
            Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos4 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos4; 
        }
        if (Room[5,1]==11 ||Room[5,1]==13 )
        {
            if(Room[4,2]<6)
            {
            Room[5,2] = 11;
            Instantiate(rooms[11], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos5 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos5; 
            }
            else
            {
            Room[5,2] = 8;
            Instantiate(rooms[8], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos55 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos55; 
            }

        }
        else
        {
            if(Room[4,2]<6)
            {
            Room[5,2] = 13;
            Instantiate(rooms[13], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos56 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos56; 
            }
            else
            {
            Room[5,2] = 10;
            Instantiate(rooms[10], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos555 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos555; 
            }

        }
    }

    private void Level3() // budowa poziomu 3
    {
        MagnitudeL= 3;
        for(int i=0; i <4; i++) // ide w prawo 5 chunków, losując za każdym razem nowy z przejściami w lewo i prawo
        {
            int rand = Random.Range(0,4); // losuje 
            Room[i,1] = rand;
            Instantiate(rooms[rand], transform.position, Quaternion.identity); // buduje 
            Vector2 newPos = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
            transform.position = newPos; // przesuwam      
        }
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        Room[4,1]=0;
        Vector2 newPos31 = new Vector2(transform.position.x + moveAmountx,transform.position.y ); 
        transform.position = newPos31;
        int rand1 = Random.Range(11,15); // losuje 6 chunk który ma obowiazkowo przejście w prawo i opcjonalne w góre i w dół
        Room[5,1] = rand1;
        Instantiate(rooms[rand1], transform.position, Quaternion.identity); // buduje
       
    }
    
    private void Level4() // budowa poziomu 4 
    {
        MagnitudeL= 4;
        Vector2 newPos1 = new Vector2(StartingPosition.x,StartingPosition.y); // przesuwam sie na pozycje na startowa
        transform.position = newPos1;
        if(Room[0,1]==0 || Room[0,1]==2) 
             {
                Vector2 newPos12 = new Vector2(transform.position.x,transform.position.y - moveAmounty);
                transform.position = newPos12;            
                Instantiate(rooms[6], transform.position, Quaternion.identity); // jezeli na górze przejscia nie ma wybieram chunk z mozliwoscia pojscia tylko w prawo
                Room[0,0]=6;
            }
        else
            {
                Vector2 newPos13 = new Vector2(transform.position.x,transform.position.y - moveAmounty); // jezeli jest przejscie biore chunk z przejściem w prawo i w góre
                transform.position = newPos13;
                Instantiate(rooms[7], transform.position, Quaternion.identity);
                Room[0,0]=7;
            }
        
        Vector2 newPos14 = new Vector2(StartingPosition.x,StartingPosition.y);
        transform.position = newPos14;
        Vector2 newPos15 = new Vector2(StartingPosition.x+ moveAmountx,StartingPosition.y);
        transform.position = newPos15;
         
        if(Room[1,1]==0||Room[1,1]==2) 
            {
                Vector2 newPos6 = new Vector2(transform.position.x,transform.position.y - moveAmounty);
                transform.position = newPos6;

                int rand = Random.Range(0,2); // losuje 
                if ( rand == 0)rand = 1;
                if (rand==1 )rand = 13;
                Instantiate(rooms[rand], transform.position, Quaternion.identity); // jezeli na górze przejscia nie ma wybieram chunk z mozliwoscia pojscia tylko w prawo
                Room[1,0]=rand;
            }
        else
            {
                Vector2 newPos11 = new Vector2(transform.position.x,transform.position.y - moveAmounty); // jezeli jest przejscie biore chunk z przejściem w prawo i w góre
                transform.position = newPos11;   
                Instantiate(rooms[3], transform.position, Quaternion.identity);// jezeli nie mozna w do gory a tylko w prawo to biore prawo i lewo
                Room[1,0]=3;
            }
        for (int i=2;i <4; i++)
            {
                Vector2 newPos10 = new Vector2(StartingPosition.x,StartingPosition.y);
                transform.position = newPos10;
                Vector2 newPos2 = new Vector2(StartingPosition.x + i* moveAmountx,StartingPosition.y); 
                transform.position = newPos2;   
                Vector2 newPos3 = new Vector2(StartingPosition.x,StartingPosition.y);
                transform.position = newPos3;
                Vector2 newPos4 = new Vector2(StartingPosition.x + i* moveAmountx,StartingPosition.y-moveAmounty);
                transform.position = newPos4;
                switch (Room[i-1,0])
                {
                    case 1:
                    {
                        if(Room[i,1]==1 || Room[i,1]==3)
                        {
                            int rand= Random.Range(0,2);
                            if(rand==0)rand=14;
                            if(rand==1)rand=3;
                            Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            Room[i,0]=rand;
                        }
                        else
                        {
                            Instantiate(rooms[13], transform.position, Quaternion.identity);
                            Room[i,0]=13;
                        }
                        break;
                    }
                    case 3:
                    {
                        if(Room[i,1]==1 || Room[i,1]==3)
                        {
                            Instantiate(rooms[3], transform.position, Quaternion.identity);
                            Room[i,0]=3;
                        }
                        else
                        {
                            int rand= Random.Range(0,2);
                            if(rand==0)rand=1;
                            if(rand==1)rand=13;
                            Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            Room[i,0]=rand;
                        }
                        break;
                    }
                    case 6:
                    {
                        if(Room[i,1]==1 || Room[i,1]==3)
                        {
                            int rand= Random.Range(0,2);
                            if(rand==0)rand=3;
                            if(rand==1)rand=14;
                            Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            Room[i,0]=rand;
                        }
                        else
                        {
                            int rand= Random.Range(0,2);
                            if(rand==0)rand=1;
                            if(rand==1)rand=13;
                            Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            Room[i,0]=rand;
                        }
                        break;
                    }
                     case 7:
                    {
                        if(Room[i,1]==1 || Room[i,1]==3)
                        {
                            Instantiate(rooms[3], transform.position, Quaternion.identity);
                            Room[i,0]=3;
                        }
                        else
                            {
                            int rand= Random.Range(0,2);
                            if(rand==0)rand=1;
                            if(rand==1)rand=13;
                            Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            Room[i,0]=rand;
                            }
                        break;
                    }
                    case 10:
                    {
                        if(Room[i,1]==1 || Room[i,1]==3)
                        {
                            Instantiate(rooms[7], transform.position, Quaternion.identity);
                            Room[i,0]=7;     
                        }
                        else
                        {   
                            Instantiate(rooms[6], transform.position, Quaternion.identity);
                            Room[i,0]=6;  
                        }
                        break;
                    }
                    case 13:
                    {
                        if(Room[i,1]==1 || Room[i,1]==3)
                        {
                            Instantiate(rooms[7], transform.position, Quaternion.identity);
                            Room[i,0]=7;     
                        }
                        else
                            {   
                            int rand= Random.Range(0,2);
                            if(rand==0)rand=10;
                            if(rand==1)rand=6;
                            Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            Room[i,0]=rand;
                            }
                        
                        break;
                    }
                    case 14:
                    {
                        if(Room[i,1]==1 || Room[i,1]==3)
                        {
                            Instantiate(rooms[7], transform.position, Quaternion.identity);
                            Room[i,0]=7;     
                        }
                        else
                        {   
                            int rand= Random.Range(0,2);
                            if(rand==0)rand=10;
                            if(rand==1)rand=6;
                            Instantiate(rooms[rand], transform.position, Quaternion.identity);
                            Room[i,0]=rand;
                        }
                        
                        break;
                    }
                }
            }
            Vector2 newPos24 = new Vector2(transform.position.x + moveAmountx,transform.position.y);
            transform.position = newPos24;
            if (Room[3,0]<8)
            {
                Instantiate(rooms[1], transform.position, Quaternion.identity);
                Room[4,0]=1;
            }
            else
            {
                 Instantiate(rooms[6], transform.position, Quaternion.identity);
                Room[4,0]=6;
            }
        
            Vector2 newPos25 = new Vector2(transform.position.x + moveAmountx,transform.position.y);
            transform.position = newPos25;

            if(Room[5,1]>12)
            {
                Instantiate(rooms[14], transform.position, Quaternion.identity);
                    Room[5,0]=14;  
            }
            else
            {
                Instantiate(rooms[13], transform.position, Quaternion.identity);
                    Room[5,0]=13; 
            }
 
    }
    public void Fix()
    {
        for ( int i=1; i<7;i++)
            {
                for ( int j=0;j<4;j++)
            {
                
                FixedRoom[i,j]=Room[i-1,j];
                //Debug.Log(FixedRoom[i,j]);
            }
            }
        FixedRoom[0,1]=15;
        FixedRoom[0, 0] = 9999;
        FixedRoom[0, 2] = 9999;
        FixedRoom[0, 3] = 9999;

    }

    void InitialFix()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                FixedRoom[i, j] = 9999;
            }
        }
    }

    void FallbackRoom()
    {
        Instantiate(rooms[17], transform.position, Quaternion.identity);
    }

    [ContextMenu("GenerateLevel")]
    public void Create() // buduje poziom 
    {
        Vector2 newPos14 = new Vector2(StartingPosition.x, StartingPosition.y);
        transform.position = newPos14;
        int randEndPos = Random.Range(0, 4); // losuje miejsce przejścia do bossa

        Level3();
        Level4();
        Level2();
        Level1();        
        St();
        InitialFix();
        Fix();
        Boss();
        KupieciPortal();
        FallbackRoom();
        
        EventController.instance.levelEvents.CallOnChunkGenerated();
        EventController.instance.levelEvents.CallOnLevelGenerated(FixedRoom);
        GameController.instance.DataStorage.PlayerInfo.IsInTutorial = false;
    }

    public void CreateTutorial()
    {
        Instantiate(tutorial,new Vector2( StartingPosition.x - moveAmountx, StartingPosition.y- moveAmounty), Quaternion.identity);
        EventController.instance.levelEvents.CallOnChunkGenerated();
        EventController.instance.levelEvents.CallOnTutorialGenerated();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = TutorialStartingPosition;
        GameController.instance.DataStorage.PlayerInfo.IsInTutorial = true;
    }
}
