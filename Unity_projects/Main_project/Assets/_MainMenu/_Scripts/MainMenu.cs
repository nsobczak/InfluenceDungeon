using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Attributes

    [SerializeField] private static int maxInstanceCount = 1;
    private static int instanceCount = 0;

    #endregion

    //___________________________________________

    #region singleton

    private static MainMenu mainMenuInstance = null;

    public MainMenu()
    {
        ++instanceCount;
    }

    ~MainMenu() // destructor
    {
        --instanceCount;
    }

    public static MainMenu GetMainMenuInstance
    {
        get
        {
            if (mainMenuInstance == null)
                mainMenuInstance = new MainMenu();
            return mainMenuInstance;
        }
    }

    #endregion

    //___________________________________________

    void Start()
    {
        if (instanceCount > maxInstanceCount + 1)
            GameObject.Destroy(this.gameObject);
    }
}