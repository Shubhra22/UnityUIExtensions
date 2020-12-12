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
        MessageBox.Instance.Show("Test", "Boddy",MessageBox.MessageBoxButton.YesNo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
