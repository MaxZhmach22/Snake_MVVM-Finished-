using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MainMenuWindow : MonoBehaviour
{
    private enum Sub
    {
        Main,
        HowToPlay
    }

    private void Awake()
    {
        transform.Find("HowToPlaySubMenu").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("MainSubMenu").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        transform.Find("MainSubMenu").Find("playBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.GameScene);
        transform.Find("MainSubMenu").Find("quitBtn").GetComponent<Button_UI>().ClickFunc = () => Application.Quit();
        transform.Find("MainSubMenu").Find("howToPlayBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.HowToPlay);

        transform.Find("HowToPlaySubMenu").Find("backBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.Main);

        ShowSub(Sub.Main);
    }

    private void ShowSub(Sub sub)
    {
        transform.Find("MainSubMenu").gameObject.SetActive(false);
        transform.Find("HowToPlaySubMenu").gameObject.SetActive(false);

        switch (sub)
        {
            case Sub.Main:
            transform.Find("MainSubMenu").gameObject.SetActive(true);
                break;
            case Sub.HowToPlay:
                transform.Find("HowToPlaySubMenu").gameObject.SetActive(true);
                break;

        }
    }
}
