using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddArrow : MonoBehaviour
{
    
    public GameObject gameObjectArrow;

    public void activateArrow()
    {
        gameObjectArrow.SetActive(true);
    }

    public void desactivateArrow()
    {
        gameObjectArrow.SetActive(false);
    }
}
