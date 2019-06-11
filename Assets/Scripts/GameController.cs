using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text textHp;
    public Text textCoins;
    public int countCoins=10;
    static GameController instance;
    public float targetSpeed = 10f;

    public int countHP = 1500;
    public Text textHP;
    public int coins = 1500;
    // Start is called before the first frame update
    private void Awake()
    {

        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public static GameController GetGame()
    {
        return instance;
    }
    public void TargetFinished()
    {
        countHP -= 100;
        textHP.text = countHP.ToString();
    }
    public void EnemyDamaged()
    {
        countCoins += 1;
        textCoins.text = countCoins.ToString();
    }
public void PlacedTower()
{
    countCoins-=5;
    textCoins.text=countCoins.ToString();
}

}