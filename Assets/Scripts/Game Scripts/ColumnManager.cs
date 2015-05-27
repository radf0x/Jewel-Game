using UnityEngine;
using System.Collections;

public class ColumnManager : MonoBehaviour 
{
    public static ColumnManager instance;
    internal ColumnScript[] gameColumns;
    internal int numberOfColumns;
    

    void Awake()
    {
        instance = this;
        
    }
	
	void Start () 
    {
        numberOfColumns = LevelStructure.instance.numberOfColumns;

        gameColumns = new ColumnScript[numberOfColumns];

        for (int i = 0; i < gameColumns.Length; i++)
        {
            GameObject temp1 = new GameObject();
            gameColumns[i] = temp1.AddComponent<ColumnScript>();
            temp1.transform.parent = transform;
            temp1.name = "Column " + i.ToString();
        }

        float x = 2.5f;

        if (numberOfColumns % 2 == 1)
        {
            x = (numberOfColumns / 2) * GameManager.instance.gapBetweenObjects;
        }
        else
        {
            x = (numberOfColumns / 2) * GameManager.instance.gapBetweenObjects - GameManager.instance.gapBetweenObjects * .5f;
        }

        for (int i = 0; i < gameColumns.Length; i++)
        {
            if (i < numberOfColumns)
            {
                gameColumns[i].columnIndex = i;
                gameColumns[i].transform.localPosition = new Vector3(x - i * GameManager.instance.gapBetweenObjects, 0, 0);
            }
            else
                Destroy(gameColumns[i].gameObject);
        }

        ColumnScript[] temp = gameColumns;
        gameColumns = new ColumnScript[numberOfColumns];

        for (int i = 0; i < numberOfColumns; i++)
        {
            gameColumns[i] = temp[i];
        }
	
	}

    

}
