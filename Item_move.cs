using System;
using System.Collections;
using UnityEngine;

public class Item_move : MonoBehaviour
{
    private bool isMoving = false;
    private Cell[,] cellArray;
    public static event Action OnTileMoved;

    private void OnEnable() => Cell.OnCellEmpty += FillEmptyCell;
    private void OnDisable() => Cell.OnCellEmpty -= FillEmptyCell;
    private void Start() => cellArray = Cell_Setup.cellArray;

    private void FillEmptyCell(Cell currentCell)
    {
        Cell upperCell = cellArray[currentCell.row + 1, currentCell.col];
        if (currentCell.isEmpty && upperCell.cellItem != null)
            StartCoroutine(MoveItem_From_To(upperCell, currentCell));
    }

    public IEnumerator MoveItem_From_To(Cell from, Cell to)
    {
        if (!isMoving) //Do not start moving the item untill previous one is moving
        {
            isMoving = true;
            while (from.cellItem!=null && from.cellItem.transform.position != to.transform.position)
            {
                from.cellItem.transform.position = Vector3.MoveTowards(from.cellItem.transform.position, to.transform.position, 0.3f);
                yield return new WaitForEndOfFrame();                
            }OnTileMoved?.Invoke();

            to.isEmpty = false;            
            to.cellItem = from.cellItem;
            to.cellItem.itemCell = to;
            from.cellItem = null;
            from.isEmpty = true;
            
            isMoving =false;
        }        
    }
}
