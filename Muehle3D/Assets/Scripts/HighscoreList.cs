using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighscoreList : MonoBehaviour {

    public TextAsset highscores;
    public GameObject  Win_Name;
    public Text WinNameText;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Gameplay.GameOver)
        {
            Win_Name.SetActive(true);
        }
	}


    
    public void WriteString()
    {
        if (WinNameText.text != "")
        {

           
            Gameplay.GameOver = false;
            string path = "Assets/Resources/Highscores.txt";

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("Name: "+WinNameText.text+"     Zuege: "+Gameplay.WinTurn); //Schreibt Name und Anzahl der benötigten Züge in die Text-Datei
            writer.Close();
        }

       
        
        
    }

   
   


}
