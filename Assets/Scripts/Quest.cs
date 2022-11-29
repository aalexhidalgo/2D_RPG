using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questId;
    public bool questCompleted;
    public string title;
    public string startText;
    public string completedText;
    private QuestManager questManagerScript;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest()
    {
        questManagerScript = FindObjectOfType<QuestManager>();
        questManagerScript.ShowQuestText($"{title}\n{completedText}");
        questCompleted = true;
        gameObject.SetActive(false);
    }

    public void CompleteQuest()
    {
        questManagerScript = FindObjectOfType<QuestManager>();
        questManagerScript.ShowQuestText($"{title}\n{ completedText}");
        questCompleted = true;
        gameObject.SetActive(false);
    }
}
