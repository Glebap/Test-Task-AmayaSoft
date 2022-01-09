using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;

    [System.Serializable]
    public class Level
    {
        public string name;
        public int rows;
        public int columns;
    }
}
