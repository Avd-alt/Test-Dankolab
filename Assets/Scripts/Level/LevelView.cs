using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private TextMeshProUGUI _textLevel;

    private void OnEnable()
    {
        _levelManager.LevelUp += DisplayLevel;
    }

    private void OnDisable()
    {
        _levelManager.LevelUp -= DisplayLevel;
    }

    private void DisplayLevel()
    {
        _textLevel.text = $"LV {_levelManager.Level}";
    }
}