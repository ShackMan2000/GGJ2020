using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private FloatRef buildMaterial;

    [SerializeField]
    private ExplosionDetails[] explosions;

    [SerializeField]
    private GameObject gameOverScreen;


    [SerializeField]
    private int buildMaterialAtStartInUnits;


    private bool shuttingDown;


    private void Awake()
    {
        buildMaterial.SetUnitAmount(buildMaterialAtStartInUnits);

        InitialixeExplosionLists();

    }

    private void InitialixeExplosionLists()
    {
        foreach (var item in explosions)
        {
            item.FillList();
        }


    }


    public void PlayerDied()
    {
        if (!shuttingDown)
        {
            shuttingDown = true;
            StartCoroutine(GameOver());
        }
    }


    private IEnumerator GameOver()
    {

        gameOverScreen.SetActive(true);

        yield return new WaitForSeconds(3f);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);


    }



}
