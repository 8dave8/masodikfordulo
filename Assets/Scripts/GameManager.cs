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
    private bool selectionIsActive = false;
    private int[] buildings;
    // Start is called before the first frame update
    void Start()
    {
        buildings[0] = 0;
        buildings[0] = 0;
        buildings[0] = 0;
        buildings[0] = 0;
        Lerakando = 4;
        tmp = new Vector3Int(0,0,0);
        Buttons.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = highlightMap.WorldToCell(worldPoint);
            if(position.x < -2) position = tmp; // nemenged belenyulni a kiirasba
            else tmp = position;
            Debug.Log(position);
        }
        Buttons.SetActive(true);
        if(Buttons.activeSelf && Lerakando != 4)
        {            
            Tiles[Lerakando].sprite = Sprites[Lerakando];            
        }
    }
    public void lerakando(int id)
    {
        Lerakando = id;
        Buttons.SetActive(false);
    }
}
