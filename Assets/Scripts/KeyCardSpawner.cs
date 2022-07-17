using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyCardSpawner : MonoBehaviour
{

    public TextMeshProUGUI ScreenText;
    public Image ScreenImage;
    private bool IsDisplayingUniqueScreen = false;
    public GameObject keyCardPrefab;
    public GameObject keyCardAttach;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrantAccess() {
        IsDisplayingUniqueScreen = true;
        ScreenImage.color = new Color(0, 1, 0.1258f);
        ScreenText.text = "Access Granted";
        Instantiate(keyCardPrefab, keyCardAttach.transform.position, keyCardAttach.transform.rotation) ;
    }

    public void DenyAccess() {
        IsDisplayingUniqueScreen = true;
        ScreenImage.color = new Color(1, 0, 0);
        ScreenText.color = new Color(1, 1, 1);
        ScreenText.text = "Access Denied";
    }
    public void SetText(string text) {
        if (IsDisplayingUniqueScreen) {
            resetScreenColor();
        }
        ScreenText.text = text;
	}

    private void resetScreenColor() {
        IsDisplayingUniqueScreen = false;
        ScreenImage.color = new Color(1, 1, 1);
        ScreenText.color = new Color(0, 0, 0);
        ScreenText.text = "";
    }
}
