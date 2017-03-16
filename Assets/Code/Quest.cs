using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest : MonoBehaviour
{
    public string Title;
    public string Description;
    public string StartTaskID;

    public List<QuestTask> QuestTasks;
    public QuestTask ActiveTask { get; set; }

    private UIManager uiManager;


    private bool IsValidTask(string taskID)
    {
        foreach (var task in QuestTasks)
        {
            if (task.TaskID == taskID)
            {
                return true;
            }
        }
        return false;
    }

    public QuestTask ToTask(string taskID)
    {
        Debug.Assert(StartTaskID != null && StartTaskID != "", "StartTaskID is empty");
        Debug.Assert(IsValidTask(taskID), "Undefined TaskID");

        foreach (var task in QuestTasks)
        {
            if (task.TaskID == taskID)
            {
                return task;
            }
        }
        return null;
    }

    public void CompleteActiveTask()
    {
        CompleteTask(ActiveTask);
    }

    public void CompleteTask(string taskID)
    {
        CompleteTask(ToTask(taskID));
    }

    public void CompleteTask(QuestTask task)
    {
        if (task != ActiveTask) return;

        OnEndTask(task);

        int nextIndex = QuestTasks.IndexOf(task) + 1;

        // All tasks have been completed
        if (QuestTasks.Count == nextIndex)
        {
            ActiveTask = null;
            GameManager.GetInstance().QuestManager.CompleteQuest(this);
        }
        else
        {
            ActiveTask = QuestTasks[nextIndex];
            OnBeginTask(ActiveTask);
        }
    }

    public void OnBeginTask(QuestTask task)
    {
        Debug.Log("BEGIN TASK: " + task.TaskID);
        uiManager.ShowTaskInfo(task);
    }

    public void OnEndTask(QuestTask task)
    {
        uiManager.HideTaskInfo();
        Debug.Log("END TASK: " + task.TaskID);
    }

    public void OnTriggerBoxEnterProxy(QuestTriggerBox trigger)
    {
        if (trigger.CompleteTaskOnTrigger)
        {
            if (trigger.Collider.tag == "Player" && ActiveTask == ToTask(trigger.ID))
            {
                CompleteActiveTask();
            }
        }
        else
        {
            OnTriggerBoxEnter(trigger.ID, trigger.Collider);
        }
    }

    public virtual void OnTriggerBoxEnter(string id, Collider collider)
    {
        Debug.Log("Not Implemented: OnTriggerBoxEnter");
    }

    void Awake()
    {
        Debug.Assert(IsValidTask(StartTaskID), "Unknown StartTaskID");

        uiManager = GameManager.GetInstance().UIManager;
    }

    public void OnBeginQuest()
    {
        ActiveTask = ToTask(StartTaskID);

        uiManager.ShowQuestDialog(this);

        OnBeginTask(ActiveTask);
    }

    public void OnEndQuest()
    {
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class QuestTask
{
    public string TaskID;
    public string Text;
}