﻿using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class FPSDisplay : MonoBehaviour {
    float deltaTime = 0.0f;

    public float renderScale;

    void Start()
    {
    }

    void Update () {
        XRSettings.eyeTextureResolutionScale = renderScale;

        //deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI () {
        //int w = Screen.width, h = Screen.height;

        //GUIStyle style = new GUIStyle ();

        //Rect rect = new Rect (w / 2.0f, h / 2.0f, w, h * 2 / 100);
        //style.alignment = TextAnchor.UpperLeft;
        //style.fontSize = h * 2 / 100;
        //style.normal.textColor = Color.white;
        //float msec = deltaTime * 1000.0f;
        //float fps = 1.0f / deltaTime;
        //string text = string.Format ("{0:0.0} ms ({1:0.} fps)", msec, fps);
        //GUI.Label (rect, text, style);
    }
}