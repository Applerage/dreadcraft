using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentPointsPopUp : MonoBehaviour
{
    private PlayerResources pr;

    public Image talentPopup;

    public Text talentPopupText;

    public Text talentPopUpDialogue;

    private float dialogueTimer;

    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        dialogueTimer = 6;
        talentPopUpDialogue.text = "";
        talentPopup.enabled = false;
        pr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResources>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pr.currentTalentPoints >= 1)
        {
            talentPopup.enabled = true;
            talentPopupText.text = $"Talent Points to spend: {pr.currentTalentPoints}";
        }
        else
        {
            talentPopup.enabled = false;
            talentPopupText.text = "";
        }

        if (pr.currentLevel == 2 && !isActive)
        {
            talentPopUpDialogue.text = "Use talent points after each level!";
            dialogueTimer -= Time.deltaTime;
            if (dialogueTimer <= 0)
            {
                isActive = true;
                talentPopUpDialogue.text = "";
            }
        }
    }
}
