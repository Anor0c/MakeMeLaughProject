using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImitateMinigame : MonoBehaviour
{
    [SerializeField] private float maxX, minX, maxY, minY;
    [SerializeField] private float damage = 2f;
    [SerializeField] private RectTransform[] imitateClones;
    [SerializeField] private UIBar laughBar;

    public void ShuffleClones()
    {
        foreach (RectTransform clone in imitateClones)
        {
            clone.anchoredPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            clone.gameObject.SetActive(true); 
        }
    }
    public void DeactivateClones()
    {
        foreach(RectTransform clone in imitateClones)
        {
            clone.gameObject.SetActive(false);
        }
    }
    public void OnClick()
    {
        laughBar.UpdateValue(damage);
    }
}
