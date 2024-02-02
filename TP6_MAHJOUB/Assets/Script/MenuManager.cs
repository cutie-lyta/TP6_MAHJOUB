using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _speeds;
    [SerializeField] private List<TextMeshProUGUI> _frequencies;

    public void ChangeSpeed(string button)
    {
        // Change previously selected button appearance
        this._speeds[(int)GameManager.Instance.Speed - 1].outlineWidth = 0.087f;
        this._speeds[(int)GameManager.Instance.Speed - 1].outlineColor = new Color32(0, 10, 255, 255);

        // Change Game Manager Speed
        GameManager.Instance.Speed = int.Parse(button);

        // Change this selected button appearance
        this._speeds[(int)GameManager.Instance.Speed - 1].outlineWidth = 10;
        this._speeds[(int)GameManager.Instance.Speed - 1].outlineColor = new Color32(210, 180, 0, 255);
    }

    public void ChangeFreq(string button)
    {
        // Change previously selected button appearance
        this._frequencies[(int)GameManager.Instance.Frequency - 1].outlineWidth = 0.087f;
        this._frequencies[(int)GameManager.Instance.Frequency - 1].outlineColor = new Color32(0, 10, 255, 255);

        // Change Game Manager Speed
        GameManager.Instance.Frequency = int.Parse(button);

        // Change this selected button appearance
        this._frequencies[(int)GameManager.Instance.Frequency - 1].outlineWidth = 10;
        this._frequencies[(int)GameManager.Instance.Frequency - 1].outlineColor = new Color32(210, 180, 0, 255);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
