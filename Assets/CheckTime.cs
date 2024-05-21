using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class CheckTime : MonoBehaviour
{
    private string score_value;
    private string last_connexion_value;
    private string current_connexion_value;
    private string save;
    private int counter;
    public float interval = 2f;
    private float timeSinceLastAction = 0f;
    private int lostStreak = 0;
    private int winStreak = 0; 

    private void displayLostStreak()
    {
        if (lostStreak == 0) {
            if (File.Exists(save)) {
                string[] lines = File.ReadAllLines(save);
                lines[2] = "streak:0";
                File.WriteAllLines(save, lines);
            }
            SceneManager.LoadSceneAsync("StreakLost", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("SampleScene");
            SceneManager.UnloadSceneAsync("font");
        }
        lostStreak = 1;
    }

    private void checkWinStreak()
    {
        if (winStreak == 0) {
            if(File.Exists(save)) {
                string[] lines = File.ReadAllLines(save);
                string[] streak_line = lines[2].Split(':');
                int streak = int.Parse(streak_line[1]) + 1;
                lines[2] = "streak:" + streak.ToString();
                File.WriteAllLines(save, lines);
            }
            winStreak = 1;
        }
    }

    private void getApi()
    {
        if (!WorldTimeAPI.Instance.isTimeLoaded) {
            if (counter == 100)
                return;
            counter++;
            getApi();
        }

        DateTime currentDateTime = WorldTimeAPI.Instance.GetCurrentDateTime();
        current_connexion_value = currentDateTime.ToString("dd/MM/yyyy");
        last_connexion_value = last_connexion_value.Trim();
        current_connexion_value = current_connexion_value.Trim();
        DateTime lastConnectionDate = DateTime.ParseExact(last_connexion_value, "dd/MM/yyyy", null);
        DateTime currentConnectionDate = DateTime.ParseExact(current_connexion_value, "dd/MM/yyyy", null);
        TimeSpan difference = currentConnectionDate - lastConnectionDate;
        int daysPassed = (int)difference.TotalDays;
        if (daysPassed > 1) {
            Debug.Log("You have lost your streak: " + daysPassed + " days have passed since last connection.");
            displayLostStreak();
        }
        if (daysPassed == 1) {
            Debug.Log("You have one more day of streak: " + daysPassed);
            checkWinStreak();
        }
    }

    void Start()
    {
        counter = 0;
        save = Application.dataPath + "/../save.db";
        if (File.Exists(save)) {
            Debug.Log("File found : " + save);
            string[] content = File.ReadAllText(save).Split('\n');
            string[] last_connexion = content[0].Split(':');
            string[] score = content[1].Split(':');
            score_value = score[1];
            last_connexion_value = last_connexion[1];
            Debug.Log("last connexion : " + last_connexion_value);
            getApi();
        }
        else
            Debug.Log("File not found: " + save);
    }

    void Update()
    {
        timeSinceLastAction += Time.deltaTime;
        if (timeSinceLastAction >= interval) {
            if (File.Exists(save)) {
                getApi();
                string[] lines = File.ReadAllLines(save);
                lines[0] = "last_connexion:" + current_connexion_value;
                last_connexion_value = current_connexion_value;
                File.WriteAllLines(save, lines);
                Debug.Log("Action executed at: " + Time.time);
            } else
                Debug.Log("je rentre pas dans le if >:(" + counter);
            timeSinceLastAction = 0f;
        }
    }
}
