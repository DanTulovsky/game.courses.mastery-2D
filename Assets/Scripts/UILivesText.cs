using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        _text.SetText(GameManager.Instance.Lives.ToString());
    }

    private void HandleOnLivesChanged(int livesRemaining)
    {
        _text.SetText(livesRemaining.ToString());
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= HandleOnLivesChanged;
    }
}