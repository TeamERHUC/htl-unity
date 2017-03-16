using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggerBox : MonoBehaviour
{
    public bool CompleteTaskOnTrigger = true;
    public string ID;
    public Collider Collider { get; set; }


    void Awake()
    {
        Debug.Assert(ID != null && ID != "", "Undefined TriggerID");
    }

    void OnTriggerEnter(Collider other)
    {
        Collider = other;
        SendMessageUpwards("OnTriggerBoxEnterProxy", this);
    }

    void Start()
    {

    }


    void Update()
    {

    }
}