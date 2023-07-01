using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    private int points = 0;
    [SerializeField] private TextMeshProUGUI pointsText;
    void Start()
    {
        pointsText.text = points.ToString();
    }

    public void AddPoint()
    {
        points++;
        pointsText.text = points.ToString();
    }

    public void ResetPoints()
    {
        points = 0;
        pointsText.text = points.ToString();
    }
}
