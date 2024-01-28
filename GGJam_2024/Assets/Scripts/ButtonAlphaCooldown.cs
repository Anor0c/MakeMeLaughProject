using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public enum ButtonBinding
{
    Fart,
    Imitation,
    FunnyFace, 
}
public class ButtonAlphaCooldown : MonoBehaviour
{
    private bool isCooldown;  
    private bool isJoking;  

    private Image buttonImage;
    private JokeBehaviour player;
    [SerializeField] private ButtonBinding binding; 
    void Start()
    {
        buttonImage = GetComponent<Image>();
        player = FindObjectOfType<JokeBehaviour>(); 

    }

    private void Update()
    {
        switch (binding)
        {
            case ButtonBinding.Fart:
                isCooldown = player.IsFartCooldown;
                isJoking = player.IsFarting; 
                break;
            case ButtonBinding.Imitation:
                isCooldown = player.IsImitationCooldown;
                isJoking = player.IsImitating; 
                break;
            case ButtonBinding.FunnyFace:
                isCooldown = player.IsFunnyFaceCooldown;
                isJoking = player.IsFunnyFacing; 
                break;
            default:
                break;
        }
        if (isCooldown  ) 
        {
            buttonImage.color = new Vector4(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0.1f);
        }
        else if (isJoking)
        {
            buttonImage.color = new Vector4(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0.3f);
        }
        else
        {
            buttonImage.color = new Vector4(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 1f);
        }
    }
}
