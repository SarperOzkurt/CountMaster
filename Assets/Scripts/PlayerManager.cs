using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : APool
{
    public Transform player;
    public int numberOfStickmans = 1;
    [SerializeField] private TextMeshPro CounterText;
    [SerializeField] private GameObject stickMan;

    [Range(0, 1f)] [SerializeField] private float distance, radius=1f;
    private float playerresetx, playerresetz;
    private Vector3 playernewpos;

    private Camera cam;
    public GameObject SecondCam;
    public bool moveByTouch, gamestate;
    public float playerSpeed = 5f, roadSpeed = 5f,currentRoadSpeed = 20.0f;
    Vector3 mouseStartPos, playerStartPos;

   

    [SerializeField] private Transform road;

    private int cnumber = 0;

    bool FinishLine = false;


    void Start()
    {
        player = transform;
        CreatePool(stickMan, transform, 1000);
        GameObject o =  Out(pool[0]);
        o.transform.localPosition = Vector3.zero;

        CounterText.text = numberOfStickmans.ToString();
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetMouseButtonDown(0) && gamestate)
        {
            moveByTouch = true;
            var plane = new Plane(Vector3.up, 0f);

            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                mouseStartPos = ray.GetPoint(distance + 1f);
                playerStartPos = transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveByTouch = false;
        }

        if (moveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);

            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                var mousePos = ray.GetPoint(distance + 1f);

                var move = mousePos - mouseStartPos;

                var control = playerStartPos + move;

                if (numberOfStickmans > 40)
                {
                    control.x = Mathf.Clamp(control.x, -6f, 6f);
                }
                else
                {
                    control.x = Mathf.Clamp(control.x, -11f, 11f);
                }
             

                transform.position = new Vector3(Mathf.Lerp(transform.position.x, control.x, Time.deltaTime * playerSpeed), transform.position.y, transform.position.z);
            }
        }

        if (gamestate)
        {
            road.Translate(road.forward * Time.deltaTime * -roadSpeed);
            
            for (int i = 2; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Animator>().SetBool("Run", true);
            }
        }
    }
    public void ResetStickMan()
    {

        numberOfStickmans = outPool.Count;
        for (int i = 1; i <numberOfStickmans; i++)
        {
            playerresetx = distance * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            playerresetz = distance * Mathf.Sqrt(i) * Mathf.Sin(i * radius);

            playernewpos = new Vector3(playerresetx, 0, playerresetz);

            outPool[i].transform.DOLocalMove(playernewpos, .2f).SetEase(Ease.OutBack);
        }
    }
   
    private void MakeStickMan(int number)
    {
        GameObject o;
         for (int i = 0; i < number; i++)
        {
            o = Out(pool[i]);
            o.transform.localPosition = Vector3.zero;
        }

        CounterText.text = numberOfStickmans.ToString();
        ResetStickMan();
    }


    int targetCount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            other.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            other.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled = false;

            var gateManager = other.GetComponent<GateManager>();
            if (gateManager.multiply)
            {
                numberOfStickmans *= gateManager.randomNumber;
                numberOfStickmans -= outPool.Count;
                MakeStickMan(numberOfStickmans);
            }
            else
            {
                numberOfStickmans += gateManager.randomNumber;
                numberOfStickmans -= outPool.Count;
                MakeStickMan(numberOfStickmans);
            }

        }

        if (other.CompareTag("Finish"))
        {
            Tower.ToweInstance.CreateTower();
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
