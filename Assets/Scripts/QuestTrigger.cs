using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public int questId;
    public bool startPoint, endPoint;
    public bool acceptQuestAutomatically;
    private QuestManager questManagerScript;
    private bool playerInZone;

    // Start is called before the first frame update
    void Start()
    {
        questManagerScript = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone)
        {
            if (acceptQuestAutomatically || (!acceptQuestAutomatically && Input.GetKeyDown(KeyCode.M)))
            {
                Quest q = questManagerScript.GetQuestWithId(questId);

                if (q == null)
                {
                    //Message in development fase
                    Debug.LogErrorFormat("La misión con id {0} no existe", questId);
                    return;
                }
                if (!q.questCompleted)
                {
                    if (startPoint)
                    {
                        if (!q.gameObject.activeInHierarchy)
                        {
                            q.gameObject.SetActive(true);
                            q.StartQuest();
                        }
                    }

                    if (endPoint)
                    {
                        if (q.gameObject.activeInHierarchy)
                        {
                            q.CompleteQuest();
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            playerInZone = false;
        }
    }
}
