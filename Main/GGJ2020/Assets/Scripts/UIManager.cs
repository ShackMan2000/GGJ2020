using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private FloatRef buildMaterial;

    [SerializeField]
    private TextMeshProUGUI tilesText;


    private void Update()
    {
        tilesText.SetText(buildMaterial.CurrentUnits.ToString());
    }




}
