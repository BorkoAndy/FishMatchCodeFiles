using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text movesText;
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private int moves;  
    
    private int endScene = 1;
    public static int points;

    private void OnEnable()
    {
        ChangeItemCell.OnMoveDone += ReduseMoves;
        MatchChecker.OnMatchMade += IncreasePoints;
    }
    private void OnDisable()
    {
        ChangeItemCell.OnMoveDone -= ReduseMoves;
        MatchChecker.OnMatchMade -= IncreasePoints;
    }
    private void Start()
    {
        points = 0;        
        pointsText.text = points + " points";
        movesText.text = "Moves left " + moves;
    }

    private void IncreasePoints(int cellItemValue)
    {
        points += cellItemValue;
        pointsText.text = points + " points";
    }
    private void ReduseMoves()
    {
        moves--;
        movesText.text = "Moves left " + moves;
        if (moves <= 0) EndGame();
    }

    private void EndGame() => SceneManager.LoadScene(endScene);
}
