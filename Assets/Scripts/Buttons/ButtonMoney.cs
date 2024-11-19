using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonMoney : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Banknote _banknote;
    [SerializeField] private GameBalanceSO _gameBalance;
    [SerializeField] private TextMeshProUGUI _textClickMoney;
    [SerializeField] private Button _buttonGetMoney;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private RectTransform _rectTransformCanvas;
    [SerializeField] private BanknotePool _spawner;

    public float ClickValue { get; private set; }

    private void Start()
    {
        ClickValue = _gameBalance.ClickValue;
    }

    private void Update()
    {
        _textClickMoney.text = $"+{ClickValue}";
    }

    private void OnEnable()
    {
        _buttonGetMoney.onClick.AddListener(_wallet.AddMoney);
    }

    private void OnDisable()
    {
        _buttonGetMoney.onClick.RemoveListener(_wallet.AddMoney);
    }

    public void RaiseClickValue()
    {
        ClickValue++;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 screenPoint = eventData.position;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransformCanvas, screenPoint, null, out Vector2 localPoint))
        {
            _spawner.GetBanknote(localPoint);
        }
    }
}