using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {


    public GameObject[] stones = new GameObject[18];

    public static Vector3 nextPos;
    Vector3 orgPos;
    Vector3 dist;
    float posX;
    float posY;
    static public bool oldMuehleSwz = false;
    private bool isNearEven = false;
    private bool isNearOdd = false;

    void Start()
    {

    }

   private void OnMouseDown()
    {
        if (Gameplay.player1Turn == true && Positions.foundMuehleSwz == false)
        {


            dist = Camera.main.WorldToScreenPoint(transform.position);
            posX = Input.mousePosition.x - dist.x;
            posY = Input.mousePosition.y - dist.y;

            orgPos = transform.position; //Debug.Log("Orgpos benutzt");
        }
    }

    private void OnMouseDrag()
    {   
        if (Gameplay.player1Turn == true && Positions.foundMuehleSwz == false)
        {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
        }
    }

    

    private void OnMouseUp()
    {
        if (Gameplay.player1Turn == true && Gameplay.player1PhaseOne && Positions.foundMuehleSwz == false)
        {


            if (Drop.colTrue == true)
            {        
                find2Index();              

                /*if (oldMuehleSwz == false)
                {
                    Positions.findMuehleSwz();
                    if (Positions.foundMuehleSwz)
                    {
                        oldMuehleSwz = true;
                    }
                    if (Positions.foundMuehleSwz == false)
                    {
                        oldMuehleSwz = false;
                    }
                    
                }
                */

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] != 'n')
                {
                    
                    transform.position = orgPos;
                    Drop.colTrue = false;
                }
              
                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] == 'n')
                {
                    
                    setIndexOld(); //Alte Position bereinigen
                    transform.position = nextPos;
                    Gameplay.Stonesleft--;

                    Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] = 's';
                    Positions.eraseMuehle();

                    if(oldMuehleSwz == false)
                    Positions.findMuehleSwz();
                 
                    if (Positions.foundMuehleSwz == false || oldMuehleSwz )
                    {
                        Gameplay.Player2Turn();
                       
                    }
                    Drop.colTrue = false;
                  

                }

            }
            else
            {
                
                transform.position = orgPos;
                Drop.colTrue = false;
            }
        }

        if (Gameplay.player1Turn == true && Gameplay.player1PhaseTwo && Positions.foundMuehleSwz == false)
        {
            if (Drop.colTrue == true)
            {
                find2IndexOrg();
                find2Index();
                isNearEven = findNearEven(Positions.indexRingOrg);
                Debug.Log("Ring Even: " + Positions.indexRingOrg);
                isNearOdd = findNearOdd(Positions.indexRingOrg);
                Debug.Log("Ring Odd: " + Positions.indexRingOrg);
                Debug.Log("isNearOdd: " + isNearOdd);
                Debug.Log("isNearEven: " + isNearEven);

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] != 'n' || ( isNearEven == false && isNearOdd == false))
                {

                    transform.position = orgPos;
                    Debug.Log("Orgpos benutzt");
                    Drop.colTrue = false;
                    isNearEven = false;
                    isNearOdd = false;
                }

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] == 'n' && (isNearEven || isNearOdd))
                {
                    
                    setIndexOld(); //Alte Position bereinigen
                    transform.position = nextPos;

                    isNearEven = false;
                    isNearOdd = false;

                    Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] = 's';
                    Positions.eraseMuehle();
                    Positions.findMuehleSwz();
                   
                   
                    if (Positions.foundMuehleSwz == false)
                    {
                        Gameplay.Player2Turn();
                    }
                    Drop.colTrue = false;
                 

                }



            }
            else
            {
                //Debug.Log("Original Pos)");
                transform.position = orgPos;
                Drop.colTrue = false;
            }
        }

        if (Gameplay.player1Turn == true && Gameplay.player1PhaseThree && Positions.foundMuehleSwz == false)
        {
            if (Drop.colTrue == true)
            {
                find2Index();

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] != 'n')
                {

                    transform.position = orgPos;
                    Drop.colTrue = false;
                }

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] == 'n')
                {

                    setIndexOld(); //Alte Position bereinigen
                    transform.position = nextPos;
                    Gameplay.Stonesleft--;

                    Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] = 's';
                    Positions.eraseMuehle();
                    Positions.findMuehleSwz();

                    if (Positions.foundMuehleSwz == false)
                    {
                        Gameplay.Player2Turn();
                    }
                    Drop.colTrue = false;


                }

            }
            else
            {

                transform.position = orgPos;
                Drop.colTrue = false;
            }
        }

    }

    private void find2Index()
    {
        Positions.indexRing = 0;
        Positions.indexPlace = 0;
        for (int i = 0; i <3; i++)
        {
            for(int j = 0;j < 8; j++){

            if (nextPos == Positions.positionArray2dim[i,j])
            {

                Positions.indexRing = i;
                Positions.indexPlace = j;
                }

            }
           
        }
    }

    private void find2IndexOrg()
    {
        Positions.indexRingOrg = 0;
        Positions.indexPlaceOrg = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                if (orgPos == Positions.positionArray2dim[i, j])
                {

                    Positions.indexRingOrg = i;
                    Positions.indexPlaceOrg = j;
                    Debug.Log("index Ring Org"+i);
                    Debug.Log("index Place Org" + j);
                }

            }

        }
    }

    /* private void find2IndexNear()
     {
         Positions.indexRingNear = 0;
         Positions.indexPlaceNear = 0;
         for (int i = 0; i < 3; i++)
         {
             for (int j = 0; j < 8; j++)
             {

                 if (orgPos == Positions.positionArray2dim[i, j])
                 {

                     Positions.indexRingNear = i;
                     Positions.indexPlaceNear = j;
                 }

             }

         }

         if(Positions.indexPlace - Positions.indexRingNear == 1 || Positions.indexPlace - Positions.indexRingNear == -1)
         {

         }
     }
     */
    

    private bool findNearEven(int ring)
    {
        
       
           // for (int p = 0; p < 7; p=p+2)
            //{
                if (Positions.indexPlaceOrg  == 0)
                {

                    if (Positions.indexRing == ring && Positions.indexPlace == 0)
                    {
                        Debug.Log("Gerade 0 ");
                        return true;
                    }
                    

                        if (Positions.indexRing == ring && Positions.indexPlace  == 7)
                    {
                        Debug.Log("Gerade 7 ");
                        return true;
                    }

                }
    

                if (Positions.indexPlaceOrg == 2)
                {
                    if (Positions.indexRing == ring && Positions.indexPlace == 1)
                    {
                        //Debug.Log("Gerade p-1: " + p);
                        return true;
                    }

                    if (Positions.indexRing == ring && Positions.indexPlace == 3)
                    {

                        //Debug.Log("Gerade p+1:  " + p);
                        return true;
                    }

                }

                if (Positions.indexPlaceOrg == 4)
                {
                    if (Positions.indexRing == ring && Positions.indexPlace == 3)
                    {
                        //Debug.Log("Gerade p-1: " + p);
                        return true;
                    }

                    if (Positions.indexRing == ring && Positions.indexPlace == 5)
                    {

                        //Debug.Log("Gerade p+1:  " + p);
                        return true;
                    }

                }

                if (Positions.indexPlaceOrg == 6)
                {
                    if (Positions.indexRing == ring && Positions.indexPlace == 5)
                    {
                        //Debug.Log("Gerade p-1: " + p);
                        return true;
                    }

                    if (Positions.indexRing == ring && Positions.indexPlace == 7)
                    {

                        //Debug.Log("Gerade p+1:  " + p);
                        return true;
                    }

                }



            
        return false;
    }

    private bool findNearOdd(int ring)
    {

        if (ring == 0)
        {



            if (Positions.indexPlaceOrg == 1)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 0)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 2)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 1)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 3)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 2)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 4)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 3)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 5)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 4)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 6)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 5)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 7)
            {
                if (Positions.indexRing == ring && Positions.indexPlace == 0)
                {

                    //Debug.Log("Ungerade 0:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 6)
                {

                    //Debug.Log("Ungerade 6:  " + p);
                    return true;
                }

            }

        }

        if (ring == 1)
        {



            if (Positions.indexPlaceOrg == 1)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 0)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 2)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 1)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 3)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 2)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 4)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 3)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 5)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 4)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 6)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 5)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 7)
            {
                if (Positions.indexRing == ring && Positions.indexPlace == 0)
                {

                    //Debug.Log("Ungerade 0:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 6)
                {

                    //Debug.Log("Ungerade 6:  " + p);
                    return true;
                }

            }

        }


        if (ring == 2)
        {


            if (Positions.indexPlaceOrg == 1)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 0)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 2)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 1)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 3)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 2)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 4)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 3)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 5)
            {

                if (Positions.indexRing == ring && Positions.indexPlace == 4)
                {

                    //Debug.Log("Ungerade p-1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 6)
                {

                    //Debug.Log("Ungerade p+1:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring + 1 && Positions.indexPlace == 5)
                {

                    //Debug.Log("Ungerade p:  " + p);
                    return true;
                }

            }

            if (Positions.indexPlaceOrg == 7)
            {
                if (Positions.indexRing == ring && Positions.indexPlace == 0)
                {

                    //Debug.Log("Ungerade 0:  " + p);
                    return true;
                }

                if (Positions.indexRing == ring && Positions.indexPlace == 6)
                {

                    //Debug.Log("Ungerade 6:  " + p);
                    return true;
                }

            }

            /* for (int p = 1; p < 8; p=p+2)
             {
                 if (p % 2 != 0)
                 {

                     if (Positions.indexRing == ring && Positions.indexPlace == p - 1)
                     {

                         Debug.Log("Ungerade p-1:  " + p);
                         return true;
                     }

                     if (Positions.indexRing == ring && Positions.indexPlace == p + 1)
                     {

                         Debug.Log("Ungerade p+1:  " + p);
                         return true;
                     }

                     if (Positions.indexRing == ring - 1 && Positions.indexPlace == p)
                     {

                         Debug.Log("Ungerade p==:  " + p);
                         return true;
                     }
                 }

                 if (p == 7)
                 {
                     if (Positions.indexRing == ring && Positions.indexPlace == 0)
                     {

                         Debug.Log("Ungerade 0:  " + p);
                         return true;
                     }

                     if (Positions.indexRing == ring && Positions.indexPlace == 6)
                     {

                         Debug.Log("Ungerade 7:  " + p);
                         return true;
                     }
                 }
             }*/

        }
        return false;

    }

    

    private void setIndexOld()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                if (orgPos == Positions.positionArray2dim[i, j])
                {

                    Positions.colourArray2dim[i, j] = 'n';
                }
                

            }
           
        }
    }


    private void Update()
    {

        //Debug.Log("Index: " + Positions.index);
        //  Debug.Log("Maus Y: "+Input.mousePosition.y);

        Debug.Log("OMS"+oldMuehleSwz);
        if (Gameplay.player1Turn == true || Drop.colTrue == true && Gameplay.player2Turn==false )
        {
            if (Input.mousePosition.y > 900)// && Input.mousePosition.y >700)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0f, 8f, -1), 1f * Time.deltaTime);
            }

           

            if (Input.mousePosition.y > 400)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0f, 8f, -8), 1f * Time.deltaTime);
            }

            if (Input.mousePosition.y < 50)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0f, 8f, -10f), 1f * Time.deltaTime);
            }

        }
    } 


}   
