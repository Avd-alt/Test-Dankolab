using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameBalanceSO _gamebalance;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ButtonMoney _buttonMoney;

    public float Level { get; private set; }

    public float CostUpgrade { get; private set; }

    public event Action LevelUp;

    private void Start()
    {
        CostUpgrade = _gamebalance.CostUpgrade;
    }

    public void UpgradeLevel()
    {
        _wallet.TakeMoney();
        _buttonMoney.RaiseClickValue();
        IncreaseCostUpgrade();
        Level++;
        LevelUp?.Invoke();
    }

    public bool TryLevelUp()
    {
        if (_wallet.TotalAmount >= CostUpgrade)
        {
            return true;
        }

        return false;
    }

    private void IncreaseCostUpgrade()
    {
        float multiplier = 1.5f;
        CostUpgrade = Mathf.FloorToInt(CostUpgrade * multiplier);
    }
}