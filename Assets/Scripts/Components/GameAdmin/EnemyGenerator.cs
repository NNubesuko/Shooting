using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    [SerializeField] private GameObject enemy;

    public bool WasLastEnemyDefeated { get; private set; } = false;

    private string enemyJsonName = "Json/Enemy";
    private string enemyJson;
    private List<EnemyPair> enemyPairs = new List<EnemyPair>();
    private float currentTime = 0f;
    private int currnetGenerateEnemyIndex = 0;
    
    private float lastEnemyGenerateTime;
    private GameObject lastEnemy;

    private void Start() {
        enemyJson = Resources.Load<TextAsset>(enemyJsonName).ToString();
        EnemyEntities enemyEntities = JsonUtility.FromJson<EnemyEntities>(enemyJson);
        EnemyEntity[] enemyEntity = enemyEntities.entities;
        // ラグ対策で1秒加算している
        lastEnemyGenerateTime = enemyEntity[enemyEntity.Length - 1].generateTime + 1;
        
        // 敵を初期化メソッドで初期化し、リストに追加
        for (int enemyIndex = 0; enemyIndex < enemyEntity.Length; enemyIndex++) {
            GameObject enemyObject = InitEnemyObject(enemyEntity[enemyIndex]);
            enemyPairs.Add(
                new EnemyPair(
                    enemyEntity[enemyIndex].generateTime,
                    enemyObject
                )
            );
        }
    }

    private void Update() {
        currentTime += Time.deltaTime;
        
        if (currentTime > lastEnemyGenerateTime && !GameObject.FindWithTag("Enemy")) {
            WasLastEnemyDefeated = true;
        }

        if (enemyPairs.Count <= currnetGenerateEnemyIndex) return;

        if (enemyPairs[currnetGenerateEnemyIndex].generateTime <= currentTime) {
            enemyPairs[currnetGenerateEnemyIndex].enemy.SetActive(true);
            currnetGenerateEnemyIndex++;
        }
    }

    /*
     * Jsonファイルを読み込むメソッド
     */
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

    /*
     * 敵を初期化するヘルプメソッド
     */
    private GameObject InitEnemyObject(EnemyEntity enemyEntity) {
        GameObject enemyObject = Instantiate(enemy, enemyEntity.initPosition, Quaternion.identity);
        Enemy enemyScript = enemyObject.GetComponent<EnemyMain>();

        enemyScript.Init(
            EnemyHP.Of(enemyEntity.hp),
            EnemyAP.Of(enemyEntity.ap),
            EnemyMoveSpeed.Of(enemyEntity.moveSpeed),
            EnemyMoveSpeedMagnification.Of(enemyEntity.magnification),
            enemyEntity.moveTargetTable,
            EnemyPoint.Of(enemyEntity.point)
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