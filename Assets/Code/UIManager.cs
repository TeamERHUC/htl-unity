using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject QuestPanel;
    public GameObject MenuPanel;
    public GameObject TaskInfo;


	void Start()
    {
        QuestPanel.SetActive(false);
        MenuPanel.SetActive(false);

        TaskInfo.SetActive(true);
    }
	
	void Update()
    {
		
	}


    public void ShowPauseMenu()
    {
        if (QuestPanel.activeSelf) return;


        MenuPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;


    }

    public void HidePauseMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MenuPanel.SetActive(false);
    }

    public void ShowQuestDialog(Quest quest)
    {
        // TODO: Put cursor logic in a method
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        QuestPanel.SetActive(true);

        // TODO: Find a better way to referece ui elements
        var title = GameObject.Find("QuestTitle").GetComponent<Text>();
        var desc = GameObject.Find("QuestDescription").GetComponent<Text>();

        title.text = quest.Title;
        desc.text = quest.Description;


    }

    public void HideQuestDialog()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        QuestPanel.SetActive(false);
    }

    public void ShowTaskInfo(QuestTask task)
    {
        TaskInfo.SetActive(true);
        var taskInfoText = GameObject.Find("TaskInfoText").GetComponent<Text>();
        taskInfoText.text = task.Text;
    }

    public void HideTaskInfo()
    {
        TaskInfo.SetActive(false);
    }
}
