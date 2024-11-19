using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpgrade : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private TextMeshProUGUI _textCostUpgrade;
    [SerializeField] private Button _buttonUpgrade;

    private void Update()
    {
        _textCostUpgrade.text = $"Upgrade {_levelManager.CostUpgrade}";

        ActivateButton();
    }

    private void OnEnable()
    {
        _buttonUpgrade?.onClick.AddListener(_levelManager.UpgradeLevel);
    }

    private void OnDisable()
    {
        _buttonUpgrade?.onClick.RemoveListener(_levelManager.UpgradeLevel);
    }

    private bool ActivateButton()
    {
        if (_levelManager.TryLevelUp())
        {
            return _buttonUpgrade.interactable = true;
        }

        return _buttonUpgrade.interactable = false;
    }
}