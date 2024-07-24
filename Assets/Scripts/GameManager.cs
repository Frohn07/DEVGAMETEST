using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField]
    private Player player;
    [SerializeField]
    private EnemySpawner enemySpawner;
    [SerializeField]
    private PickupBonusSpawner pickupBonusSpawner;
    [SerializeField]
    private ZoneSpawner zoneSpawner;

    [Header("Prefabs")]
    [SerializeField]
    private List<Enemy> enemiePrefabs;
    [SerializeField]
    private List<WeaponBonus> weaponPickupBonusPrefabs;
    [SerializeField]
    private List<PickupBonus> strengtheningPickupBonusPrefabs;
    [SerializeField]
    private Zone slowdownZone;
    [SerializeField]
    private Zone deathZone;


    [Header("Map Parameters")]
    [SerializeField]
    private float xAxisSpawnRange;
    [SerializeField]
    private float zAxisSpawnRange;

    [Header("UI")]
    [SerializeField]
    private UI_Result uI_ResultPanel;




    public void INIT()
    {
        player.Init();
        enemySpawner.Init(enemiePrefabs, player.transform, xAxisSpawnRange, zAxisSpawnRange);
        pickupBonusSpawner.Init(weaponPickupBonusPrefabs, strengtheningPickupBonusPrefabs, player, xAxisSpawnRange, zAxisSpawnRange);
        zoneSpawner.Init(slowdownZone, deathZone, xAxisSpawnRange, zAxisSpawnRange);
    }

    private void Awake()
    {
        INIT();
    }

    private void OnEnable()
    {
        PlayerHealth.PlayerHealthIsOverEvent += GameOver;
    }
    private void OnDisable()
    {
        PlayerHealth.PlayerHealthIsOverEvent -= GameOver;
    }

    private void Start()
    {
        enemySpawner.StartSpawnEnemy();
        pickupBonusSpawner.StartSpawmBonuses();
        zoneSpawner.SpawnZones();
    }


    private void GameOver()
    {
        enemySpawner.StopSpawnEnemy();
        pickupBonusSpawner.StopSpawnBonuses();

        GameParametersManager.CheckAndSaveRecord();

        ShowResult();
    }

    private void ShowResult()
    {
        uI_ResultPanel.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
