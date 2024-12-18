using System.Collections.Generic;
using UnityEngine;

public class CreatDice : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Transform> diceParents;
    private Vector2Int randomPos = new Vector2Int();
    private GameObject[,] objects = new GameObject[2,3];


    private void Awake()
    {
        int count = 0;
        for(int i = 0; i < 2; i ++)
        {
            for(int j = 0; j < 3; j++)
            {
                objects[i,j] = diceParents[count++].gameObject;
            }
        }
    }
    public void Onclick()
    {
        Create();
    }

    public void Create()
    {
        int count = 0;
        
        for(int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(objects[i,j].transform.childCount > 0)
                {
                    count++;
                }
            }
        }

        if(count == 6) return;
        
          int randomIndex = Random.Range(0, prefabs.Count);
          GameObject randomPrefab = prefabs[randomIndex]; 

        randomPos.x = Random.Range(0, 2);
        randomPos.y = Random.Range(0, 3);

        if(objects[randomPos.x,randomPos.y].transform.childCount < 1)
        {
            Instantiate(randomPrefab, objects[randomPos.x, randomPos.y].transform);
        }
        else
        {
            Create();
        }
    }
}
