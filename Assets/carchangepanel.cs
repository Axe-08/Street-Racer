using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carchangepanel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public logicControl logicControl;

    public void CarChange(int index)
    {
        logicControl.ChangeCar(index);
    }

    public void back()
    {
        panel.SetActive(false);
    }

}
