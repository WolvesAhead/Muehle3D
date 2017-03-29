using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour {
    
    public static Vector3[,] positionArray2dim = new Vector3[3, 8];

    public static char[,] colourArray2dim = new char[3, 8];
    
    public static bool[,] inMuehle = new bool[3, 8];
    public static bool[] muehlen = new bool[16];


    public static int index;
    public static int indexRing;
    public static int indexPlace;
    public static int indexRingOrg;
    public static int indexPlaceOrg;
    public static int indexRingNear;
    public static int indexPlaceNear;


    int schwarzCount = 0;

    public static bool Muehle = false;
    public static bool foundMuehleSwz = false;
    public static bool foundMuehleWss = false;




   
    // Use this for initialization
    void Start() {


        for (int m = 0; m < 3; m++)
        {
            for (int n = 0; n < 8; n++)
            {
                positionArray2dim[m, n] = GameObject.Find("R" + m + "P" + n).transform.position;
                //Debug.Log(positionArray2dim[m, n]);
            }
        }

        for (int m = 0; m < 3; m++)
        {
            for (int n = 0; n < 8; n++)
            {
                colourArray2dim[m, n] = 'n';
                //Debug.Log(colourArray2dim[m, n]);
            }
        }



        for (int m = 0; m < 3; m++)
        {
            for (int n = 0; n < 8; n++)
            {
                inMuehle[m, n] = false;
            }
        }


    }

    // Update is called once per frame
    void Update() {


    }

    public static void findMuehleSwz()
    {
        #region Muehle Swz

       
        for (int k = 0; k < 3; k++) // nachfolgende Mühlen
        {
            for (int l = 0; l < 5; l = l + 2)
            {
                if (colourArray2dim[k, l] == 's' && colourArray2dim[k, l + 1] == 's' && colourArray2dim[k, l + 2] == 's')
                {
                    inMuehle[k, l] = true;
                    inMuehle[k, l + 1] = true;
                    inMuehle[k, l + 2] = true;
                    foundMuehleSwz = true;
                }
            }
        }

        for (int k = 0; k < 3; k++) // Mühlen mit 0 am Ende
        {
            if (colourArray2dim[k, 0] == 's' && colourArray2dim[k, 6] == 's' && colourArray2dim[k, 7] == 's')
            {
                inMuehle[k, 0] = true;
                inMuehle[k, 6] = true;
                inMuehle[k, 7] = true;
                foundMuehleSwz = true;
            }
        }

        for (int l = 1; l < 8; l = l + 2) // Mühlen mit gleichem Place
        {
            if (colourArray2dim[0, l] == 's' && colourArray2dim[1, l] == 's' && colourArray2dim[2, l] == 's')
            {
                inMuehle[0, l] = true;
                inMuehle[1, l] = true;
                inMuehle[2, l] = true;
                foundMuehleSwz = true;
            }
        }

        //Debug.Log("foundMuehleSwz: " + foundMuehleSwz);

        #endregion

    }   



 public static void  findMuehleWss()
    { 


        #region Muehle Wss
        

        for (int k = 0; k < 3; k++) // nachfolgende Mühlen
        {
            for (int l = 0; l < 5; l = l + 2)
            {
                if (colourArray2dim[k, l] == 'w' && colourArray2dim[k, l + 1] == 'w' && colourArray2dim[k, l + 2] == 'w')
                {
                    inMuehle[k, l] = true;
                    inMuehle[k, l + 1] = true;
                    inMuehle[k, l + 2] = true;
                    foundMuehleWss = true;
                }
            }
        }

        for (int k = 0; k < 3; k++) // Mühlen mit 0 am Ende
        {
            if (colourArray2dim[k, 0] == 'w' && colourArray2dim[k, 6] == 'w' && colourArray2dim[k, 7] == 'w')
            {
                inMuehle[k, 0] = true;
                inMuehle[k, 6] = true;
                inMuehle[k, 7] = true;
                foundMuehleWss = true;
            }
        }

        for (int l = 1; l < 8; l = l + 2) // Mühlen mit gleichem Place
        {
            if (colourArray2dim[0, l] == 'w' && colourArray2dim[1, l] == 'w' && colourArray2dim[2, l] == 'w')
            {
                inMuehle[0, l] = true;
                inMuehle[1, l] = true;
                inMuehle[2, l] = true;
                foundMuehleWss = true;
            }
        }

       // Debug.Log("foundMuehleWss: " + foundMuehleWss);
       
        #endregion
}

 public static void eraseMuehle()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                inMuehle[i, j] = false;
            }
        }

       // Debug.Log("Mühlen gelöscht");
    }
       
       
}
    

 
    

 

