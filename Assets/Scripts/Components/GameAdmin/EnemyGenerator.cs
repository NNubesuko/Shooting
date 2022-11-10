using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private PlayerMain playerMain;

    private string enemyJsonName = "Enemy";
    private string enemyJson;
    private List<EnemyPair> enemyPairs = new List<EnemyPair>();
    private float currentTime = 0f;
    private int currnetGenerateEnemyIndex = 0;

    private void Awake() {
        enemyJson = Resources.Load<TextAsset>(enemyJsonName).ToString();

        EnemyEntities enemyEntities = JsonUtility.FromJson<EnemyEntities>(enemyJson);

        foreach (EnemyEntity enemyEntity in enemyEntities.entities) {
            GameObject enemyObject = InitEnemyObject(enemyEntity);
            enemyPairs.Add(new EnemyPair(enemyEntity.generateTime, enemyObject));
        }
    }

    private void Update() {
        if (enemyPairs.Count  <= currnetGenerateEnemyIndex) return;

        currentTime += Time.deltaTime;

        if (enemyPairs[currnetGenerateEnemyIndex].generateTime <= currentTime) {
            enemyPairs[currnetGenerateEnemyIndex].enemy.SetActive(true);
            currnetGenerateEnemyIndex++;
        }
    }

    private string ReadJsonFile(string path) {
        string json = "";

        try {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(path)) {
                json = sr.ReadToEnd();
                sr.Close();
            }
        } catch (System.IO.IOException e) {
            Debug.Log(e.Message);
        }

        return json;
    }

    private GameObject InitEnemyObject(EnemyEntity enemyEntity) {
        GameObject enemyObject = Instantiate(enemy, enemyEntity.initPosition, Quaternion.identity);
        Enemy enemyScript = enemyObject.GetComponent<EnemyMain>();

        enemyScript.Init(
            EnemyHP.Of(enemyEntity.hp),
            EnemyAP.Of(enemyEntity.ap),
            EnemyMoveSpeed.Of(enemyEntity.moveSpeed),
            EnemyPoint.Of(enemyEntity.point),
            enemyEntity.magnification,
            enemyEntity.moveTargetSwitchingInterval,
            enemyEntity.moveTargetTable,
            playerMain
        );

        return enemyObject;
    }

    private class EnemyPair {
        public float generateTime;
        public GameObject enemy;

        public EnemyPair(float generateTime, GameObject enemy) {
            this.generateTime = generateTime;
            this.enemy = enemy;
        }
    }

}