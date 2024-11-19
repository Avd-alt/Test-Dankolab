using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private GameBalanceSO _gameBalance;
    [SerializeField] private ButtonMoney _buttonMoney;
    [SerializeField] private LevelManager _levelManager;

    public float TotalAmount {  get; private set; }

    public event Action AmountChanged;

    private void Start()
    {
        TotalAmount = _gameBalance.TotalAmount;
    }

    public void AddMoney()
    {
        TotalAmount += _buttonMoney.ClickValue;

        AmountChanged?.Invoke();
    }

    public void TakeMoney()
    {
        TotalAmount -= _levelManager.CostUpgrade;

        AmountChanged?.Invoke();
    }
}