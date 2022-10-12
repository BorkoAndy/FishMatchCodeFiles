using UnityEngine;
using TMPro;

public class EndUI : MonoBehaviour
{
    [SerializeField] private TMP_Text endPointsText; 
    private int endPoints;

    private void Start()
    {
        endPoints = UI.points;
        endPointsText.text = "You've earned " + endPoints + " points";
    }
}
