using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadHighscore : MonoBehaviour {

    public Text Highscores;
    string text;


    /*
     * Noch nicht funktionsfähig
     * 
     * 
     * */






    // Use this for initialization
    void Start () {

        string path = "Assets/Resources/Highscores.txt";

       
        StreamReader reader = new StreamReader(path);
        text = reader.ReadLine();
        Highscores.text = text;
        reader.Close();
        
    
}
	
	// Update is called once per frame
	void Update () {
		
	}
}
