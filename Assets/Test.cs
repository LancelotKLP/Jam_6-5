using UnityEngine;
using UnityEngine.UI;
using System;

public class Test : MonoBehaviour
{
    [SerializeField] Text datetimeText;

    void Update()
    {
        if (WorldTimeAPI.Instance.isTimeLoaded) {
            DateTime currentDateTime = WorldTimeAPI.Instance.GetCurrentDateTime();
            datetimeText.text = currentDateTime.ToString();
        }
    }
}
