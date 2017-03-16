using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {


    public GameObject LoadingPanel;
    public GameObject MenuPanel;

	// Use this for initialization
	void Start () {

        LoadingPanel.SetActive(false);


        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }

    public void StartGame()
    {


        MenuPanel.SetActive(false);
        LoadingPanel.SetActive(true);


        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void ShowSettings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
