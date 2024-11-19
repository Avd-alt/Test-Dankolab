using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _amountView;

    private void Start()
    {
        DisplayAmount();
    }

    private void OnEnable()
    {
        _wallet.AmountChanged += DisplayAmount;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= DisplayAmount;
    }

    private void DisplayAmount()
    {
        _amountView.text = $"{_wallet.TotalAmount}";
    }
}