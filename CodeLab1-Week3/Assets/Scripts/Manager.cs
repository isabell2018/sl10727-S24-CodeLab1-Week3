using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Manager : MonoBehaviour
{
    public static Manager instance = null;
    
    private float time;
    
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    private int highScore;
    
    public int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            
            Debug.Log("score changed");

            if (score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    const string DATA_DIR = "/Data/";
    const string DATA_HS_FILE = "hs.txt";
    string DATA_FULL_HS_FILE_PATH;
    public int HighScore
    {
        get
        {
            if (File.Exists(DATA_FULL_HS_FILE_PATH))
            {
                string fileContents = File.ReadAllText(DATA_FULL_HS_FILE_PATH);//get all text in file
                highScore = Int32.Parse(fileContents);//read int in DATA_HS_FILE
            }
            return highScore;
        }

        set
        {
            highScore = value;
            Debug.Log("new high score");
            string fileContent = "" + highScore;
            
            //If no directory named string DATA_DIR's value exists, create one
            if (!Directory.Exists(Application.dataPath + DATA_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + DATA_DIR);
            }

            File.WriteAllText(DATA_FULL_HS_FILE_PATH, fileContent);
        }
    }
    
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        //name data file path after path+dir+name
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        scoreText.text = "Score: " + Score + 
                           "\nHigh Score: " + HighScore;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
