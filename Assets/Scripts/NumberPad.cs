using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    [Header("Passwords and stuff")]
    public string Sequence;
    public KeyCardSpawner CardSpawner;
    private string m_CurrentEnteredCode = "";


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed(int valuePressed) {
        m_CurrentEnteredCode += valuePressed;
        CardSpawner.SetText(m_CurrentEnteredCode);

        if (m_CurrentEnteredCode.Length == Sequence.Length) {
            if (m_CurrentEnteredCode == Sequence) {
                CardSpawner.GrantAccess();
			} else {
                CardSpawner.DenyAccess();
			}
            m_CurrentEnteredCode = "";
        }
	}
}
