using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Dictionary<string, Selection> SavedSelections { get; set; }
    public Selection CurrentSelection { get; private set; }

    void Start()
    {
        SavedSelections = new Dictionary<string, Selection>();
        CurrentSelection = ScriptableObject.CreateInstance<Selection>();
    }

    void Update()
    {

    }

    public void saveCurrentSelection(string key)
    {
        SavedSelections[key] = CurrentSelection.copy();
    }

    public void addToSelection(string key)
    {
        if (SavedSelections.ContainsKey(key))
        {
            Debug.Log("loading " + SavedSelections[key].Selected.Count);
            Selection saved = SavedSelections[key];
            foreach (Selectable sel in CurrentSelection.Selected)
            {
                if (!saved.Selected.Contains(sel))
                {
                    saved.Selected.Add(sel);
                }
            }
        }
        else
        {
            saveCurrentSelection(key);
        }
    }

    public void loadSelection(string key)
    {
        if (SavedSelections.ContainsKey(key))
        {
            CurrentSelection = SavedSelections[key].copy();
            Debug.Log("loading " + SavedSelections[key].Selected.Count);
        }

        // Debug.Log(CurrentSelection);
    }

    public void saveSelection(string key, Selection selection)
    {
        SavedSelections[key] = Instantiate(selection);
    }

    public Selection getSelection(string key)
    {
        return SavedSelections[key];
    }
}
