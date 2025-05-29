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
    public GameObject player1Camera;
    public GameObject player2Camera;
    public TextMeshProUGUI textWin;

    public void Winn(string playerName, GameObject playerWinCamera)
    {
        normalCanvas.SetActive(false);
        player1Camera.SetActive(false);
        player2Camera.SetActive(false);
        winCanvas.SetActive(true);
        playerWinCamera.SetActive(true);
        textWin.text = playerName + " Wins";
    }
}
