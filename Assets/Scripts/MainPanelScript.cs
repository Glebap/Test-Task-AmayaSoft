using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelScript : MonoBehaviour
{
    private int currentLevel;
    private int levelsQuantity;
    //private Level[] levels = FindObjectOfType<LevelManager>().levels;  

    // Start is called before the first frame update
    void Start()
    {
    	levelsQuantity = FindObjectOfType<LevelManager>().levels.Length;
        NewGame();
    }

    private void StartLevel()
    {
        int levelRows = FindObjectOfType<LevelManager>().levels[currentLevel].rows;
        int levelColumns = FindObjectOfType<LevelManager>().levels[currentLevel].columns;

        SetPanel(levelRows, levelColumns);
        FindObjectOfType<CellSpawner>().SpawnCells(levelColumns * levelRows);
    }

    private void SetPanel(int rows, int columns)
    {
    	int width = columns * 250;
    	int height = rows * 250;
    	GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    public void NextLevel()
    {
    	currentLevel += 1;
    	if (currentLevel < levelsQuantity)
    	{
    		StartLevel();
    	}
    	else
    	{
    		FindObjectOfType<GameOverScript>().SetUp();
    	}
 
    }

    public void NewGame()
    {
    	currentLevel = 0;
    	FindObjectOfType<CellSpawner>().ClearUsedTasks();
    	StartLevel();
    }
}
