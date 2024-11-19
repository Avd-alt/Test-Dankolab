using System.Collections.Generic;
using UnityEngine;

public class BanknotePool : MonoBehaviour
{
    [SerializeField] private Banknote _banknotePrefab;
    [SerializeField] private int _initialPoolSize;
    [SerializeField] private RectTransform _rectTransform;

    private Queue<Banknote> _banknotePool = new Queue<Banknote>();

    private void Awake()
    {
        for (int i = 0; i < _initialPoolSize; i++)
        {
            CreateBanknote();
        }
    }

    private Banknote CreateBanknote()
    {
        Banknote banknote = Instantiate(_banknotePrefab);
        banknote.BanknoteReturn += ReturnBanknote;
        banknote.gameObject.SetActive(false);
        _banknotePool.Enqueue(banknote);
        return banknote;
    }

    private void ReturnBanknote(Banknote banknote)
    {
        banknote.gameObject.SetActive(false);
        _banknotePool.Enqueue(banknote);
    }

    public Banknote GetBanknote(Vector2 position)
    {
        Banknote banknote;

        if (_banknotePool.Count > 0)
        {
            banknote = _banknotePool.Dequeue();
            banknote.gameObject.SetActive(true);
        }
        else
        {
            banknote = CreateBanknote();
        }

        banknote.transform.SetParent(_rectTransform, false);
        banknote.RectTransform.anchoredPosition = position;

        return banknote;
    }
}