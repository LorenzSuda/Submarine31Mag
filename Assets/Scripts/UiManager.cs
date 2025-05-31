using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TMP_Text gameOverText; // Riferimento al testo di Game Over


    public void GameOver()
    {
         gameOverText.gameObject.SetActive(true); // Mostra il testo di Game Over
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }
}
