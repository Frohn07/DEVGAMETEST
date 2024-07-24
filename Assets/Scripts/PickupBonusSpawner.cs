using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBonusSpawner : MonoBehaviour
{


    [SerializeField]
    private Transform weaponBonusSpawnPoint;
    [SerializeField]
    private Transform strengtheningPickupBonusSpawnPoint;

    private List<WeaponBonus> weaponPickupBonusPrefabs;
    private List<PickupBonus> strengtheningPickupBonusPrefabs;

    private float xAxisSpawnRange;
    private float zAxisSpawnRange;

    private Player playerComponent;

    [SerializeField]
    private float weaponSpawnTime;
    [SerializeField]
    private float strengtheningSpawnTime;

    private Coroutine spawnWeaponCoroutine;
    private Coroutine spawnStrengtheningCoroutine;


    public void Init(List<WeaponBonus> weaponPickupBonusPrefabs, List<PickupBonus> strengtheningPickupBonusPrefabs, Player player, float xAxisSpawnRange, float zAxisSpawnRange)
    {
        this.weaponPickupBonusPrefabs = weaponPickupBonusPrefabs;
        this.strengtheningPickupBonusPrefabs = strengtheningPickupBonusPrefabs;
        this.playerComponent = player;

        this.xAxisSpawnRange = xAxisSpawnRange;
        this.zAxisSpawnRange = zAxisSpawnRange;
    }


    public void StartSpawmBonuses()
    {
        spawnWeaponCoroutine = StartCoroutine(WeaponBonusSpawnCoroutine());
        spawnStrengtheningCoroutine = StartCoroutine(StrengtheningSpawnCoroutine());
    }
    public void StopSpawnBonuses()
    {
        StopAllCoroutines();
    }


    private IEnumerator WeaponBonusSpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(weaponSpawnTime);
            SpawnBonus(GetRandomWeaponBonus(), weaponBonusSpawnPoint);
        }
    }

    private IEnumerator StrengtheningSpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(strengtheningSpawnTime);
            SpawnBonus(GetRandomStrengtheningBonus(), strengtheningPickupBonusSpawnPoint);
        }
    }


    private void SpawnBonus(GameObject bonus, Transform spawnPoint)
    {
        Vector3 spawnPosition = GetRandomSpawnPoint(spawnPoint);
        Instantiate(bonus, spawnPosition, Quaternion.identity);
    }


    private GameObject GetRandomWeaponBonus()
    {
        WeaponBonus result = weaponPickupBonusPrefabs[Random.Range(0, weaponPickupBonusPrefabs.Count)];

        while(result.GetMyWeapon().GetIndex() == playerComponent.GetPlayerAttackComponent().GetMyActiveWeapon().GetIndex())
        {
            result = weaponPickupBonusPrefabs[Random.Range(0, weaponPickupBonusPrefabs.Count)];
        }

        return result.gameObject;
    }

    private GameObject GetRandomStrengtheningBonus()
    {
        return strengtheningPickupBonusPrefabs[Random.Range(0, strengtheningPickupBonusPrefabs.Count)].gameObject;
    }



    private Vector3 GetRandomSpawnPoint(Transform spawnPoint)
    {
        Vector3 result = Vector3.zero;
        spawnPoint.position = new Vector3(Random.Range(-xAxisSpawnRange, xAxisSpawnRange), spawnPoint.transform.position.y, Random.Range(-zAxisSpawnRange, zAxisSpawnRange));

        while (!IsVisablePosition(spawnPoint))
            spawnPoint.position = new Vector3(Random.Range(-xAxisSpawnRange, xAxisSpawnRange), spawnPoint.transform.position.y, Random.Range(-zAxisSpawnRange, zAxisSpawnRange));

        result = spawnPoint.position;

        return result;
    }


    private bool IsVisablePosition(Transform point)
    {
        Bounds objectBounds = point.gameObject.GetComponent<Renderer>().bounds;
        Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);


        return GeometryUtility.TestPlanesAABB(cameraPlanes, objectBounds);


    }
}
