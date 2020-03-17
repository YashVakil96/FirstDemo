using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{ 
    public Transform player;

    public ObjectPooler[] ObjectPools;
    public ObjectPooler[] AirObjectPools;

    public Transform maxHeightPoint;
    public float distMin;
    public float distMax;
    public float maxHeightChange;
    public float CoinThreashold;
    public float EnemyThreashold;
    public float SpikeThreashold;
    public float AirPlatformDistance;

    private float[] platformwidth;
    private float[] Airplatformwidth;

    private int PlatformSelector;
    private int AirPlatformSelector;

    private Vector2 screenBounds;
    private float playerDistance;
    private float currentDistance;
    private float minHeight;
    private float maxHeight;
    private float heightChange;
    private float distanceBetween;
    private CoinGenerator CoinGenerator;
    private EnemyGenerator EnemyGenerator;
    private SpikeGenerator SpikeGenerator;
    private Spike spike;
    private float place;
    private int no;
    private bool IsAir;
    private Score scorepoint;
    private bool EnemyGen=false;
    private Vector3 spikeInfo;

    //private float theWidth;

    GameObject newPlatform;
    void Start()
    {
        scorepoint = FindObjectOfType<Score>();
        platformwidth = new float[ObjectPools.Length];
        for (int i = 0; i < ObjectPools.Length; i++)
        {
            platformwidth[i] = ObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        Airplatformwidth = new float[AirObjectPools.Length];
        for (int j = 0; j < AirObjectPools.Length; j++)
        {
            Airplatformwidth[j] = AirObjectPools[j].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerDistance = transform.position.x - player.position.x;
        CoinGenerator = FindObjectOfType<CoinGenerator>();
        EnemyGenerator = FindObjectOfType<EnemyGenerator>();
        SpikeGenerator = FindObjectOfType<SpikeGenerator>();
        spike = FindObjectOfType<Spike>();
    }

    void Update()
    {
        currentDistance= transform.position.x - player.position.x;
            if (currentDistance < playerDistance)
            {
                if (transform.position.x > screenBounds.x)
                {
                    distanceBetween = (Random.Range(distMin, distMax));

                    PlatformSelector = Random.Range(0, ObjectPools.Length);
                    AirPlatformSelector = Random.Range(0, AirObjectPools.Length);

                    heightChange = transform.position.y - Random.Range(maxHeightChange, -maxHeightChange);

                    if (heightChange > maxHeight)
                        heightChange = maxHeight;
                    else if (heightChange < minHeight)
                        heightChange = minHeight;
                    if (heightChange != minHeight)
                    {
                        IsAir = true;
                    }
                    else
                    {
                        IsAir = false;
                    }

                    if (IsAir)
                    {
                        //AIR CODE
                        //Debug.Log("True  AIR");
                        transform.position = new Vector3(transform.position.x + (Airplatformwidth[AirPlatformSelector]) / 2 + distanceBetween, heightChange, transform.position.z);
                        newPlatform = AirObjectPools[AirPlatformSelector].GetPooledObject();
                    }


                    else
                    {
                        //GROUND CODE
                        //Debug.Log("False  GROUND");
                        transform.position = new Vector3(transform.position.x + (platformwidth[PlatformSelector])/2 + distanceBetween, heightChange, transform.position.z);
                        newPlatform = ObjectPools[PlatformSelector].GetPooledObject();
                    }


                        newPlatform.transform.position = transform.position;
                        newPlatform.transform.rotation = transform.rotation;
                        newPlatform.SetActive(true);

                if (scorepoint.ScorePoint>5000)
                {
                    if ((platformwidth[PlatformSelector]) > 15)
                    {
                        if (Random.Range(0f, 100f) < EnemyThreashold)
                        {
                            place = 4;
                            no = Random.Range(0, 4);
                            if (no == 0 || no == 1)
                                place = 4f;
                            else if (no == 2 || no == 3)
                                place = 3.4f;
                            if (IsAir)
                            {
                                float PosX = Random.Range((-(Airplatformwidth[AirPlatformSelector]) / 2) + 10, ((Airplatformwidth[AirPlatformSelector]) / 2) - 10);
                                EnemyGenerator.SpawnEnemy(new Vector3(transform.position.x + PosX, transform.position.y + place, transform.position.z), no);
                                EnemyGen = true;

                            }
                            else
                            {
                                float PosX = Random.Range((-(platformwidth[PlatformSelector]) / 2) + 10, ((platformwidth[PlatformSelector]) / 2) - 10);
                                EnemyGenerator.SpawnEnemy(new Vector3(transform.position.x + PosX, transform.position.y + place, transform.position.z), no);
                                EnemyGen = true;
                            }
                        }
                        else
                        {
                            EnemyGen = false;
                        }
                    }
                }
                if (Random.Range(0f, 100f) < SpikeThreashold)
                {
                    if (EnemyGen==false)
                    {
                        //Debug.Log(EnemyGen);
                        if (IsAir)
                        {
                            float PosX = Random.Range((-(Airplatformwidth[AirPlatformSelector]) / 2) + 10, ((Airplatformwidth[AirPlatformSelector]) / 2) - 10);
                            spikeInfo = new Vector3(transform.position.x + PosX, transform.position.y + 1f, transform.position.z);
                            SpikeGenerator.SpawnSpike(spikeInfo);

                        }
                        else
                        {
                            float PosX = Random.Range((-(platformwidth[PlatformSelector]) / 2) + 10, ((platformwidth[PlatformSelector]) / 2) - 10);
                            spikeInfo = new Vector3(transform.position.x + PosX, transform.position.y + 2f, transform.position.z);
                            SpikeGenerator.SpawnSpike(spikeInfo);

                        }
                    }

                }

                if (Random.Range(0f, 100f) < CoinThreashold)
                    {
                    //Coin Generation Code
                    if (IsAir)
                    {
                        int startpoint = (int)-Airplatformwidth[AirPlatformSelector]/ 2;
                        int endpoint = (int)Airplatformwidth[AirPlatformSelector] / 2;
                        
                        for (int i = startpoint; i < endpoint; i += 5)
                        {
                            int heihtRandom = Random.Range(1, 5);
                            CoinGenerator.SpawnCoins(new Vector3(transform.position.x + i + 0.7f, transform.position.y + 3f+heihtRandom, transform.position.z));
                        }
                    }
                    else
                    {
                        int startpoint = (int)-platformwidth[PlatformSelector] / 2;
                        int endpoint = (int)platformwidth[PlatformSelector] / 2;
                        for (int i = startpoint; i < endpoint; i += 5)
                        {
                            int heihtRandom = Random.Range(1, 5);

                            CoinGenerator.SpawnCoins(new Vector3(transform.position.x + i + 0.7f, transform.position.y + 5f + heihtRandom, transform.position.z));
                        }
                    }
                }
                    
                    if (IsAir)
                    {
                        transform.position = new Vector3(transform.position.x + (Airplatformwidth[AirPlatformSelector]) / 2, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x + (platformwidth[PlatformSelector])/2, transform.position.y, transform.position.z);
                    }
                }
            }
    }



    private void LateUpdate()
    {
        if (transform.position.y > AirPlatformDistance)
        {
            IsAir = true;
        }
        else
        {
            IsAir = false;

        }
    }
}