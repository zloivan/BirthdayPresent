using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Instance : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;

    [SerializeField] private Animator animator;
    private bool isHighlighetd;
    private static readonly int isSelected = Animator.StringToHash("isSelected");

    public static bool isAnySelected;
    public void OnHover()
    {
        //playerName.fontMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 240, 0, 128));
        playerName.fontMaterial.EnableKeyword("GLOW_ON");
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.P))
    //     {
    //         //mylogs Probably remove this later
    //         if (Debug.isDebugBuild) Debug.Log($"<color=purple>SomeText</color>");
    //
    //         if (gameObject.name != "Misha" && isHighlighetd == false)
    //         {
    //             OnHover();
    //             isHighlighetd = true;
    //         }
    //         else
    //         {
    //             OnHoverOut();
    //             isHighlighetd = false;
    //         }
    //     }
    // }

    public void OnHoverOut()
    {
        playerName.fontMaterial.DisableKeyword("GLOW_ON");
    }

    public void OnSelect()
    {
        animator.SetBool(isSelected,true);
        isAnySelected = true;
    }

    public void OnDeselected()
    {
        animator.SetBool(isSelected,false);
        isAnySelected = false;
    }
}
