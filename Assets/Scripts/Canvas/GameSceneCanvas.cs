using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneCanvas : CanvasLightControl
{
    
    [SerializeField] GameObject settingsPanel;
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] Sprite panelBackgroundLight;
    [SerializeField] Sprite panelBackgroundBlack;
    [SerializeField] TextMeshProUGUI settingsText;
    int _point;
    private void Start()
    {
        LightControl();
    }
    private void OnEnable()
    {
        EventManager.EarnPoints += EarnPoints;
    }
    private void OnDisable()
    {
        EventManager.EarnPoints -= EarnPoints;
    }
    void EarnPoints(int point)
    {
        _point += point * 10;
        pointText.text = _point.ToString();
    }
    

    public void SettingsBtn()
    {
        settingsPanel.SetActive(true);
    }
    public void ResumeBtn()
    {
        settingsPanel.SetActive(false);
    }
    public void MenuBtn()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SoundBtn()
    {
        if (gameManagerSC.sound)
        {
            
            gameManagerSC.sound = false;
            LightControl();
            Debug.Log("Sound Off");
        }
        else
        {
            gameManagerSC.sound = true;
            LightControl();
            Debug.Log("Sound On");
        }
    }
    public void MusicBtn()
    {
        if (gameManagerSC.music)
        {
            gameManagerSC.music = false;
            LightControl();
            Debug.Log("Music Off");
        }
        else
        {
            gameManagerSC.music = true;
            LightControl();
            Debug.Log("Music On");
        }
    }
    public void LightControlBtn()
    {
        if (gameManagerSC.lightControl)
        {
            gameManagerSC.lightControl = false;
            settingsPanel.GetComponent<Image>().sprite = panelBackgroundBlack;
            settingsText.color= Color.white;
            LightControl();
        }
        else
        {
            gameManagerSC.lightControl = true;
            settingsPanel.GetComponent<Image>().sprite = panelBackgroundLight;
            settingsText.color= Color.black;    
            LightControl();
        }
    }
}
