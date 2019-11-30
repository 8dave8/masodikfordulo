using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject simulation;

    public void Begin()
    {
        menu.SetActive(false);
        simulation.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
