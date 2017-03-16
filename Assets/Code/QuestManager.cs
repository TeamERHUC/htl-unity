using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] Quests { get; private set; }
    public Quest ActiveQuest { get; private set; }
    public bool CompletedAllQuests { get; set; }

    void Awake()
    {

    }

    public void StartQuests()
    {
        CompletedAllQuests = false;
        Quests = GetComponentsInChildren<Quest>();
        if (Quests[0] == null)
        {
            Debug.Log("No quests found");
            CompletedAllQuests = true;
            return;
        }

        ActiveQuest = Quests[0];
        ActiveQuest.OnBeginQuest();
    }

    public void CompleteQuest(Quest quest)
    {
        int nextIndex = Array.IndexOf<Quest>(Quests, quest) + 1;

        quest.OnEndQuest();
        // we've completed all quests
        if (Quests.Length == nextIndex)
        {
            CompletedAllQuests = true;
            ActiveQuest = null;
        }
        else
        {
            ActiveQuest = Quests[nextIndex];
            ActiveQuest.OnBeginQuest();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
