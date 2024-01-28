using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunnyFaceMinigame : MonoBehaviour
{
    [SerializeField] private Image[] chargeImage;
    private AudioSource audioSource; 
    private Button button; 
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        audioSource = GetComponentInChildren<AudioSource>(); 
    }

    public void SetupDefaultClick(UnityEngine.Events.UnityAction _actionToCall)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(_actionToCall);
        button.onClick.AddListener(UnInteractButton);
        button.onClick.AddListener(ActivateAllChargeImage);
        button.onClick.AddListener(playSound); 
    }
    public void SetupBonusClick(UnityEngine.Events.UnityAction _actionToCall)
    {
        button.interactable = true;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(_actionToCall);
        button.onClick.AddListener(UnInteractButton); 
    }
    public void ActivateChargeImage(int _index, Color _color)
    {
        chargeImage[_index].color = _color; 
    }
    public void DeactivateAllChargeImage()
    {
        foreach(Image image in chargeImage)
        {
            image.gameObject.SetActive(false); 
        }
    }
    private void ActivateAllChargeImage()
    {
        foreach (Image image in chargeImage)
        {
            image.color = Color.white; 
            image.gameObject.SetActive(true);
        }
    }
    private void UnInteractButton()
    {
        button.interactable = false; 
    }
    private void playSound()
    {
        audioSource.Play();
    }
}
