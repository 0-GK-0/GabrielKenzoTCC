using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInput : MonoBehaviour
{
    public bool canMov = true;
    public List<GameObject> disableObj;

    public void Disable()
    {
        for (int i = 0; i < disableObj.Count; i++)
        {
            disableObj[i].gameObject.SetActive(false);
        }
    } 
    public void Enable()
    {
        for (int i = 0; i < disableObj.Count; i++)
        {
            disableObj[i].gameObject.SetActive(true);
        }
    }
}
