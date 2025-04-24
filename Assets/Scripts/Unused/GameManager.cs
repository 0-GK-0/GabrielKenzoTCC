using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayerDied(string playerName)
    {
        Debug.Log("Fim de jogo! " + playerName + " perdeu.");
    }
}