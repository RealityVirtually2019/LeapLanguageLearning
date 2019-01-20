using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WordLabel : MonoBehaviour {
    public TextMeshPro engLabel;
    public TextMeshPro deuLable;
	public void setLabel(string deu,string eng)
    {
        engLabel.text = eng;
        deuLable.text = deu;
    }
}
