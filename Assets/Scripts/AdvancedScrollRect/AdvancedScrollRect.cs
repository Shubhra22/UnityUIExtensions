using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class AdvancedScrollRect : ScrollRect
{
    private GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public Transform selectionPoint;
    public float buttonScale;
    
    public enum  Animation
    {
        SlideUp,
        SlideDown,
        ZoomIn,
    }

    public Animation animation;

    private Vector3 initalPos;
    // Start is called before the first frame update
    protected override void Start()
    {
        
        m_Raycaster = FindObjectOfType<GraphicRaycaster>();
        m_EventSystem = FindObjectOfType<EventSystem>();
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = selectionPoint.position;
    }

    private void Update()
    {
        foreach (Transform child in content)
        {
            ChooseAnimation(child,OnEntered(child));
        }
    }

    private bool OnEntered(Transform obj)
    {
        List<RaycastResult> _results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, _results);
        if (_results.Count > 0)
        {
            if (_results[0].gameObject == obj.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void ChooseAnimation(Transform child,bool entered)
    {
        switch (animation)
        {
            case Animation.SlideDown:
                if (entered)
                {
                    initalPos = transform.position;
                    child.DOMoveY(transform.position.y - 0.01f, 0.4f);
                }
                else
                {
                    child.DOMoveY(initalPos.y, 0.4f);
                }
                break;
            case Animation.SlideUp:
                if (entered)
                {
                    child.DOScale(Vector3.one * buttonScale, 0.4f);
                }
                else
                {
                    child.DOScale(Vector3.one, 0.4f);
                }
                break;
            case Animation.ZoomIn:
                if (entered)
                {
                    child.DOScale(Vector3.one * buttonScale, 0.4f);
                }
                else
                {
                    child.DOScale(Vector3.one, 0.4f);
                }
                break;
        }
    }
    
    
}
