using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSlateController : MonoBehaviour
{
    public List<CommandSlateButton> Buttons { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Buttons = new List<CommandSlateButton>(gameObject.GetComponentsInChildren<CommandSlateButton>());
        foreach(CommandSlateButton btn in Buttons){
            Debug.Log(btn.TextComponent.text);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
