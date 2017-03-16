using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public UIManager UIManager;
    public QuestManager QuestManager;
    public GameObject[] Doors;

    void Awake()
    {
        if (instance == null) instance = this;

        Debug.Assert(UIManager != null);
        Debug.Assert(QuestManager != null);
        
    }

    void Start()
    {
        QuestManager.StartQuests();
    }

	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.timeScale > 0f)
            {
                Time.timeScale = 0f;
                UIManager.ShowPauseMenu();
            }
            else
            {
                UIManager.HidePauseMenu();
                Time.timeScale = 1f;
            }
        }	
	}

    public void ResetGame()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ToggleDoors()
    {
        foreach (var door in Doors)
        {
            door.SetActive(!door.activeInHierarchy);
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
}
