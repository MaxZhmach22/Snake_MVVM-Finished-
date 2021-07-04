using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  static class Loader
{
    public enum Scene
    {
        GameScene,
        Loader,
    }

    private static Action loaderCallbakAction;

    public static void Load(Scene scene)
    {
        loaderCallbakAction = () =>
        {

            SceneManager.LoadScene(scene.ToString());
        };
        SceneManager.LoadScene(Scene.Loader.ToString());
    } 

    public static void LoaderCallBack()
    {
        loaderCallbakAction?.Invoke();
        loaderCallbakAction = null;
    }
}
