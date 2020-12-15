using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestModal : MonoBehaviour
{
    private Button b;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        MessageBox m = MessageBox.Instance.Show("Header", "This is a test body.",
            MessageBox.MessageBoxButton.YesNo,MessageBox.MessageBoxInput.RichTextBoxInput);
        m.onConfirm.AddListener(Confirm);
    }

    private void Confirm()
    {
        Debug.Log("Done");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
