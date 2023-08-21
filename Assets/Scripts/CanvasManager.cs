using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public CanvasScriptableObject canvasScriptableObject;
    CanvasLightControl lightControl;

    private void Start()
    {
        lightControl = GetComponent<CanvasLightControl>();
        lightControl.LightControl();
    }

    private void OnEnable()
    {
        EventManager.LightControl += LightControl;
    }
    private void OnDisable()
    {
        EventManager.LightControl -= LightControl;
    }
    void LightControl(bool light)
    {
        if (light)
        {
            //canvasScriptableObject.lightControl = false;
            lightControl.LightControl();
        }
        else
        {
            //canvasScriptableObject.lightControl=true;
            lightControl.LightControl();
        }
    }
    
    public void SettingsBtn()
    {
        SceneManager.LoadScene("Settings");
    }
    public void MenuBtn()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ResumeBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MusicBtn()
    {
        if (canvasScriptableObject.music)
        {
            canvasScriptableObject.music = false;
            lightControl.LightControl();
        }
        else
        {
            canvasScriptableObject.music=true;
            lightControl.LightControl();
        }
    }
    
    public void LightControlBtn()
    {
        if (canvasScriptableObject.lightControl)
        {
            canvasScriptableObject.lightControl = false;
            EventManager.LightControl(canvasScriptableObject.lightControl);
        }
        else
        {
            canvasScriptableObject.lightControl = true;
            EventManager.LightControl(canvasScriptableObject.lightControl);
        }
    }
    public void SoundBtn()
    {
        if (canvasScriptableObject.sound)
        {
            canvasScriptableObject.sound = false;
            lightControl.LightControl();
        }
        else
        {
            canvasScriptableObject.sound = true;
            lightControl.LightControl();
        }
    }
}
