using System;
using UnityEngine;


public class Cell : MonoBehaviour
{   
    private int firstRow; 

    public bool isEmpty;    
    public int row;
    public int col;
    public FieldItem cellItem;

    public static event Action<Cell> OnCellEmpty, MakeNewItem;
    private void Start() => firstRow = Cell_Setup.cellArray.GetLength(0) - 1;

    private void Update()
    {
        if (isEmpty)
        { 
            if(cellItem) Destroy(cellItem.gameObject);

            if (row == firstRow) MakeNewItem?.Invoke(this);
            else OnCellEmpty?.Invoke(this);
        }

        if (cellItem == null)isEmpty = true;            
    }   
}