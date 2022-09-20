using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvPMapSelect : MonoBehaviour
{
    public void PvPMap1() //modificar para los demás mapas
    {
        SceneManager.LoadScene("PvP M1");
    }

    public void PvPMap2()
    {
        SceneManager.LoadScene("PvP M2");
    }

    public void PvPMap3()
    {
        SceneManager.LoadScene("PvP M3");
    }
}
