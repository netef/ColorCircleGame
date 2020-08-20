using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private static GameManagerScript instance = null;
    public static GameManagerScript GetInstance()
    {
        if (instance == null) instance = new GameManagerScript();
        return instance;
    }
}
