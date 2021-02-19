using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadText : MonoBehaviour
{
    public GFXController Controller { get; private set; }
    public TextMesh Mesh { get; private set; }
    public MeshRenderer MeshRenderer { get; private set; }

    void Start()
    {
        Controller = GetComponentInParent<GFXController>();
        Mesh = gameObject.GetComponentInChildren<TextMesh>();
        MeshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        orientParallelToCamera();
        updateText();
    }

    public void enable()
    {
        MeshRenderer.enabled = true;
    }

    public void disable()
    {
        MeshRenderer.enabled = false;
    }

    private void orientParallelToCamera()
    {
        if (Camera.main != null)
        {
            Mesh.transform.forward = Camera.main.transform.forward;
        }
    }

    private void updateText()
    {
        Mesh.text = getStateText();
        Mesh.text += "\n" + getHealthText();
    }

    private string getStateText()
    {
        string res = "";
        var controller = Controller;
        var unit = controller.Unit;
        var stateMachine = unit.StateMachine;
        var currentState = stateMachine.CurrentState;
        if (currentState != null)
        {
            res = currentState.Name;
        }
        return "State: " + res;
    }

    private string getHealthText()
    {
        string res = "";
        var controller = Controller;
        var unit = controller.Unit;
        var stats = unit.Stats;
        var health = stats.CurrentHealth;
        var maxHealth = stats.maxHealth;
        res = "Health: " + health + "/" + maxHealth;
        return res;
    }
}
