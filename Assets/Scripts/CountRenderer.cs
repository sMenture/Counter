using TMPro;
using UnityEngine;

public class CountRenderer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDisplay;
    [SerializeField] private Counter counter;

    private void OnEnable()
    {
        counter.CountUpdated += UpdateDisplay;
    }

    private void OnDisable()
    {
        counter.CountUpdated -= UpdateDisplay;
    }

    private void UpdateDisplay(int value)
    {
        _textDisplay.text = value.ToString();
    }
}
