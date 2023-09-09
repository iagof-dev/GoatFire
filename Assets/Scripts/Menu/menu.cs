using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour{
    public static menu instance;


    //Menu Principal
    [SerializeField] Canvas menu_st;
    [SerializeField] Button bt_play;
    [SerializeField] Button bt_maps;
    [SerializeField] Button bt_options;


    //Menu Maps
    [SerializeField] Canvas menu_mps;
    [SerializeField] Button menu_mps_devmap;

    //Menu options
    [SerializeField] Canvas menu_op;
    [SerializeField] TextMeshProUGUI menu_op_res;
    [SerializeField] Toggle menu_op_windowed;
    [SerializeField] public Slider menu_op_renderdistance;
    [SerializeField] TextMeshProUGUI menu_op_rdsVALUE;
    [SerializeField] Button menu_op_aplicar;
    bool fullscreen = true;

    void Start()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.None;
        menu_st.enabled = true;
        menu_mps.enabled = false;
        menu_op.enabled = false;
        Debug.Log("menu.cs | started!");
        bt_play.onClick.AddListener(play);
        bt_maps.onClick.AddListener(maps);
        bt_options.onClick.AddListener(options);
        menu_op_renderdistance.onValueChanged.AddListener(delegate { setrdvalue(); }) ;

        menu_op_windowed.onValueChanged.AddListener(delegate{op_windowed();});
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu_st.enabled = true; menu_mps.enabled = false; menu_op.enabled = false;
        }
    }
    void play(){Debug.Log("bt_play | Clicked"); SceneManager.UnloadSceneAsync("Menu"); SceneManager.LoadSceneAsync("Casa");}
    void maps() { Debug.Log("bt_maps | Clicked"); menu_st.enabled = false; menu_mps.enabled = true; menu_mps_devmap.onClick.AddListener(devmap); }
    void devmap() { SceneManager.UnloadSceneAsync("Menu"); SceneManager.LoadSceneAsync("devmap");  } 
    void options() { Debug.Log("bt_options | Clicked"); menu_st.enabled = false; menu_mps.enabled = false; menu_op.enabled = true; menu_op_aplicar.onClick.AddListener(res_aplicar); }
    void setrdvalue() { menu_op_rdsVALUE.text = Convert.ToString(menu_op_renderdistance.value); }
    public void op_windowed() {
        Debug.Log("Windowed = " + fullscreen); if (fullscreen == true)
            {
            //Falso = Windowed
            fullscreen = false;
        }
        else
        {
            //Verdadeiro = Fullscreen
            fullscreen = true;
            

        }
        Debug.Log("Windowed definido para " + fullscreen);
    }
    void res_aplicar()
    {
        Debug.Log("Windowed: " + fullscreen);
        if (menu_op_res.text == "1920x1080") { Screen.SetResolution(1920, 1080, fullscreen); }
        if (menu_op_res.text == "1280x720")
        {
            Screen.SetResolution(1280, 720, fullscreen);
        }

        if (menu_op_res.text == "800x600")
        {
            Screen.SetResolution(800, 600, fullscreen);
        }

        menu_st.enabled = true; menu_mps.enabled = false; menu_op.enabled = false;


    }

}
