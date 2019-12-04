using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //runtime
    public float vizSzint;
    public float KWH;
    public float termeltKWH;
    public Text TXtermeltAram;
    public Text TXtermeltKWH;
    public Text vizszint;
    public GameObject deathScene;
    public Text DeathText;
    


    private Vector3Int elozoLerakotEpitmenyHelyeKoordinatakban;
    //epites
    public int[] buildings;
    public Sprite[] Sprites;
    public GameObject Buttons;
    public Tilemap highlightMap;
    private Vector3Int previous;
    private int Lerakando;
    private Vector3Int tmp;
    public bool selectionIsActive = false;
    public GameObject lerakandoSprite;
    private static Vector3 worldPoint;
    public GameObject buildBT;

    public Slider vizbeszabalyzo;
    public Text slidertext;

    // Start is called before the first frame update
    void Start()
    {
        Lerakando = 4;
        vizSzint = 50;
        buildings = new int[4];
        tmp = new Vector3Int(0,0,0);
        elozoLerakotEpitmenyHelyeKoordinatakban = tmp;
        Buttons.SetActive(false);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Epites();
        runTime();
    }

    private void runTime()
    {
        if (vizSzint > 10 && vizSzint < 90)
        {
            vizSzint += vizbeszabalyzo.value * Time.deltaTime;
            vizSzint -= buildings[0] * Time.deltaTime; 
            KWH = 0;
            KWH = (buildings[0] * 10);
            KWH += (buildings[0] * 10) * (buildings[1] * 1.5f);
            KWH += (buildings[0] * 10) * (buildings[2] * 2f);
            KWH += (buildings[0] * 10) * (buildings[3] * 5);
            termeltKWH += KWH * Time.deltaTime;
            TXtermeltAram.text = KWH + " kW/h";
            TXtermeltKWH.text = termeltKWH + " kW";
            vizszint.text = "vizszint: "+Mathf.Round(vizSzint*10)/10+" %";
            slidertext.text = Mathf.Round(vizbeszabalyzo.value*10)/10+"";
        }
        else {
            Time.timeScale = 0f;
            deathScene.SetActive(true);
            DeathText.text = termeltKWH + " kW";
        }
    }

    private void Epites()
    {
        if (Input.touchCount > 0 && selectionIsActive)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = highlightMap.WorldToCell(worldPoint);
            if (position.x < -1.5f) position = tmp; // nemenged belenyulni a kiirasba
            else tmp = position;
            //Debug.Log(worldPoint);
        }
        if (selectionIsActive) Buttons.SetActive(true);
        if (Buttons.activeSelf && Lerakando != 4 && elozoLerakotEpitmenyHelyeKoordinatakban != tmp) { 
                buildings[Lerakando]++; 
                lerakandoSprite.GetComponent<SpriteRenderer>().sprite = Sprites[Lerakando];
                Instantiate(lerakandoSprite, tmp, Quaternion.identity);
                selectionIsActive = false;
                Buttons.SetActive(false);
                buildBT.SetActive(true);
                Lerakando = 4;
            elozoLerakotEpitmenyHelyeKoordinatakban = tmp;
        }
    }

    public void lerakando(int id)
    {
        Lerakando = id;
        Buttons.SetActive(false);
    }
    public void setSelectionToActive()
    {
        selectionIsActive = true;
    }
    public void Reload()
    {
        SceneManager.LoadScene("Samplescene");
    }
}
