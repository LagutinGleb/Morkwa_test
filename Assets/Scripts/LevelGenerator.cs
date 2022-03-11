using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject[] floorSector;
    public GameObject prefabOfBlock;
    private string floorSectorTag = "FloorSector";

    void Start()
    {
        floorSector = GameObject.FindGameObjectsWithTag(floorSectorTag);
        GenerateLevel();
    }

    private void GenerateLevel() // устанавливаем блоки с вероятностью 50/50, при этом на карте оставлены пути для избежания ситуации с невозможностью прохождения уровня
    {
        foreach (GameObject obj in floorSector)
        {
            if (Randomizer())
            {
                Instantiate(prefabOfBlock, obj.transform);
            }
        }
    }

    private bool Randomizer()
    {
        if (Random.Range(0, 2) == 0)
        {
            return true;
        }
        else
        { return false; }
    }
}
