using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell_Setup : MonoBehaviour
{
    public static Cell[,] cellArray;
    [SerializeField] private int rows = 6;
    [SerializeField] private int collumns = 4;
    [SerializeField] private Cell cellPrefab;
    
    private void Awake()
    {
        cellArray = new Cell[rows, collumns];        
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < collumns; col++)
            {
                float yPos = row;
                float xPos = col;

                Cell newCell = Instantiate(cellPrefab, new Vector3(xPos, yPos), cellPrefab.transform.rotation);
                newCell.isEmpty = true;
                newCell.transform.SetParent(gameObject.transform);
                newCell.row = row;
                newCell.col = col;
                cellArray[row, col] = newCell;
            }
        }
    }
}
