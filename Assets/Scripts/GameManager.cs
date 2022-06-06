using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PRIVATE VARIABLES

    #endregion
    #region SINGLETON CLASS
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
                if(instance==null)
                {
                    instance = GameObject.Find("GameManager").GetComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    #region PUBLIC METHODS
    public void ActivatingSuperPower(GameObject obj)
    {
        obj.transform.localScale += Vector3.one;
    }
    public void ActivatingMegaPower(GameObject obj)
    {
        // Blue colour Particle effect for player 
    }
    #endregion
}
