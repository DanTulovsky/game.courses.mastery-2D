using UnityEngine;
using Object = UnityEngine.Object;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private int totalCoins = 1;
    [SerializeField] private Object coinPrefab;

    private SpriteRenderer _spriteRenderer;
    private Sprite _enabledSprite;

    private int _remainingCoins;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enabledSprite = _spriteRenderer.sprite;
        _remainingCoins = totalCoins;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_remainingCoins <= 0) return;

        if (!col.HitFromBellow()) return;
        if (!col.HitByPlayer()) return;

        PopupCoin();
        
        GameManager.Instance.AddCoin();
        _remainingCoins--;

        if (_remainingCoins <= 0)
        {
            _spriteRenderer.sprite = disabledSprite;
        }
    }

    private void PopupCoin()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity, transform);
    }
}