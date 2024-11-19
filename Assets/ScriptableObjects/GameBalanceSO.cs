using UnityEngine;

[CreateAssetMenu(fileName = "GameBalance", menuName = "ScriptableObjects/GameBalance", order = 1)]
public class GameBalanceSO : ScriptableObject
{
    [SerializeField] private float _clickValue;
    [SerializeField] private float _costUpgrade;
    [SerializeField] private float _totalAmount;
    [SerializeField] private float _level;

    public float ClickValue => _clickValue;
    public float CostUpgrade => _costUpgrade;
    public float TotalAmount => _totalAmount;
    public float Level => _level;
}