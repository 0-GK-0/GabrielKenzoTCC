using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Win : MonoBehaviour
{
    [Header("Both")]
    public GameObject winCanvas;
    public GameObject normalCanvas;
    public GameObject playerCamera;
    public TextMeshProUGUI textWin;

    public Transform winPos;
    public Transform losePos;

    public void Winn(string playerName, GameObject playerWinCamera)
    {
        normalCanvas.SetActive(false);
        playerCamera.SetActive(false);
        winCanvas.SetActive(true);
        playerWinCamera.SetActive(true);
        textWin.text = playerName + " Wins";
    }
}
