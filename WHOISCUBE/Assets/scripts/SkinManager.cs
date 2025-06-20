using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;
    public List<Material> playerSkins;
    public TextMeshProUGUI textMeshProUGUI;
    private int _currentSkinIndex = 0;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSkin();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadSkin()
    {
        _currentSkinIndex = PlayerPrefs.GetInt("SelectedSkin", 0);
        Debug.Log($"Loaded skin index: {_currentSkinIndex}");
    }

    public void SelectSkin(int skinIndex)
    {
        float TimeText = Time.time;
        if (skinIndex >= 0 && skinIndex < playerSkins.Count)
        {
            _currentSkinIndex = skinIndex;
            PlayerPrefs.SetInt("SelectedSkin", skinIndex);
            PlayerPrefs.Save();
            Debug.Log($"Skin selected: {skinIndex}");
            if (TimeText <= 1f)
            {
                textMeshProUGUI.text = "÷вет выбран";
            }
        }
    }

    public Material GetSelectedSkin()
    {
        return playerSkins[_currentSkinIndex];
    }
}