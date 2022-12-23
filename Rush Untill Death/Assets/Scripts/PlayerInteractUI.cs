using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject UIcontainer;
    [SerializeField] private PlayerInteract playerInteract;

    private void Update()
    {
        if(playerInteract.GetInteractableObject() !=null)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        UIcontainer.SetActive(true);
    }

    private void Hide()
    {
        UIcontainer.SetActive(false);
    }
}
