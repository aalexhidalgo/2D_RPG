using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;
    private DialogManager dialogManagerScript;

    void Start()
    {
        dialogManagerScript = FindObjectOfType<DialogManager>();
        foreach (Transform t in transform)
        {
            quests.Add(t.gameObject.GetComponent<Quest>());
        }
    }

    public void ShowQuestText(string questText)
    {
        dialogManagerScript.ShowDialog(new string[] { questText });
    }

    public Quest GetQuestWithId(int id)
    {
        Quest q = null;
        foreach (Quest temp in quests)
        {
            if (temp.questId == id)
            {
                q = temp;
            }
        }
        return q;
    }
}
