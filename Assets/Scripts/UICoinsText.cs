using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleOnCoinsChanged;
        _text.SetText("0");
    }

    private void HandleOnCoinsChanged(int coinsRemaining)
    {
        _text.SetText(coinsRemaining.ToString());
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= HandleOnCoinsChanged;
    }
}