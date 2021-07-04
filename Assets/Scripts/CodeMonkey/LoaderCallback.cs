using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool fistUpdate = true;

    private void Update()
    {
        if (fistUpdate)
        {
            fistUpdate = false;
            Loader.LoaderCallBack();
        }
    }
}
