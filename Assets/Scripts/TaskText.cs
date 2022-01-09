using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TaskText : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI taskText;

    public void CreateTask(string task)
    {
        taskText.text = "Find " + task;
    }
}
