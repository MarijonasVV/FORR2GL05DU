using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    //sækir breyttu healthbar
    private VisualElement m_Healthbar;

    //gerir ui instance
    public static UIHandler instance { get; private set; }

    // UI fyrir texta
    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue;
    private float m_TimerDisplay;


    //
    private void Awake()
    {
        instance = this;
    }

    // þegar byrjað, gerir ui fyrir leikinn
    private void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);


        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("Background");
        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;


    }


    //hvert frame er uppfært
    private void Update()
    {
        //tímer fyrir dialogue textan
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue.style.display = DisplayStyle.None;
            }


        }
    }

    //breyttir eftir hversu mikið líf notandi er með
    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    //sýnir dialogue
    public void DisplayDialogue()
    {
        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }

}
