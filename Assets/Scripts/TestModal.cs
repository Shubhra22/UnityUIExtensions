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
        MessageBox m = MessageBox.Instance.Show("Test", "Boddy", MessageBox.MessageBoxButton.YesNo,MessageBox.MessageBoxInput.NormalInput);
        m.onCancel.AddListener(Cancel);
    }

    private void Cancel()
    {
        Debug.Log("Cancelled");
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
