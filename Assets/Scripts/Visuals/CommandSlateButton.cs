using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandSlateButton : MonoBehaviour
{
    public Text TextComponent { get; private set;}
    public 
    // Start is called before the first frame update
    void Start()
    {
        TextComponent = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        Debug.Log("123");
    }
}
