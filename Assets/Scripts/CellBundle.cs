using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CellBundle", menuName = "Cell Bundle")]
public class CellBundle : ScriptableObject
{
    public List<Sprite> sprites;
    public List<string> ansverOption;

    private List<int> usedCells;

    private void Reset()
    {
        usedCells.Clear();
    }
}
