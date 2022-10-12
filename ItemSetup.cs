using UnityEngine;

public class ItemSetup : MonoBehaviour
{
    private Cell[,] cellArray;
    private FieldItem[,] itemsArray;
    private int rows, cols;
    public FieldItem[] itemPrefabs;

    private void OnEnable() => Cell.MakeNewItem += SetItemsOfFirstRow;
    private void OnDisable() => Cell.MakeNewItem -= SetItemsOfFirstRow;
    private void Start()
    {
        cellArray = Cell_Setup.cellArray;        

        rows = cellArray.GetLength(0);
        cols = cellArray.GetLength(1);
        itemsArray = new FieldItem[rows, cols];

        for (int i = 0; i < cols; i++)
        {
            Cell cellofFirstRow = cellArray[rows-1,i];
            SetItemsOfFirstRow(cellofFirstRow);
            itemsArray[rows-1, i] = cellofFirstRow.cellItem;
        }
    }    

    private void SetItemsOfFirstRow(Cell cellOfFirstRow)
    {
        int randomItem = Random.Range(0, itemPrefabs.Length);
            
        FieldItem newItem = Instantiate(itemPrefabs[randomItem], cellOfFirstRow.transform.position, Quaternion.identity);
        newItem.itemCell = cellOfFirstRow;
        cellOfFirstRow.cellItem = newItem;
        cellOfFirstRow.isEmpty = false;        
    }
}
