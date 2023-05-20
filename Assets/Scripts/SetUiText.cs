using TMPro;
using UnityEngine;

public class SetUiText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textField;
    [SerializeField]
    private string fixedText;

    public void OnSliderValueChange(float numericValue)
    {
        textField.text = $"{fixedText}: {numericValue}";
    }
}
