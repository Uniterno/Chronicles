using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayCard : MonoBehaviour
{
    public Card card;
    public Text TName;
    public Text TCost;
    public Text Tatk;
    public Text Tdef;
    public Text TcardText;
    public Text Teffect;
    public Image Tartwork;
    void Start()
    {
        TName.text = card.cardName;
        TCost.text = card.Mcost.ToString();
        Tatk.text = card.atk.ToString();
        Tdef.text = card.def.ToString();
        TcardText.text = card.cardText;
        Tartwork.sprite = card.art;
    }
    

}
