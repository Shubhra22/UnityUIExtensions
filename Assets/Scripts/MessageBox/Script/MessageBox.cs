using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using SocialNinja;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class MessageBox : Manager<MessageBox>
{

    public enum MessageBoxButton
    {
        Ok,
        YesNo,
        YesNoExit,
    }

    public MessageBoxButton _messageBoxButton;
    public MessageBoxObject _messageBoxObject;
    
    public void Show(string title, string message, MessageBoxButton messageBoxButton = MessageBoxButton.Ok)
    {
        MessageBoxObject m_obj =  Instantiate(_messageBoxObject, transform);
        m_obj.header.gameObject.SetActive(true);
        m_obj.message.gameObject.SetActive(true);

        _messageBoxButton = messageBoxButton;
        m_obj.header.text = title;
        m_obj.message.text = message;
        ManageButton(m_obj);
    }
    
    public void Show(string title, string message, string detail,MessageBoxButton messageBoxButton = MessageBoxButton.Ok)
    {
        MessageBoxObject m_obj =  Instantiate(_messageBoxObject, transform);
        m_obj.header.gameObject.SetActive(true);
        m_obj.message.gameObject.SetActive(true);
        m_obj.details.gameObject.SetActive(true);

        _messageBoxButton = messageBoxButton;
        ManageButton(m_obj);
        m_obj.header.text = title;
        m_obj.message.text = message;
        m_obj.details.text = detail;

    }

    static void CloseDialogue(ref MessageBoxObject obj)
    {
        DestroyImmediate(obj.gameObject);
    }


    void ManageButton(MessageBoxObject m_obj, UnityAction confirmButton = null, UnityAction cancelButton=null,UnityAction exitButton=null)
    {
        Button b1, b2, b3;
        switch (_messageBoxButton)
        {
            case MessageBoxButton.Ok:
                b1 = m_obj.confirmButton;
                b1.GetComponentInChildren<TextMeshProUGUI>().text = "Ok";
                b1.gameObject.SetActive(true);
                b1.onClick.RemoveAllListeners();
                b1.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                if(confirmButton!=null) b1.onClick.AddListener(confirmButton);
                break;
            case MessageBoxButton.YesNo:
                b1 = m_obj.confirmButton;
                b2 = m_obj.exitButton;
                b1.gameObject.SetActive(true);
                b2.gameObject.SetActive(true);
                
                b1.GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
                b1.onClick.RemoveAllListeners();
                b1.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                if(confirmButton!=null) b1.onClick.AddListener(confirmButton);
                
                b2.GetComponentInChildren<TextMeshProUGUI>().text = "No";
                b2.onClick.RemoveAllListeners();
                b2.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                if(cancelButton!=null) b2.onClick.AddListener(cancelButton);
                break;
            
            case MessageBoxButton.YesNoExit:
                b1 = m_obj.confirmButton;
                b2 = m_obj.exitButton;
                b3 = m_obj.exitButton;
                
                b1.gameObject.SetActive(true);
                b2.gameObject.SetActive(true);
                b3.gameObject.SetActive(true);
                
                b1.GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
                b1.onClick.RemoveAllListeners();
                b1.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                if(confirmButton!=null) b1.onClick.AddListener(confirmButton);
                
                b2.GetComponentInChildren<TextMeshProUGUI>().text = "No";
                b2.onClick.RemoveAllListeners();
                b2.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                if(cancelButton!=null) b2.onClick.AddListener(cancelButton);
                
                b3.GetComponentInChildren<TextMeshProUGUI>().text = "Exit";
                b3.onClick.RemoveAllListeners();
                b3.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                if(exitButton!=null) b3.onClick.AddListener(exitButton); ;
                break;
        }
    }
    
}
