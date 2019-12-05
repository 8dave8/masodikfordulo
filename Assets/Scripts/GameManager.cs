using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject simulation;
    //runtime
    public float vizSzint;
    public float KWH;
    public float termeltKWH;
    public Text TXtermeltAram;
    public Text TXtermeltKWH;
    public Text vizszint;
    public GameObject deathScene;
    public Text DeathText;
    private bool alive;
    private System.Random vizrandomizer;


    private List<Vector3Int> elozoLerakotEpitmenyekHelyeKoordinatakban; //donmai, kore namae wa meme desu
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
        vizrandomizer = new System.Random();
        alive = true;
        Lerakando = 4;
        vizSzint = 50;
        buildings = new int[4];
        tmp = new Vector3Int(0,0,0);
        elozoLerakotEpitmenyekHelyeKoordinatakban = new List<Vector3Int>();
        Buttons.SetActive(false);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (simulation.activeSelf && alive)
        {
            Epites();
            runTime();
        }
    }

    private void runTime()
    {
        if (!(vizSzint > 10 && vizSzint < 90))
        {
            DeathText.text = "Kitermelt áram: " + termeltKWH + " kW";
            deathScene.SetActive(true);
            alive = false;
        }
            vizSzint += vizbeszabalyzo.value * Time.deltaTime;
            vizSzint -= (buildings[0] + (buildings[3] * 1.215f) - buildings[2] * 0.8765f) * (vizrandomizer.Next(912, 1087) / 1000) * Time.deltaTime; 
            KWH = 0;
            KWH = (buildings[0] * 10);
            KWH += (buildings[0] * 10) * (buildings[1] * 1.5f);
            KWH += (buildings[0] * 10) * (buildings[2] * 2f);
            KWH += (buildings[0] * 10) * (buildings[3] * 5);
            termeltKWH += KWH * Time.deltaTime;
            TXtermeltAram.text = "Termelés: " + KWH + "kW/h";
            TXtermeltKWH.text = "kitermelt áram: " + Mathf.Round(termeltKWH) + "kW";
            vizszint.text = "vizszint: "+Mathf.Round(vizSzint*10)/10+" %";
            slidertext.text = Mathf.Round(vizbeszabalyzo.value*10)/10+"";
    }

    private void Epites()
    {
        if (Input.touchCount > 0 && selectionIsActive)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = highlightMap.WorldToCell(worldPoint);
            if (position.x < -1.5f) return; // nemenged belenyulni a kiirasba
            else tmp = position;
            Debug.Log(worldPoint);
        }
        if (selectionIsActive) Buttons.SetActive(true);
        if (Buttons.activeSelf && Lerakando != 4 && !elozoLerakotEpitmenyekHelyeKoordinatakban.Contains(tmp)) { 
                buildings[Lerakando]++; 
                lerakandoSprite.GetComponent<SpriteRenderer>().sprite = Sprites[Lerakando];
                Instantiate(lerakandoSprite, tmp, Quaternion.identity);
                selectionIsActive = false;
                Buttons.SetActive(false);
                buildBT.SetActive(true);
                Lerakando = 4;
            elozoLerakotEpitmenyekHelyeKoordinatakban.Add(tmp);
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
}
