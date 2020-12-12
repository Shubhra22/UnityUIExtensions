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
    public UnityEvent onConfirm;
    public UnityEvent onCancel;
    public UnityEvent onExit;
    public UnityEvent<string> onSubmitForm;
    
    public enum MessageBoxButton
    {
        Ok,
        YesNo,
        YesNoExit,
    }
    public MessageBoxButton _MessageBoxButton;
    
    
    public enum MessageBoxInput
    {
        NonInput,
        NormalInput,
        RichTextBoxInput,

    }
    public MessageBoxInput _MessageBoxInput ;
    
    public MessageBoxObject _MessageBoxObject;
    
    public MessageBox Show(string title, string message, MessageBoxButton messageBoxButton = MessageBoxButton.Ok,MessageBoxInput input = MessageBoxInput.NonInput)
    {
        MessageBoxObject m_obj =  Instantiate(_MessageBoxObject, transform);
        m_obj.header.gameObject.SetActive(true);
        m_obj.message.gameObject.SetActive(true);

        _MessageBoxInput = input;
        _MessageBoxButton = messageBoxButton;
        m_obj.header.text = title;
        m_obj.message.text = message;
        ManageButton(m_obj);
        ManageMessageBoxInput(m_obj);
        return this;

    }
    
    public MessageBox Show(string title, string message, string detail,MessageBoxButton messageBoxButton = MessageBoxButton.Ok, MessageBoxInput input = MessageBoxInput.NonInput)
    {
        MessageBoxObject m_obj =  Instantiate(_MessageBoxObject, transform);
        m_obj.header.gameObject.SetActive(true);
        m_obj.message.gameObject.SetActive(true);
        m_obj.details.gameObject.SetActive(true);

        _MessageBoxInput = input;
        _MessageBoxButton = messageBoxButton;
        
        m_obj.header.text = title;
        m_obj.message.text = message;
        m_obj.details.text = detail;
        ManageButton(m_obj);
        ManageMessageBoxInput(m_obj);
        return this;

    }
    

    static void CloseDialogue(ref MessageBoxObject obj)
    {
        DestroyImmediate(obj.gameObject);
    }


    void ManageMessageBoxInput(MessageBoxObject m_obj)
    {
        // if (_MessageBoxInput == MessageBoxInput.NormalInput || _MessageBoxInput == MessageBoxInput.RichTextBoxInput)
        // {
        //     m_obj.inputField.gameObject.SetActive(true);
        //     m_obj.inputField.onValueChanged.RemoveAllListeners();
        //     m_obj.inputField.onValueChanged.AddListener(SubmitForm);
        // }
        //
        // if (_MessageBoxInput == MessageBoxInput.RichTextBoxInput)
        // {
        //     m_obj.inputField.GetComponent<RectTransform>().sizeDelta += new Vector2(0,100);
        // }
        
    }

    private void SubmitForm(string inputText)
    {
        onSubmitForm.Invoke(inputText);
    }

    void ManageButton(MessageBoxObject m_obj)
    {
        Button b1, b2, b3;
        switch (_MessageBoxButton)
        {
            case MessageBoxButton.Ok:
                b1 = m_obj.confirmButton;
                b1.GetComponentInChildren<TextMeshProUGUI>().text = "Ok";
                b1.gameObject.SetActive(true);
                b1.onClick.RemoveAllListeners();
                b1.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                b1.onClick.AddListener(()=>onConfirm.Invoke());
                break;
            case MessageBoxButton.YesNo:
                b1 = m_obj.confirmButton;
                b2 = m_obj.exitButton;
                b1.gameObject.SetActive(true);
                b2.gameObject.SetActive(true);
                
                b1.GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
                b1.onClick.RemoveAllListeners();
                b1.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                b1.onClick.AddListener(()=>onConfirm.Invoke());

                b2.GetComponentInChildren<TextMeshProUGUI>().text = "No";
                b2.onClick.RemoveAllListeners();
                b2.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                b2.onClick.AddListener(()=>onCancel.Invoke());
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
                b1.onClick.AddListener(()=>onConfirm.Invoke());

                b2.GetComponentInChildren<TextMeshProUGUI>().text = "No";
                b2.onClick.RemoveAllListeners();
                b2.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                b2.onClick.AddListener(()=>onCancel.Invoke());

                b3.GetComponentInChildren<TextMeshProUGUI>().text = "Exit";
                b3.onClick.RemoveAllListeners();
                b3.onClick.AddListener(()=>CloseDialogue(ref m_obj));
                b3.onClick.AddListener(()=>onExit.Invoke());

                break;
        }
    }
    
}
