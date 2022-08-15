using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleUI : MonoBehaviour
{
    public GUIStyle style;
    public GUISkin skin;

    void OnGUI()
    {
        GUI.Button(new Rect(100, 0, 100, 100), "");
        GUI.Button(new Rect(100, 100, 100, 100), "", style);

        GUI.skin = skin;
        GUI.Button(new Rect(100, 200, 100, 100), "");
        GUI.skin = null;


    }





}
