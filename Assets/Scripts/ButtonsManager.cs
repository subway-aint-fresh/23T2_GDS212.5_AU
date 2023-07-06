using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void ButtonRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonPLay()
    {
        SceneManager.LoadScene(1);
    }
}
