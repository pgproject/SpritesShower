using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Application = UnityEngine.Application;

public class Item : MonoBehaviour
{
    private const string FOLDER_PATH = "/Resources/";

    [SerializeField] private FileExtensions m_fileExtension;
    [SerializeField] private Text m_textName;
    [SerializeField] private Image m_image;
    [SerializeField] private Text m_timeSinceCreate;

    private DateTime m_createTimeOfFile;

    public void SetItemPriporties(Sprite sprite)
    {
        m_image.sprite = sprite;
        m_textName.text = m_image.sprite.name;

        m_createTimeOfFile = File.GetCreationTime(Application.dataPath + FOLDER_PATH + m_image.sprite.name + "." + m_fileExtension.ToString());

        m_timeSinceCreate.text += (DateTime.Now - m_createTimeOfFile).ToString();

        Debug.Log(DateTime.Now - m_createTimeOfFile);
    }
}

public enum FileExtensions
{ 
    TGA, 
    PSD,
    JPG,
    PNG
}
