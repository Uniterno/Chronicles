using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class playerMoves : MonoBehaviour
{
    GameObject slideText, screenAppear, textPhase ,playerDeck , playerCementery, enemyCementery, handView, abortButton ,yourLifeText, yourManaText, enemyLifeText;
    GameObject downButton0, downButton1, downButton2, downButton3 , downButton4, downButton5;
    GameObject enemyButton0, enemyButton1, enemyButton2, enemyButton3, enemyButton4, enemyButton5;
    Color temporalColor;
    public bool takeCard, battle, enemy;

    public void Update()
    {
        Debug.Log(this.name);
    }

    public void SetPhase()
    {
        Debug.Log("Set Phase: " + takeCard);

        if (takeCard == false && battle == false && enemy == false)
        {
            screenAppear.transform.position = screenAppear.transform.position + new Vector3(0.0f, -412.0f, 0.0f);

            takeCard = true;
            UserPhaseTakeCard();
        }
        else
        {

            if (battle == false && takeCard == true)
            {
                screenAppear.transform.position = screenAppear.transform.position + new Vector3(0.0f, -412.0f, 0.0f);
                PlayPhase();
            }
            else
            {
                if(enemy == true)
                {
                    screenAppear.transform.position = screenAppear.transform.position + new Vector3(0.0f, -412.0f, 0.0f);
                    EnemyFase();
                }
            }
        }
    }
    public void EnemyFase()
    {
        downButton0.GetComponent<Animator>().enabled = false;
        downButton1.GetComponent<Animator>().enabled = false;
        downButton2.GetComponent<Animator>().enabled = false;
        downButton3.GetComponent<Animator>().enabled = false;
        downButton4.GetComponent<Animator>().enabled = false;
        downButton5.GetComponent<Animator>().enabled = false;

        playerCementery.GetComponent<Animator>().enabled = false;
        enemyCementery.GetComponent<Animator>().enabled = true;

        abortButton.GetComponent<Animator>().enabled = false;


        downButton0.GetComponent<Button>().enabled = false;
        downButton1.GetComponent<Button>().enabled = false;
        downButton2.GetComponent<Button>().enabled = false;
        downButton3.GetComponent<Button>().enabled = false;
        downButton4.GetComponent<Button>().enabled = false;
        downButton5.GetComponent<Button>().enabled = false;

        playerCementery.GetComponent<Button>().enabled = false;
        enemyCementery.GetComponent<Button>().enabled = true;
        abortButton.GetComponent<Button>().enabled = false;

        downButton0.GetComponent<Image>().color = temporalColor;
        downButton1.GetComponent<Image>().color = temporalColor;
        downButton2.GetComponent<Image>().color = temporalColor;
        downButton3.GetComponent<Image>().color = temporalColor;
        downButton4.GetComponent<Image>().color = temporalColor;
        downButton5.GetComponent<Image>().color = temporalColor;
        playerCementery.GetComponent<Image>().color = temporalColor;
        abortButton.GetComponent<Image>().color = temporalColor;
    }
    //This phase is activated when the player click on the message button at the beginning of their turns
    public void UserPhaseTakeCard()
    {
        handView.transform.position = handView.transform.position + new Vector3(1030.0f, 0.0f, 0.0f);
        playerCementery.GetComponent<Button>().enabled = false;
        enemyCementery.GetComponent<Button>().enabled = false;
        playerCementery.GetComponent<Animator>().enabled = false;
        enemyCementery.GetComponent<Animator>().enabled = false;
        playerDeck.GetComponent<Button>().enabled = true;
        playerDeck.GetComponent<Animator>().enabled = true;

        playerDeck.GetComponent<Image>().color = temporalColor;
        enemyCementery.GetComponent<Image>().color = temporalColor;

    }

    //This is activated when the player take a card from deck and enable the play phase
    public void PlayPhase()
    {
        Debug.Log("Play Phase: " + takeCard);
        playerDeck.GetComponent<Button>().enabled = false;
        playerDeck.GetComponent<Animator>().enabled = false;
        playerCementery.GetComponent<Button>().enabled = true;
        enemyCementery.GetComponent<Button>().enabled = true;
        playerCementery.GetComponent<Animator>().enabled = true;
        enemyCementery.GetComponent<Animator>().enabled = true;
        downButton0.GetComponent<Animator>().enabled = true;
        downButton1.GetComponent<Animator>().enabled = true;
        downButton2.GetComponent<Animator>().enabled = true;
        downButton3.GetComponent<Animator>().enabled = true;
        downButton4.GetComponent<Animator>().enabled = true;
        downButton5.GetComponent<Animator>().enabled = true;

        downButton0.GetComponent<Button>().enabled = true;
        downButton1.GetComponent<Button>().enabled = true;
        downButton2.GetComponent<Button>().enabled = true;
        downButton3.GetComponent<Button>().enabled = true;
        downButton4.GetComponent<Button>().enabled = true;
        downButton5.GetComponent<Button>().enabled = true;

        playerDeck.GetComponent<Image>().color = temporalColor;
    }

    public void AbortAttack()
    {
        downButton0.GetComponent<Animator>().enabled = true;
        downButton1.GetComponent<Animator>().enabled = true;
        downButton2.GetComponent<Animator>().enabled = true;
        downButton3.GetComponent<Animator>().enabled = true;
        downButton4.GetComponent<Animator>().enabled = true;
        downButton5.GetComponent<Animator>().enabled = true;

        enemyButton0.GetComponent<Animator>().enabled = false;
        enemyButton1.GetComponent<Animator>().enabled = false;
        enemyButton2.GetComponent<Animator>().enabled = false;
        enemyButton3.GetComponent<Animator>().enabled = false;
        enemyButton4.GetComponent<Animator>().enabled = false;
        enemyButton5.GetComponent<Animator>().enabled = false;
        playerCementery.GetComponent<Animator>().enabled = true;
        enemyCementery.GetComponent<Animator>().enabled = true;

        abortButton.GetComponent<Animator>().enabled = false;


        downButton0.GetComponent<Button>().enabled = true;
        downButton1.GetComponent<Button>().enabled = true;
        downButton2.GetComponent<Button>().enabled = true;
        downButton3.GetComponent<Button>().enabled = true;
        downButton4.GetComponent<Button>().enabled = true;
        downButton5.GetComponent<Button>().enabled = true;

        enemyButton0.GetComponent<Button>().enabled = false;
        enemyButton0.GetComponent<Button>().enabled = false;
        enemyButton0.GetComponent<Button>().enabled = false;
        enemyButton0.GetComponent<Button>().enabled = false;
        enemyButton0.GetComponent<Button>().enabled = false;
        enemyButton0.GetComponent<Button>().enabled = false;
        playerCementery.GetComponent<Button>().enabled = true;
        enemyCementery.GetComponent<Button>().enabled = true;
        abortButton.GetComponent<Button>().enabled = false;


        enemyButton0.GetComponent<Image>().color = temporalColor;
        enemyButton1.GetComponent<Image>().color = temporalColor;
        enemyButton2.GetComponent<Image>().color = temporalColor;
        enemyButton3.GetComponent<Image>().color = temporalColor;
        enemyButton4.GetComponent<Image>().color = temporalColor;
        enemyButton5.GetComponent<Image>().color = temporalColor;
        abortButton.GetComponent<Image>().color = temporalColor;
    }
    public void BackToHand()
    {
        enemyLifeText.GetComponent<Text>().text = ("Enemy Life" + '\n' + " 00");
        yourLifeText.GetComponent<Text>().text = ("Your Life" + '\n' + " 00");
        yourManaText.GetComponent<Text>().text = ("Your Mana" + '\n' + " 00");
        handView.transform.position = handView.transform.position + new Vector3(-1030.0f, 0.0f, 0.0f);

    }
    public void ChooseAttack()
    {
        var botonActual = EventSystem.current;

        downButton0.GetComponent<Animator>().enabled = false;
        downButton1.GetComponent<Animator>().enabled = false;
        downButton2.GetComponent<Animator>().enabled = false;
        downButton3.GetComponent<Animator>().enabled = false;
        downButton4.GetComponent<Animator>().enabled = false;
        downButton5.GetComponent<Animator>().enabled = false;

        enemyButton0.GetComponent<Animator>().enabled = true;
        enemyButton1.GetComponent<Animator>().enabled = true;
        enemyButton2.GetComponent<Animator>().enabled = true;
        enemyButton3.GetComponent<Animator>().enabled = true;
        enemyButton4.GetComponent<Animator>().enabled = true;
        enemyButton5.GetComponent<Animator>().enabled = true;
        playerCementery.GetComponent<Animator>().enabled = false;
        enemyCementery.GetComponent<Animator>().enabled = false;

        abortButton.GetComponent<Animator>().enabled = true;


        downButton0.GetComponent<Button>().enabled = false;
        downButton1.GetComponent<Button>().enabled = false;
        downButton2.GetComponent<Button>().enabled = false;
        downButton3.GetComponent<Button>().enabled = false;
        downButton4.GetComponent<Button>().enabled = false;
        downButton5.GetComponent<Button>().enabled = false;

        enemyButton0.GetComponent<Button>().enabled = true;
        enemyButton0.GetComponent<Button>().enabled = true;
        enemyButton0.GetComponent<Button>().enabled = true;
        enemyButton0.GetComponent<Button>().enabled = true;
        enemyButton0.GetComponent<Button>().enabled = true;
        enemyButton0.GetComponent<Button>().enabled = true;
        playerCementery.GetComponent<Button>().enabled = false;
        enemyCementery.GetComponent<Button>().enabled = false;
        abortButton.GetComponent<Button>().enabled = true;
        downButton0.GetComponent<Image>().color = temporalColor;
        downButton1.GetComponent<Image>().color = temporalColor;
        downButton2.GetComponent<Image>().color = temporalColor;
        downButton3.GetComponent<Image>().color = temporalColor;
        downButton4.GetComponent<Image>().color = temporalColor;
        downButton5.GetComponent<Image>().color = temporalColor;
        playerCementery.GetComponent<Image>().color = temporalColor;
        enemyCementery.GetComponent<Image>().color = temporalColor;
        Debug.Log(botonActual.currentSelectedGameObject.name);

    }
    public void EnterToPlayPhase()
    {
        enemyLifeText.GetComponent<Text>().text = ("Enemy Life" + '\n' + " 00");
        yourLifeText.GetComponent<Text>().text = ("Your Life" + '\n' + " 00");
        yourManaText.GetComponent<Text>().text = ("Your Mana" + '\n' + " 00");
        handView.transform.position = handView.transform.position + new Vector3(-1030.0f, 0.0f, 0.0f);
        screenAppear.transform.position = screenAppear.transform.position + new Vector3(0.0f, 412.0f, 0.0f);
        screenAppear.GetComponent<Animator>().Play(null, -1, 0);
        textPhase.GetComponent<Text>().text = "Play Phase";

    }

    public void HandView()
    {

    }

    public void GoToDesk()
    {
        handView.transform.position = handView.transform.position + new Vector3(1030.0f, 0.0f, 0.0f);
    }
    public void PassTurn()
    {
        if (takeCard == true && battle == false)
        {
            screenAppear.transform.position = screenAppear.transform.position + new Vector3(0.0f, 412.0f, 0.0f);
            screenAppear.GetComponent<Animator>().Play(null, -1, 0);
            textPhase.GetComponent<Text>().text = "Enemy Turn";
            takeCard = false;
            battle = false;
            enemy = true;
            enemyCementery.GetComponent<Animator>().enabled = true;
            enemyCementery.GetComponent<Button>().enabled = true;
        }
        else
        {
            if (takeCard == false && enemy == true)
            {
                screenAppear.transform.position = screenAppear.transform.position + new Vector3(0.0f, 412.0f, 0.0f);
                handView.transform.position = handView.transform.position + new Vector3(-1030.0f, 0.0f, 0.0f);
                screenAppear.GetComponent<Animator>().Play(null, -1, 0);
                textPhase.GetComponent<Text>().text = ("Your Turn\nTake a Card");
                enemy = false;
                takeCard = false;
                battle = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        takeCard = false;
        battle = false;
        enemy = false;
        slideText = GameObject.Find("MessagesTextUI");
        textPhase = GameObject.Find("UserPhaseText");
        textPhase.GetComponent<Text>().text = ("Your Turn\nTake a Card");
        screenAppear = GameObject.Find("MessagesUi");
        playerDeck = GameObject.Find("downDeckCards");
        playerCementery = GameObject.Find("downCementeryCards");
        enemyCementery = GameObject.Find("upCementeryCards");
        downButton0 = GameObject.Find("downCardPlace");
        downButton1 = GameObject.Find("downCardPlace (1)");
        downButton2 = GameObject.Find("downCardPlace (2)");
        downButton3 = GameObject.Find("downCardPlace (3)");
        downButton4 = GameObject.Find("downCardPlace (4)");
        downButton5 = GameObject.Find("downCardPlace (5)");
        enemyButton0 = GameObject.Find("upCardPlace");
        enemyButton1 = GameObject.Find("upCardPlace (1)");
        enemyButton2 = GameObject.Find("upCardPlace (2)");
        enemyButton3 = GameObject.Find("upCardPlace (3)");
        enemyButton4 = GameObject.Find("upCardPlace (4)");
        enemyButton5 = GameObject.Find("upCardPlace (5)");
        yourLifeText = GameObject.Find("yourchampionText");
        yourManaText = GameObject.Find("yourManaText");
        enemyLifeText = GameObject.Find("enemyChampionText");
        abortButton = GameObject.Find("upDeckCards");
        handView = GameObject.Find("handView");
        temporalColor = downButton0.GetComponent<Image>().color;
        temporalColor.a = 0f;
    }


}
