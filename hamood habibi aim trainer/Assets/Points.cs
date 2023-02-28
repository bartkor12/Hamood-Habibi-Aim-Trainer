using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public int points = 0;
    public Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        textComponent.text = points.ToString();
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdateDisplay();
    }
}