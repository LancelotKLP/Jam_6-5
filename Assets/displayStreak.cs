using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class displayStreak : MonoBehaviour
{
    private string save = Application.dataPath + "/../save.db";
    public Text streakCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(save))
        {
            string[] lines = File.ReadAllLines(save);
            string[] streakLine = lines[2].Split(':');
            string streak = streakLine[1];
            streakCounter.text = streak;
        }
    }
}
