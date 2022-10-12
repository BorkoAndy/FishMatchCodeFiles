using System;
using UnityEngine;

public class FieldItem : MonoBehaviour    
{    
    [SerializeField] private Sprite activeSprite, inactiveSprite;    
    private SpriteRenderer spriteRenderer;
    private bool isActive;

    public int ID;
    public Cell itemCell;
    public static event Action SetItemsChange;
    
    private void Start() => spriteRenderer = GetComponent<SpriteRenderer>();   

    private void OnMouseDown()
    {       
        if (!isActive) ActivateItem();            
        else DeactivateItem();           
    }    

    private void ActivateItem()
    {
        spriteRenderer.sprite = activeSprite;
        isActive = true;
        if (ChangeItemCell.sourceItem == null) 
            ChangeItemCell.sourceItem = this;
        else
        {
            ChangeItemCell.targetItem = this;
            SetItemsChange?.Invoke();
        }
    }
    public void DeactivateItem()
    {
        spriteRenderer.sprite = inactiveSprite;
        isActive = false;
    }
}
