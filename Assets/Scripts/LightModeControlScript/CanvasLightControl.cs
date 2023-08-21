using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLightControl : MonoBehaviour
{
    public CanvasScriptableObject canvasScriptableObject;

    public GameObject musicBtn;
    public Sprite musicLight;
    public Sprite musicDark;
    public Sprite musicOffLight;
    public Sprite musicOffDark;

    public GameObject lightControlBtn;
    public Sprite lightControlLight;
    public Sprite lightControlDark;

    public GameObject soundBtn;
    public Sprite soundLight;
    public Sprite soundDark;
    public Sprite soundOffLight;
    public Sprite soundOffDark;

    public GameObject menuBtn;
    public Sprite menuLight;
    public Sprite menuDark;

    public void LightControl()
    {
        if (canvasScriptableObject.lightControl)
        {
            lightControlBtn.GetComponent<Image>().sprite = lightControlDark;
            menuBtn.GetComponent<Image>().sprite = menuDark;
            if (canvasScriptableObject.music)
            {
                musicBtn.GetComponent<Image>().sprite = musicDark;
            }
            else
            {
                musicBtn.GetComponent<Image>().sprite = musicOffDark;
            }
            if (canvasScriptableObject.sound)
            {
                soundBtn.GetComponent<Image>().sprite = soundDark;
            }
            else
            {
                soundBtn.GetComponent<Image>().sprite = soundOffDark;
            }
        }
        else
        {
            lightControlBtn.GetComponent<Image>().sprite = lightControlLight;
            menuBtn.GetComponent<Image>().sprite = menuLight;
            if (canvasScriptableObject.music)
            {
                musicBtn.GetComponent<Image>().sprite = musicLight;
            }
            else
            {
                musicBtn.GetComponent<Image>().sprite = musicOffLight;
            }
            if (canvasScriptableObject.sound)
            {
                soundBtn.GetComponent<Image>().sprite = soundLight;
            }
            else
            {
                soundBtn.GetComponent<Image>().sprite = soundOffLight;
            }
        }
    }
}
