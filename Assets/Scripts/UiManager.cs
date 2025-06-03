using TMPro;
using UnityEngine;
using System.Collections;

public class UiManager : MonoBehaviour
{
    public TMP_Text gameOverText; // Riferimento al testo di Game Over
    public TMP_Text fuelLostText;
    public TMP_Text fuelGainedText;
    
   
    public void FuelLost(Vector3 boxPosition) 
    {
         fuelLostText.gameObject.SetActive(true); 
         
         //setting  the fuel lost at box position
         Vector3 screenPosition = Camera.main.WorldToScreenPoint(boxPosition);
         fuelLostText.transform.position = screenPosition;
         // Avvia una coroutine per nascondere il testo dopo 1 secondo
         StartCoroutine(HideTextAfterDelay(fuelLostText, 1f));
    }

    private IEnumerator HideTextAfterDelay(TMP_Text text, float delay)
    {
        yield return new WaitForSeconds(delay);
        text.gameObject.SetActive(false);
    }
    
    public void GameOver()
    {
         gameOverText.gameObject.SetActive(true); // Mostra il testo di Game Over
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        fuelLostText.gameObject.SetActive(false);
        fuelGainedText.gameObject.SetActive(false);
    }

    public void MineHit(Vector3 boxPosition)
    {
        fuelGainedText.gameObject.SetActive(true);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(boxPosition);
        fuelGainedText.transform.position = screenPosition;
        StartCoroutine(HideTextAfterDelay(fuelGainedText, 1f));
    }
}
