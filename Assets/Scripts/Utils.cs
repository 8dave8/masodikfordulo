using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Utils : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject simulation;
    [SerializeField] GameObject tutorial;
    public void Begin()
    {
        menu.SetActive(false);
        simulation.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
    }
    public void Tutorial()
    {
        tutorial.SetActive(true);
    }
}
