﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions; 

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance = null;

    [SerializeField]
    private Vector3 TapeSpeed = new Vector3(-2f, 0f, 0f);

    [SerializeField]    
    private Transform Tape = null; 

    public UIcomponentes uiComponentes;

    SceneData sceneData = new  SceneData();

    void Awake(){

        Assert.IsNotNull(Tape); 
        
        if (instance ==null){
            instance = this;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        Tape.position = Tape.position + TapeSpeed * Time.deltaTime;
        DisplayHudData();
    }

    public void IncrementCoinCount(){
        sceneData.coinCount++;

    }

    void DisplayHudData(){
        uiComponentes.hud.txtCoinCount.text = "x" + sceneData.coinCount;
    }

    public void SetTapeSpeed (float value){
        TapeSpeed = new Vector3 (value, TapeSpeed.y, TapeSpeed.z);
    }

    public void ShowLevelCompletePanel(){
        uiComponentes.LCPanel.Panel.SetActive(true);
        uiComponentes.LCPanel.txtScore.text = "" + sceneData.coinCount;

    }

    public void ShowGameOverPanel(){
        uiComponentes.GOPanel.Panel.SetActive(true);
        uiComponentes.GOPanel.txtScore.text = "" + sceneData.coinCount;

    }
}
