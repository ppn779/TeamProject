using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    // 타일 상태
    public bool walkable = true;    // 갈 수 있는지
    public bool current = false;    // 현재 위치
    public bool target = false;     // 타겟 선택
    public bool selectable = false; // 선택 가능

    public List<Tile> adjacencyList = new List<Tile>(); // 인접 타일

    // BFS(breadth first search) 광범위한 첫 탐색
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (current)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if (target)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (selectable)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void Reset()
    {
        adjacencyList.Clear();

        walkable = true;   
        current = false;    
        target = false;   
        selectable = false; 


        visited = false;
        parent = null;
        distance = 0;
    }

    public void FindNeighbors(float jumpHeight)
    {
        Reset();

        CheckTile(Vector3.forward, jumpHeight);
        CheckTile(Vector3.back, jumpHeight);
        CheckTile(Vector3.right, jumpHeight);
        CheckTile(Vector3.left, jumpHeight);
    }

    public void CheckTile(Vector3 dir, float jumpHeight)
    {
        Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + dir, halfExtents);

        foreach (Collider item in colliders)
        {
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.walkable)
            {
                RaycastHit hit;

                if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
                {
                    adjacencyList.Add(tile);
                }
            }
        }
    }
}
