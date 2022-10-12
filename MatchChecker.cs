using System;
using UnityEngine;

public class MatchChecker : MonoBehaviour
{
    private Cell[,] cellArray;
    private int rows, collumns;

    public static event Action<int> OnMatchMade;

    private void OnEnable() => FirstMatchCheck.SetCheck += SetCheck;
    private void OnDisable() => FirstMatchCheck.SetCheck -= SetCheck;

    private void Start()
    {
        cellArray = Cell_Setup.cellArray;
        rows = cellArray.GetLength(0);
        collumns = cellArray.GetLength(1);       
    }   
    public void SetCheck()
    {            
        if (collumns >= 3) HorizontalCheck();            
        if (rows >= 3) VerticalCheck();            
    }

    private void HorizontalCheck()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < collumns - 2; col++)
            {
                if (cellArray[row, col].cellItem.ID == cellArray[row, col + 1].cellItem.ID && cellArray[row, col].cellItem.ID == cellArray[row, col + 2].cellItem.ID)
                {                    
                    cellArray[row, col].isEmpty = true;
                    cellArray[row, col + 1].isEmpty = true;
                    cellArray[row, col + 2].isEmpty = true;

                    OnMatchMade?.Invoke(cellArray[row, col].cellItem.ID * 10);                    
                }
            }
        }
    }

    private void VerticalCheck()
    {
        for (int col = 0; col < collumns; col++)
        {
            for (int row = 0; row < rows - 2; row++)
            {
                if (cellArray[row, col].cellItem.ID == cellArray[row + 1, col].cellItem.ID && cellArray[row, col].cellItem.ID == cellArray[row + 2, col].cellItem.ID)
                {                    
                    cellArray[row, col].isEmpty = true;
                    cellArray[row + 1, col].isEmpty = true;
                    cellArray[row + 2, col].isEmpty = true;

                    OnMatchMade?.Invoke(cellArray[row, col].cellItem.ID * 10);
                }
            }
        }
    }
}
