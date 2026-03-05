using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject _endGameUI;
    [SerializeField] private int _characterCount;

    private void Awake()
    {
        Instance = this;

        if (_endGameUI != null)
        {
            _endGameUI.SetActive(false);
        }
    }

    public void CharacterCount()
    {
        _characterCount--;

        if (_characterCount <= 0)
        {
            _endGameUI.SetActive(true);
        }
    }
}
