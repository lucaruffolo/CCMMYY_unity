﻿using Assets.Scripts.EmbASP.Utility;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //--------------------------------------------------------
    // Game variables

    public static int Level = 0;
    public static int lives = 3;

	public enum GameState { Init, Game, Dead, Scores }
	public static GameState gameState;

    private GameObject pacman;
    private GameObject blinky;
    private GameObject pinky;
    private GameObject inky;
    private GameObject clyde;

	public static bool scared;
    static public int score;

	public float scareLength;
	private float _timeToCalm;

    public float SpeedPerLevel;
    
    //-------------------------------------------------------------------
    // singleton implementation
    private static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    //-------------------------------------------------------------------
    // function definitions

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(this != _instance)   
                Destroy(this.gameObject);
        }

        AssignGhosts();
    }

	void Start () 
	{
		gameState = GameState.Init;
	}
    /*
    void OnLevelWasLoaded()
    {
        if (Level == 0) lives = 3;

        Debug.Log("Level " + Level + " Loaded!");
        AssignGhosts();
        ResetVariables();

        
     //   EmbASPManager.Instance.GenerateCharacters();
    }
    */

    private void ResetVariables()
    {
        _timeToCalm = 0.0f;
        scared = false;
    }

    // Update is called once per frame
	void Update () 
	{
		if(scared && _timeToCalm <= Time.time)
			CalmGhosts();

	}

	public void ResetScene()
	{
        CalmGhosts();

		pacman.transform.position = new Vector3(15f, 11f, 0f);
		blinky.transform.position = new Vector3(15f, 20f, 0f);
		pinky.transform.position = new Vector3(14.5f, 17f, 0f);
		inky.transform.position = new Vector3(16.5f, 17f, 0f);
		clyde.transform.position = new Vector3(12.5f, 17f, 0f);
        
        gameState = GameState.Init;  

	}

	public void ToggleScare()
	{
		if(!scared)	ScareGhosts();
		else 		CalmGhosts();
	}

	public void ScareGhosts()
	{
		scared = true;
		_timeToCalm = Time.time + scareLength;

        Debug.Log("Ghosts Scared");
	}

	public void CalmGhosts()
	{
		scared = false;
    }

    void AssignGhosts()
    {
        // find and assign ghosts
        clyde = GameObject.Find("clyde");
        pinky = GameObject.Find("pinky");
        inky = GameObject.Find("inky");
        blinky = GameObject.Find("blinky");
        pacman = GameObject.Find("pacman");

        if (clyde == null || pinky == null || inky == null || blinky == null) Debug.Log("One of ghosts are NULL");
        if (pacman == null) Debug.Log("Pacman is NULL");
        

    }

    public void LoseLife()
    {
        lives--;
        gameState = GameState.Dead;
    }

    public static void DestroySelf()
    {
        score = 0;
        Level = 0;
        lives = 3;
        Destroy(GameObject.Find("Game Manager"));
    }
}
