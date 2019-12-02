using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GameManager : MonoBehaviour
{
    public GameObject Buttons;
    public Tile[] Tiles;
    public Tilemap highlightMap;
    private Vector3Int previous;
    private int Lerakando;
    // Start is called before the first frame update
    void Start()
    {
        Buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Buttons.SetActive(true);
            Touch touch = Input.GetTouch(0);
            Vector3Int currentCell = highlightMap.WorldToCell(touch.position);
            //currentCell.x += 1;  
            highlightMap.SetTile(currentCell,Tiles[Lerakando]);
            //setactive valaszto menu
            Debug.Log(currentCell+"  "+Lerakando);
        }
    }
    public void lerakando(int id)
    {
        Lerakando = id;
        Buttons.SetActive(false);
    }
}
