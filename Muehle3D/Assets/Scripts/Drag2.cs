using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag2 : MonoBehaviour {

        public GameObject[] stones = new GameObject[18];
    
        public static Vector3 nextPos;
        Vector3 orgPos;
        Vector3 dist;
        float posX;
        float posY;
        private bool isNearEven = false;
        private bool isNearOdd = false;




    void Start()
        {

        }

        private void OnMouseDown()
        {

            if (Gameplay.player2Turn == true && Positions.foundMuehleWss == false)
            {


                dist = Camera.main.WorldToScreenPoint(transform.position);
                posX = Input.mousePosition.x - dist.x;
                posY = Input.mousePosition.y - dist.y;

                orgPos = transform.position; // Debug.Log("Orgpos benutzt");
        }
        }

        private void OnMouseDrag()
        {
            if (Gameplay.player2Turn == true && Positions.foundMuehleWss == false)
            {


                Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);

                Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
                transform.position = worldPos;
            }
        }



        private void OnMouseUp()
        {


        if (Gameplay.player2Turn == true && Gameplay.player2PhaseOne && Positions.foundMuehleWss == false)
        {
            if (Drop.colTrue2 == true)
            {
                find2Index();

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] != 'n')
                {
                    
                    transform.position = orgPos;
                    Drop.colTrue2 = false;
                }

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] == 'n')
                {
                    setIndexOld();
                    transform.position = nextPos;
                    Gameplay.Stonesleft--;

                    Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] = 'w';
                    Positions.eraseMuehle();
                    Positions.findMuehleWss();

                    // Debug.Log("Position: " + Positions.positionArray[Positions.index]);
                    // Debug.Log("Farbe: " + Positions.colourArray[Positions.index]);
                   
                   if(Positions.foundMuehleWss == false)
                    {
                        Gameplay.Player1Turn();
                    } 

                    Drop.colTrue2 = false;
                    //Gameplay.player2TurnOver = false;
                    

                }
            }
            else
            {
                
                transform.position = orgPos;
                Drop.colTrue2 = false;
            }

        }

        if (Gameplay.player2Turn == true && Gameplay.player2PhaseTwo && Positions.foundMuehleSwz == false)
        {
            if (Drop.colTrue2 == true)
            {
                find2IndexOrg();
                find2Index();
                isNearEven = findNearEven(Positions.indexRingOrg);
                Debug.Log("Ring Even: " + Positions.indexRingOrg);
                isNearOdd = findNearOdd(Positions.indexRingOrg);
                Debug.Log("Ring Odd: " + Positions.indexRingOrg);
                Debug.Log("isNearOdd: " + isNearOdd);
                Debug.Log("isNearEven: " + isNearEven);

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] != 'n' || (isNearEven == false && isNearOdd == false))
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
                    Positions.findMuehleWss();

                    if (Positions.foundMuehleWss == false)
                    {
                        Gameplay.Player1Turn();
                    }
                    Drop.colTrue2 = false;


                }



            }
            else
            {
                //Debug.Log("Original Pos)");
                transform.position = orgPos;
                Drop.colTrue = false;
            }


        }

        if (Gameplay.player2Turn == true && Gameplay.player2PhaseThree && Positions.foundMuehleWss == false)
        {
            if (Drop.colTrue2 == true)
            {
                find2Index();

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] != 'n')
                {

                    transform.position = orgPos;
                    Drop.colTrue2 = false;
                }

                if (Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] == 'n')
                {
                    setIndexOld();
                    transform.position = nextPos;
                    Gameplay.Stonesleft--;

                    Positions.colourArray2dim[Positions.indexRing, Positions.indexPlace] = 'w';
                    Positions.eraseMuehle();
                    Positions.findMuehleWss();

                    // Debug.Log("Position: " + Positions.positionArray[Positions.index]);
                    // Debug.Log("Farbe: " + Positions.colourArray[Positions.index]);

                    if (Positions.foundMuehleWss == false)
                    {
                        Gameplay.Player1Turn();
                    }

                    Drop.colTrue2 = false;
                    //Gameplay.player2TurnOver = false;


                }
            }
            else
            {

                transform.position = orgPos;
                Drop.colTrue2 = false;
            }

        }

    }

 
    private void find2Index()
    {
        Positions.indexRing = 0;
        Positions.indexPlace = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                if (nextPos == Positions.positionArray2dim[i, j])
                {

                    Positions.indexRing = i;
                    Positions.indexPlace = j;
                }

            }
            // Debug.Log("I in For-Schleife "+ i);
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
                    Debug.Log("index Ring Org" + i);
                    Debug.Log("index Place Org" + j);
                }

            }

        }
    }

    private bool findNearEven(int ring)
    {


        // for (int p = 0; p < 7; p=p+2)
        //{
        if (Positions.indexPlaceOrg == 0)
        {

            if (Positions.indexRing == ring && Positions.indexPlace == 0)
            {
                Debug.Log("Gerade 0 ");
                return true;
            }


            if (Positions.indexRing == ring && Positions.indexPlace == 7)
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
            // Debug.Log("I in For-Schleife "+ i);
        }
    }
    private void Update()
        {
        // Debug.Log(Drop.colTrue);
        //Debug.Log(nextPos);
        // Debug.Log(Input.mousePosition.y);

        if (Gameplay.player2Turn == true || Drop.colTrue2 == true && Gameplay.player2Turn == false )
            {

                if (Input.mousePosition.y > 750)
                {
                    Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0f, 8f, 3f), 1f * Time.deltaTime);
                }

                if (Input.mousePosition.y < 50)
                {
                    Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0f, 8f, 10f), 1f * Time.deltaTime);
                }

            }
        }


    }
