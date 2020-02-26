using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelect : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;


    private Instance currentInstance;

    public static event Action<Instance> OnChangeSelected;
    public static event Action<Instance> OnChangeHighlited;

    private Instance highlitedInstance;

    // Update is called once per frame
    void Update()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            if (Instance.isAnySelected == false)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    var newEntity = hitInfo.collider.GetComponent<Instance>();
                    if (currentInstance != newEntity)
                    {
                        currentInstance = newEntity;
                        currentInstance.OnSelect();
                        OnChangeSelected?.Invoke(newEntity);
                    }
                }
                else
                {
                    var newEntity = hitInfo.collider.GetComponent<Instance>();
                    if (highlitedInstance != newEntity)
                    {
                        highlitedInstance = newEntity;

                        highlitedInstance.OnHover();
                        OnChangeHighlited?.Invoke(newEntity);
                    }
                }
            }
            
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (currentInstance != null)
                {
                    currentInstance.OnDeselected();
                    currentInstance = null;
                    OnChangeSelected?.Invoke(null);
                }
               
            }
            else
            {
                if (highlitedInstance != null && Instance.isAnySelected == false)
                {
                    highlitedInstance.OnHoverOut();
                    highlitedInstance = null;
                    OnChangeHighlited?.Invoke(null);
                }
                
            }
        }
    }

    private void Start()
    {
        OnChangeSelected += OnChangeSelectedHandler;
        OnChangeHighlited += OnChangeHighlitedHandler;
    }

    private void OnChangeHighlitedHandler(Instance obj)
    {
        if (obj != null)
        {
            //mylogs Probably remove this later
            if (Debug.isDebugBuild) Debug.Log($"<color=purple>{obj.name} is highlited</color>");

        }
        else
        {
            //mylogs Probably remove this later
            if (Debug.isDebugBuild) Debug.Log($"<color=purple>Nothing is highlited</color>");

        }
    }

    private void OnChangeSelectedHandler(Instance obj)
    {
        if (obj != null)
        {
            //mylogs Probably remove this later
            if (Debug.isDebugBuild) Debug.Log($"<color=purple>{obj.name} is selected</color>");

        }
        else
        {
            //mylogs Probably remove this later
            if (Debug.isDebugBuild) Debug.Log($"<color=purple>Nothing is selected</color>");

        }
    }
}