using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIaudioController : MonoBehaviour
{
    public audiomanager audiomanager;

    public void OnHomeClick()
    {
        audiomanager.filter.enabled = false;
    }
    public void OnReplayClick()
    {
        OnHomeClick();
        audiomanager.PlayInitialPart();
    }

    public void OnPauseClick()
    {
        audiomanager.filter.enabled = true;
        audiomanager.PlayMenuBgm();

    }

    public void OnResumeClick()
    {
        audiomanager.filter.enabled = false;
        audiomanager.PlayLoopPart();
    }




}
