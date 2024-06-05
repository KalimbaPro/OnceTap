using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weaponPrefabs;
    public List<int> spawnChances;
    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;
    public int numberOfWeaponsToSpawn = 10;
    public float spawnInterval = 90f;
    public float despawnTime = 20f;

    private void Start()
    {
        if (weaponPrefabs.Count != spawnChances.Count)
        {
            Debug.LogError("List of weapons and spawn rate have to be equal");
            return;
        }

        StartCoroutine(SpawnWeaponsRoutine());
    }

    private IEnumerator SpawnWeaponsRoutine()
    {
        while (true)
        {
            for (int i = 0; i < numberOfWeaponsToSpawn; i++)
            {
                SpawnRandomWeapon();
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    private void SpawnRandomWeapon()
    {
        if (weaponPrefabs.Count == 0)
        {
            Debug.LogError("No weapon available");
            return;
        }

        int totalProbability = 0;
        foreach (int chance in spawnChances)
        {
            totalProbability += chance;
        }

        int randomPoint = Random.Range(0, totalProbability);
        int currentSum = 0;
        for (int i = 0; i < weaponPrefabs.Count; i++)
        {
            currentSum += spawnChances[i];
            if (randomPoint < currentSum)
            {
                GameObject weaponPrefab = weaponPrefabs[i];
                SpawnWeapon(weaponPrefab);
                break;
            }
        }
    }

    private void SpawnWeapon(GameObject weaponPrefab)
    {
        Vector3 randomSpawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        GameObject weapon = Instantiate(weaponPrefab, randomSpawnPosition, Quaternion.identity);
        // StartCoroutine(DespawnWeaponRoutine(weapon, despawnTime));
    }

    private IEnumerator DespawnWeaponRoutine(GameObject weapon, float time)
    {
        yield return new WaitForSeconds(time);
        if (weapon != null)
        {
            Destroy(weapon);
        }
    }
}
