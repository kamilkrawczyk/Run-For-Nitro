using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataPersistence 
{
    private static int lives, cameras, cups, score;
    private static float time;
    //funkcje do dodawania i czytania zmiennych:
    public static int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }
    public static int Cameras
    {
        get
        {
            return cameras;
        }
        set
        {
            cameras = value;
        }
    }
    public static int Cups
    {
        get
        {
            return cups;
        }
        set
        {
            cups = value;
        }
    }
    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    public static float Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
        }
    }
}
