using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector2 limitMin;//��ȯ�� ��������
    public Vector2 limitMax;//��ȯ�� �ִ����

    public Transform gimmickPos;
    public GameObject[] gimmickPrefab;
    GimmickPool[] gimmickPools;
    public GameObject floor;//������ �ö� �ٴ�
    int spawnCount;//���� Ƚ��
    void Start()
    {
        gimmickPools = new GimmickPool[gimmickPrefab.Length];
        for(int i =0; i < gimmickPrefab.Length; i++)
        {
            GameObject poolObject = new GameObject("Pool_" + gimmickPrefab[i].name);
            poolObject.transform.SetParent(transform);
            GimmickPool pool = poolObject.AddComponent<GimmickPool>();
            pool.prefab = gimmickPrefab[i];
            pool.initialPoolSize = 5;
            gimmickPools[i] = pool;
        }
        StartCoroutine(SpawnGimmickRoutine());
        StartCoroutine(SpawnBlock());
    }
  
    IEnumerator SpawnGimmickRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            SpawnGimmick();
            spawnCount++;
        }
    }

    void SpawnGimmick()
    {
        int randomIndex = Random.Range(0, gimmickPools.Length);
        GameObject gimmick = gimmickPools[randomIndex].GetObject();
        if(gimmick != null)
        {
            gimmick.transform.position = gimmickPos.position;
        }
    }
    public void ReturnGimmick(GameObject gimmick)
    {
        for (int i = 0; i < gimmickPools.Length; i++)
        {
            if (gimmickPools[i].prefab == gimmick)
            {
                gimmickPools[i].ReturnObject(gimmick);
                break;
            }
        }
    }
    void Update()
    {
        
    }


    IEnumerator SpawnBlock()
    {
        while (true)
        {
            spawnCount++;//1++
            float randomY = Random.Range(limitMin.y, limitMax.y);
            Vector2 spawnPos = new Vector2(limitMin.x, randomY);
            Instantiate(floor, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(limitMin, limitMax);//��ȯ ���� �׷����� ��ġ �ľ�
    }
}
