/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 游戏管理器
 * 
 * Description:
 *      具体作用：
 *      1、动态生成大量道具
 *      2、设置与播放背景音乐
 *      3、显示游戏UI数值
 *      4、控制游戏开始于结束
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //单例
    public static GameManager Instantce;
    //道具
    public GameObject goAsteroidPrefab;         //小行星预设
    public int intPropSpawnNumberByAsteroid = 2;
    public Transform trSpawnAsteroidPosition;
    //敌人
    public GameObject goEnemyPrefab;         //小行星预设
    public int intPropSpawnNumberByEnemy = 4;
    public Transform trSpawnEnemyPosition;
    //分数
    public Text txt_DisplayScore;
    private int _currentScore = 0;
    //游戏开始与结束
    public GameObject goRestartTipPanel;
    private bool _isGameOver = false;
    private bool _isRestart = false;

    void Awake()
    {
        Instantce = this;
    }
    void Start()
    {
        //禁用鼠标
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //背景音乐
        AudioManager.SetAudioBackgroundVolumns(0.7f);
        AudioManager.SetAudioEffectVolumns(1f);
        AudioManager.PlayBackground("music_background");
        //游戏是否重新开始
        goRestartTipPanel.SetActive(false);

        StartCoroutine(SpawnWavesByAsteroid());
        StartCoroutine(SpawnWavesByEnemy());
    }
    void Update()
    {
        if (_isRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    /// <summary>
    /// 产生小行星道具
    /// </summary>
    IEnumerator SpawnWavesByAsteroid()
    {
        Vector3 tmp_SpawnPosition = Vector3.zero;
        Quaternion tmp_SqawnRotation = Quaternion.identity;
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (_isGameOver)
            {
                //显示游戏结束面板
                goRestartTipPanel.SetActive(true);
                //处理结束逻辑
                _isRestart = true;
            }
            else
            {
                for (int i = 0; i < intPropSpawnNumberByAsteroid; i++)
                {
                    yield return new WaitForSeconds(1f);
                    tmp_SpawnPosition.x = Random.Range(-trSpawnEnemyPosition.position.x, trSpawnEnemyPosition.position.x);
                    tmp_SpawnPosition.z = trSpawnEnemyPosition.position.z;
                    //克隆
                    Instantiate(goAsteroidPrefab, tmp_SpawnPosition, tmp_SqawnRotation);
                }
            }
        }
    }
    IEnumerator SpawnWavesByEnemy()
    {
        Vector3 tmp_SpawnPosition = Vector3.zero;
        Quaternion tmp_SqawnRotation = Quaternion.identity;
        while (true)
        {
            yield return new WaitForSeconds(5f);
            if (_isGameOver)
            {
                //显示游戏结束面板
                goRestartTipPanel.SetActive(true);
                //处理结束逻辑
                _isRestart = true;
            }
            else
            {
                for (int i = 0; i < intPropSpawnNumberByEnemy; i++)
                {
                    yield return new WaitForSeconds(2f);
                    tmp_SpawnPosition.x = Random.Range(-trSpawnAsteroidPosition.position.x, trSpawnAsteroidPosition.position.x);
                    tmp_SpawnPosition.z = trSpawnAsteroidPosition.position.z;
                    //克隆
                    Instantiate(goEnemyPrefab, tmp_SpawnPosition, tmp_SqawnRotation);
                }
            }
        }
    }

    #region 游戏分数
    /// <summary>
    /// 增加分数
    /// </summary>
    /// <param name="scoreNum"></param>
    public void AddScore(int _scoreNum)
    {
        _currentScore += _scoreNum;
        //显示分数
        UpdateCurrentScore();
    }
    /// <summary>
    /// 更新UI的分数
    /// </summary>
    private void UpdateCurrentScore()
    {
        txt_DisplayScore.text = _currentScore.ToString();
    }

    #endregion

    public void GameOver()
    {
        _isGameOver = true;
    }
}
