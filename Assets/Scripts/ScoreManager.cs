using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region PRIVATE VARIABLES
    private int score;
    #endregion
    #region SINGLETON CLASS
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ScoreManager();
                if (instance == null)
                {
                    GameObject container = GameObject.Find("ScoreManager");
                    instance = container.GetComponent<ScoreManager>();
                }
            }
            return instance;

        }
    }
    #endregion
    #region PUBLIC METHODS
    public void Score(int value)
    {
        score += value;
    }
    #endregion

}
