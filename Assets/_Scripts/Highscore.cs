using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

[Serializable]
public class Highscore
{
    public const string UsernameKey = "Username";
    public const string HighscoreFile = "highscores.json";

    public string PlayerName;
    public string Level;
    public DateTime Time;
    public int Moves;

    public Highscore(string playerName, string level, DateTime time, int moves)
    {
        PlayerName = playerName;
        Level = level;
        Time = time;
        Moves = moves;
    }

    public Highscore(string playerName, string level, int moves) : this(playerName, level, DateTime.Now, moves)
    {
    }

    public Highscore(string level, int moves)
    {
        PlayerName = PlayerPrefs.GetString(UsernameKey);
        Time = DateTime.Now;
        Level = level;
        Moves = moves;
    }

    public static HighscoreWrapper ReadHighScores()
    {
        if (!File.Exists(HighscoreFile))
            return new HighscoreWrapper();

        string highscoresText = File.ReadAllText(HighscoreFile, Encoding.UTF8);
        return JsonUtility.FromJson<HighscoreWrapper>(highscoresText);
    }

    public static void SetHighScores(HighscoreWrapper highscores)
    {
        string json = JsonUtility.ToJson(highscores, true);
        File.WriteAllText(HighscoreFile, json, Encoding.UTF8);
    }

    public static void AddHighscore(Highscore highscore)
    {
        HighscoreWrapper highscores = ReadHighScores();
        highscores.Highscores.Add(highscore);
        SetHighScores(highscores);
    }

    public static void AddHighscoreAsync(Highscore score)
    {
        new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            AddHighscore(score);
        }).Start();
    }
}

[Serializable]
public class HighscoreWrapper
{
    public List<Highscore> Highscores;

    public HighscoreWrapper(List<Highscore> highscores)
    {
        Highscores = highscores;
    }

    public HighscoreWrapper() : this(new List<Highscore>())
    {
    }
}