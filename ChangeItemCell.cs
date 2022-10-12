using System;
using UnityEngine;

public class ChangeItemCell : MonoBehaviour
{
    public static FieldItem sourceItem;
    public static FieldItem targetItem;   

    public static event Action OnMoveDone;

    private void OnEnable() => FieldItem.SetItemsChange += ItemsChange;

    private void OnDisable() => FieldItem.SetItemsChange -= ItemsChange;

    public void ItemsChange()
    {
        Cell sourceCell = sourceItem.itemCell; 
        Cell targetCell = targetItem.itemCell;

        //Check if items are neighbours by row OR by collumn
        if ((Math.Abs(targetCell.row - sourceCell.row) == 1 && targetCell.col == sourceCell.col)|| 
            (Math.Abs(targetCell.col - sourceCell.col) == 1 && targetCell.row == sourceCell.row))
        {
            sourceCell.cellItem = targetItem;
            targetCell.cellItem = sourceItem;

            targetItem.transform.position = sourceCell.transform.position;
            sourceItem.transform.position = targetCell.transform.position;

            targetItem.itemCell = sourceCell;
            sourceItem.itemCell = targetCell;
        }       

        sourceItem.DeactivateItem();
        targetItem.DeactivateItem();   
     
        sourceItem = null;
        targetItem = null;
        
        OnMoveDone?.Invoke();
    }  
}
