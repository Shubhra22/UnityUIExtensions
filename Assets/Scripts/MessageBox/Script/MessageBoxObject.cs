﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxObject : MonoBehaviour
{
    public TextMeshProUGUI header;
    public TextMeshProUGUI message;
    public TextMeshProUGUI details;
    public TMP_InputField inputField;
    public Button confirmButton;
    public Button exitButton;
    public Button outsideButton;
}