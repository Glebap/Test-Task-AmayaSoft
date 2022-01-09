using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellSpawner : MonoBehaviour
{

	[SerializeField]
	public CellBundle[] CellBundles;

	[SerializeField]
	public GameObject cellPrefab;

	[SerializeField]
	public GameObject panel;


	private List<GameObject> cellsList = new List<GameObject>();

	private List<string> usedTasks = new List<string>();

	private List<string> usedOptions = new List<string>();

	public void SpawnCells(int n)
	{
		ClearPanel();

		int option;
		CellBundle currentBundle = CellBundles[Random.Range(0, CellBundles.Length)];

		while(n-- != 0)
		{
			do
			{
				option = Random.Range(0, currentBundle.ansverOption.Count);
			}
			while(usedOptions.Contains(currentBundle.ansverOption[option]));

			GameObject cell = Instantiate(cellPrefab, panel.transform);

			cell.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = currentBundle.sprites[option];
			usedOptions.Add(currentBundle.ansverOption[option]);
			cellsList.Add(cell);

			SetColour(cell);
		}

		CreateTaskOption();
	}

	private void SetColour(GameObject cell)
	{
		int[] colours = {0, 0, 0};
		int stable = 0;
		int mutable = Random.Range(0, 3);
		colours[mutable] = Random.Range(150, 256);

		for (int i = 0; i < 3; i++)
		{
			if (i != mutable && stable == 0)
			{
				stable = Random.Range(0, 2) == 0 ? 150 : 255;
				colours[i] = stable;
			}

			if (colours[i] == 0)
			{
				colours[i] = stable == 150 ? 255 : 150;
			}
		}
		int R = colours[0];
		int G = colours[1];
		int B = colours[2];
		cell.GetComponent<Image>().color = new Color32((byte)R, (byte)G, (byte)B, 255);
	}

	private void CreateTaskOption()
	{
		int answer;

		do
		{
			answer = Random.Range(0, cellsList.Count);
		}
		while(usedTasks.Contains(usedOptions[answer]));

		cellsList[answer].GetComponent<Cell>().MarkAsAnswer();
		FindObjectOfType<TaskText>().CreateTask(usedOptions[answer]);
		usedTasks.Add(usedOptions[answer]);
	}

	public void ClearUsedTasks()
	{
		usedTasks.Clear();
	}

	private void ClearPanel()
	{
		usedOptions.Clear();
		foreach (GameObject cell in cellsList)
		{
			DestroyImmediate(cell);
		}
		cellsList.Clear();
	}


}
