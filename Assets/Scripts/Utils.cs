using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public void Restart(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
