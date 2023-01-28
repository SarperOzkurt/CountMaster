using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tower : MonoBehaviour
{
    private int playerAmount;
    [Range(5f, 10f)][SerializeField] private int maxPlayerRow;
    [Range(0f, 10f)] [SerializeField] private float xGap;
    [Range(0f, 10f)] [SerializeField] private float yGap;
    [Range(0f, 10f)] [SerializeField] private float yOffset;

    [SerializeField] private List<int> towerCountList = new List<int>();
    [SerializeField] private List<GameObject> towerlist = new List<GameObject>();
    public static Tower ToweInstance;
    PlayerManager playerManager;
    void Start()
    {
        ToweInstance = this;
        playerManager = GetComponent<PlayerManager>();
    }

    public void CreateTower()
    {
        playerAmount = playerManager.numberOfStickmans;
        FillTowerList();
        StartCoroutine(BuildTowerCoroutine());
    }

    void FillTowerList()
    {
        for (int i = 0; i < maxPlayerRow; i++)
        {
            if (playerAmount < 1)
            {
                break;
            }
            playerAmount -= 1;
            towerCountList.Add(i);
        }

        for (int i = maxPlayerRow; i > 0; i--)
        {
            if (playerAmount >= i)
            {
                playerAmount -= i;
                towerCountList.Add(i);
                i++;
            }
        }
    }

    IEnumerator BuildTowerCoroutine()
    {
        var towerId = 0;
        transform.DOMoveX(0f, 0.5f).SetEase(Ease.Flash);

        yield return new WaitForSecondsRealtime(0.3f);

        foreach (int towerHumanCount in towerCountList)
        {
            foreach (GameObject child in towerlist)
            {
                child.transform.DOLocalMove(child.transform.localPosition + new Vector3(0, yGap, 0), 0.2f).SetEase(Ease.OutQuad);

            }
            var tower = new GameObject("Tower" + towerId);

            tower.transform.parent = transform;
            tower.transform.localPosition = new Vector3(0, 0, 0);

            towerlist.Add(tower);

            var towerNewPos = Vector3.zero;
            float tempTowerHumanCount = 0;

            for (int i = 1; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.transform.parent = tower.transform;
                child.transform.localPosition = new Vector3(tempTowerHumanCount * xGap, 0, 0);
                towerNewPos += child.transform.position;
                tempTowerHumanCount++;
                i--;

                if (tempTowerHumanCount >= towerHumanCount)
                {
                    break;
                }
            }

            tower.transform.position = new Vector3(-towerNewPos.x / towerHumanCount, tower.transform.position.y - yOffset, tower.transform.position.z);

            towerId++;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
