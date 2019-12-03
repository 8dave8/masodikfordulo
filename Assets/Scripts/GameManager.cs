using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GameManager : MonoBehaviour
{
    public Sprite[] Sprites; 
    public GameObject Buttons;
    public Tile[] Tiles;
    public Tilemap highlightMap;
    private Vector3Int previous;
    private int Lerakando;
    private Vector3Int tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = new Vector3Int(0,0,0);
        Buttons.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Buttons.SetActive(true);
            Touch touch = Input.GetTouch(0);
            /* 
            Vector3Int currentCell = highlightMap.WorldToCell(touch.rawPosition);
            //currentCell.x += 1;  
            highlightMap.SetTile(currentCell,Tiles[Lerakando]);
            */
            //setactive valaszto menu
            
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = highlightMap.WorldToCell(worldPoint);
            Debug.Log(position);
            if(position.x < -2) position = tmp;// nemenged belenyulni a kiirasba
            else tmp = position; 
            TileBase tile = highlightMap.GetTile(position);
            Tiles[Lerakando].sprite = Sprites[Lerakando];
            highlightMap.SetTile(position, Tiles[Lerakando]);
            highlightMap.RefreshTile(position);
            Debug.Log(position+" "+ Tiles[Lerakando]);
        }
    }
    public void lerakando(int id)
    {
        Lerakando = id;
        Buttons.SetActive(false);
    }
}
