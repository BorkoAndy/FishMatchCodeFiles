using System;
using UnityEngine;

public class FirstMatchCheck : MonoBehaviour
{
    public static event Action SetCheck;
    private void LateUpdate()
    {
        for (int i=0; i < Cell_Setup.cellArray.GetLength(0); i++)
            for(int j =0; j < Cell_Setup.cellArray.GetLength(1); j++)
                if (Cell_Setup.cellArray[i, j].isEmpty == true) return;           
        
        SetCheck?.Invoke();       
    }
}
