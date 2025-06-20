using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelectionUI : MonoBehaviour
{
    public Button[] skinButtons;
    private void Start()
    {
        for (int i = 0; i < skinButtons.Length; i++)
        {
            int skinIndex = i;
            skinButtons[i].onClick.AddListener(() => SelectSkin(skinIndex));
        }
    }

    private void SelectSkin(int skinIndex)
    {
        SkinManager.Instance.SelectSkin(skinIndex);

        // Находим игрока и обновляем скин
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.TryApplySkin();
        }
    }
}