using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPallete : MonoBehaviour
{
    GameObject unitButtonPrefab;
    public UI UI { get; private set; }
    public Selection CurrentSelection { get { return UI.Game.Player.SelectionManager.CurrentSelection; } set { } }
    public Canvas Canvas { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        UI = gameObject.GetComponentInParent<UI>();
        Canvas = gameObject.GetComponentInParent<Canvas>();
        unitButtonPrefab = Resources.Load("Prefabs/UnitButton") as GameObject;

        // GameObject bt1 = Instantiate(unitButtonPrefab, transform.position, transform.rotation);
        // bt1.transform.SetParent(transform, false);
        // UnitButton ub1 = bt1.GetComponent<UnitButton>();
        // ub1.RectTransform.anchoredPosition = new Vector2(10, 10);
        //bt1.transform.x = 50;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("To display " + CurrentSelection?.Selected.Count);
    }

    // public UnitButton
}
