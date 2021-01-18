/*
 * 
 * 项目：太空射击(Space Shooting)
 * 
 * Title: 接触销毁
 * 
 * Description:
 *      具体作用：
 *      1、让道具与主角（玩家或玩家发射的子弹）触碰进行销毁
 *      
 * Version: 1.0
 *
 * Author:何柱洲
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContract : MonoBehaviour
{
    public GameObject goEnemyExplosion;
    public GameObject goPropExplosion;
    public GameObject goPlayerExplosion;

    void OnTriggerEnter(Collider _col)
    {
        switch (_col.gameObject.tag)
        {
            case "Player":                                             //敌人、敌人子弹碰玩家
                //音频处理
                AudioManager.PlayAudioEffectA("explosion_player");
                //显示特效
                Instantiate(goPropExplosion, transform.position, transform.rotation);
                Instantiate(goPlayerExplosion, _col.transform.position, _col.transform.rotation);
                //销毁脚本
                Destroy(_col.gameObject);
                Destroy(gameObject);
                //游戏结束
                GameManager.Instantce.GameOver();
                break;

            case "PlayerBult":
                if (gameObject.tag == "Enemy")                       //敌人碰玩家子弹
                {
                    //音频处理
                    AudioManager.PlayAudioEffectA("explosion_enemy");
                    //显示特效
                    Instantiate(goEnemyExplosion, transform.position, transform.rotation);
                    //分数处理
                    GameManager.Instantce.AddScore(20);
                }
                else if (gameObject.tag == "EnemyBult")             //敌人子弹碰玩家子弹，无视                  
                {
                    return;
                }
                else                                                //行星碰玩家子弹
                {
                    //音频处理
                    AudioManager.PlayAudioEffectA("explosion_asteroid");
                    //显示特效
                    Instantiate(goPropExplosion, transform.position, transform.rotation);
                    //分数处理
                    GameManager.Instantce.AddScore(10);
                }
                //销毁脚本
                Destroy(_col.gameObject);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
