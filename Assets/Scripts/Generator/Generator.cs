//using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static BLOCKS;

public class Generator : MonoBehaviour
{
    [SerializeField] Player playerPrefab;
    [SerializeField] Chunck chunckPrefab;
    [SerializeField] BlockData[] blockData;
    [SerializeField] public Sprite doorSideClose;
    [SerializeField] bool useRandomSeed;
    [Space]
    [SerializeField] float globalZoom = 188;
    [SerializeField] float globalCutout = 488;
    [Space]
    public int size = 10;
    public float zoom = 10;
    public float k_1 = 10;
    public bool useK;
    [SerializeField] public int chunckSize = 88;
    [SerializeField] int countChunckY = 10;
    [SerializeField] int chunckViewDistance = 3;
    //public Tile tile;

    [SerializeField] float thresoldMain = 0.35f;
    [SerializeField] int generationOffset = 888;
    [SerializeField] bool useOptimization;

    [Header("�� �����...")]
    [SerializeField] Sprite spirt;

    public Dictionary<Vector2Int, Chunck> dict = new Dictionary<Vector2Int, Chunck>();

    public Vector2Int playerStartPos;
    public Player player;

    public BlockData[] BlocksData => blockData;


    private IEnumerator Start()
    {
        //StartCoroutine(StartGeneration());

        //var pos = GetPosStartChunck(out var startY);

        //dict.Add(pos, CreateChunck(pos.x, pos.y));

        //playerStartPos = new Vector2Int(pos.x, startY);
        //player = Instantiate(playerPrefab, new Vector3(pos.x + 0.5f, startY + 10), Quaternion.identity);
        playerStartPos = new Vector2Int(0, chunckSize + 2);
        player = Instantiate
        (
            playerPrefab, 
            new Vector3(playerStartPos.x, playerStartPos.y),
            Quaternion.identity
        );

        PlanarGeneration();

        //Debug.Log(Mathf.Pow(chunckViewDistance * 2 , 2));


        //while (dict.Count < Mathf.Pow(chunckViewDistance * 2, 2))
        //{
        //    yield return new WaitForSeconds(0.01f);
        //}

        yield return new WaitForSeconds(3f);

        //yield return new WaitForSeconds(1f);

        ////AudioManager.Instance.NoobSpawn(player.Hip);

        //var go = new GameObject("OPtosiska");
        //go.AddComponent<SpriteRenderer>().sprite = spirt;
        //go.transform.position = (Vector2)playerStartPos;


    }

    private void PlanarGeneration()
    {
        StartCoroutine(Async());

        IEnumerator Async()
        {
            var chunk = CreatePlanarChunck(0, 0);
            dict.Add(new Vector2Int(0, 0), chunk);

            yield return new WaitForEndOfFrame();

            var landSize = chunckViewDistance * chunckSize;
            for (int x = -landSize; x <= landSize; x += chunckSize)
            {
                if (x == 0)
                    continue;

                chunk = CreatePlanarChunck(x, 0);
                dict.Add(new Vector2Int(x, 0), chunk);

                yield return new WaitForEndOfFrame();
            }
        }
    }


    //488 - 188
    private IEnumerator StartGeneration()
    {
        //Random.InitState(888888);

        var tilemap = Instantiate(chunckPrefab, Vector2.zero, Quaternion.identity).Tilemap;

        for (int x = 0; x < size; x++)
        {
            yield return null;

            for (int y = 0; y < size; y++)
            {
                int idBlock = DIRT;
                var globalNoise = Mathf.PerlinNoise(x / globalZoom, y / globalZoom);
                globalNoise /= y / globalCutout;
                //print(globalNoise);

                if(globalNoise > 0.5f)
                {
                    if (globalNoise > 0.6f)
                        idBlock = 2;

                    var t = ScriptableObject.CreateInstance(typeof(Tile)) as Tile;
                    t.sprite = blockData[idBlock].sprite;
                    tilemap.SetTile(new Vector3Int(x, y, 0), t);
                }

                //var noise = Mathf.PerlinNoise(x / zoom, y / zoom);
                //if (useK)
                //{
                //    noise /= y / k_1;
                //}
                //if(noise > thresoldMain)
                //{
                //    //var cave = Mathf.PerlinNoise(x / zoom, y / zoom);
                //    var cave = 1;
                //    if (cave > thresoldMain)
                //    {
                //        if (noise > 0.6f)
                //            idBlock = 2;


                //        //tile.sprite = blockData[idBlock].sprite;
                //        var t = ScriptableObject.CreateInstance(typeof(Tile)) as Tile;
                //        t.sprite = blockData[idBlock].sprite;
                //        //tilemap.SetTile(new(x, y, 0), t);
                //    }
                //}
            }
        }

        //SetGroundBlock();
    }

    public Chunck CreateChunck(int posX, int posY)
    {
        var chunck = Instantiate(chunckPrefab, new Vector3(posX, posY), Quaternion.identity);
        chunck.name += $" {chunck.GetHashCode()}";

        for (int x = 0; x < chunckSize; x++)
        {
            for (int y = 0; y < chunckSize; y++)
            {
                var idBlock = GetBlockID(x + posX, y + posY);

                if (idBlock == 0)
                    continue;
                
                var t = ScriptableObject.CreateInstance(typeof(Tile)) as Tile;
                t.sprite = blockData[idBlock].sprite;
                chunck.Tilemap.SetTile(new Vector3Int(x, y, 0), t);
                chunck.TilemapBack.SetTile(new Vector3Int(x, y, 0), t);
            }
        }

        return chunck;
    }

    public Chunck CreatePlanarChunck(int posX, int posY)
    {
        var chunck = Instantiate(chunckPrefab, new Vector3(posX, posY), Quaternion.identity);
        chunck.name += $" {chunck.GetHashCode()}";

        for (int x = 0; x < chunckSize; x++)
        {
            for (int y = 0; y < chunckSize; y++)
            {
                int idBlock;
                if (y == chunckSize - 1)
                {
                    idBlock = GROUND;
                }
                else
                {
                    idBlock = GetBlockID(x + posX, y + posY);
                    if (idBlock == GROUND && y + 1 == chunckSize - 1)
                    {
                        idBlock = DIRT;
                    }
                }

                if (idBlock == 0)
                    continue;

                var t = ScriptableObject.CreateInstance(typeof(Tile)) as Tile;
                t.sprite = blockData[idBlock].sprite;
                chunck.Tilemap.SetTile(new Vector3Int(x, y, 0), t);
                chunck.TilemapBack.SetTile(new Vector3Int(x, y, 0), t);
            }
        }

        return chunck;
    }

    public int GetBlockID(int posX, int posY)
    {
        int idBlock = EMPTY;

        var globalNoise = Mathf.PerlinNoise((posX + generationOffset) / globalZoom, posY / globalZoom);
        globalNoise /= posY / globalCutout;

        if (globalNoise > 0.5f)
        {
            var noise = Mathf.PerlinNoise((posX + generationOffset) / zoom, posY / zoom);

            if (noise > thresoldMain)
            {
                idBlock = DIRT;

                if (noise > thresoldMain + 0.1f)
                {
                    idBlock = STONE;
                }
                if (idBlock == DIRT)// �������� �� ������� ���� �����
                {
                    if (GetBlockID(posX, posY + 1) == 0)
                    {
                        idBlock = GROUND;
                    }
                }
            }
        }

        return idBlock;
    }

    public Chunck GetChunck(Vector2 pos)
    {
        int singleX = (Mathf.FloorToInt(pos.x / chunckSize)) * chunckSize;
        int singleY = (Mathf.FloorToInt(pos.y / chunckSize)) * chunckSize;
        Vector2Int singlePos = new Vector2Int(singleX, singleY);
        if (dict.ContainsKey(singlePos))
        {
            return dict[singlePos];
        }
        else
        {
            CreateChunck(singleX, singleY);
            Debug.Log("����� �� ����������");
            return null;
        }
    }

    void SetGroundBlock(Tilemap tilemap)
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                var tile = tilemap.GetTile<Tile>(new Vector3Int(x, y,0));
                if (tile && tile.sprite == blockData[1].sprite)
                {
                    var topTile = tilemap.GetTile<Tile>(new Vector3Int(x, y + 1,0));
                    if (!topTile)
                    {
                        //print(tile.sprite);
                        tile.sprite = blockData[0].sprite;
                        
                        //tilemap.SetTile(new(x, y), new Tile() { sprite = blockData[0].sprite});
                        tilemap.RefreshTile(new Vector3Int(x, y, 0));
                    }
                }
            }
        }
    }

    Vector2Int GetPosStartChunck(out int startY)
    {
        var posX = Random.Range(-100, 100);
        var posY = 0;
        startY = 0;

        posX *= chunckSize;

        for (int y = chunckSize * countChunckY; y > 0; y--)
        {
            var id = GetBlockID(posX, y);
            if (id >= 0)
            {
                startY = y;
                posY = y / chunckSize;
                break;
            }
        }

        return new Vector2Int(posX, posY * chunckSize);
    }

    void Ebala()
    {
        // ====== Right ======
        int rightX = ((int)player.Hip.position.x / chunckSize) * chunckSize;
        int rightY = ((int)player.Hip.position.y / chunckSize) * chunckSize;

        rightY -= chunckSize;

        Vector2Int rightPos = new Vector2Int(rightX, rightY);
        if (!dict.ContainsKey(rightPos))
        {
            var chunck = CreateChunck(rightX, rightY);
            dict.Add(rightPos, chunck);
            return;
        }
        // ========================
    }

    void DynamicCreateChunck()
    {
        int singleX = ((int)player.Hip.position.x / chunckSize) * chunckSize;
        int singleY = ((int)player.Hip.position.y / chunckSize) * chunckSize;

        Vector2Int singlePos = new Vector2Int(singleX, singleY);
        if (!dict.ContainsKey(singlePos))
        {
            var chunck = CreateChunck(singleX, singleY);
            dict.Add(singlePos, chunck);
            return;
        }

        // ==== Bottom ======
        int bottomX = ((int)player.Hip.position.x / chunckSize) * chunckSize;
        int bottomY = ((int)player.Hip.position.y / chunckSize) * chunckSize;

        bottomY -= chunckSize;

        Vector2Int bottomPos = new Vector2Int(bottomX, bottomY);
        if (!dict.ContainsKey(bottomPos))
        {
            var chunck = CreateChunck(bottomX, bottomY);
            dict.Add(bottomPos, chunck);
            return;
        }
        // ==================

        // ====== Right ======
        int rightX = ((int)player.Hip.position.x / chunckSize) * chunckSize;
        int rightY = ((int)player.Hip.position.y / chunckSize) * chunckSize;

        rightY -= chunckSize;

        Vector2Int rightPos = new Vector2Int(rightX, rightY);
        if (!dict.ContainsKey(rightPos))
        {
            var chunck = CreateChunck(rightX, rightY);
            dict.Add(rightPos, chunck);
            return;
        }
        // ========================

        for (int x = -chunckViewDistance-1; x < chunckViewDistance; x++)
        {
            for (int y = -chunckViewDistance; y < chunckViewDistance+1; y++)
            {
                int chunckX = ((int)player.Hip.position.x / chunckSize) * chunckSize;
                int chunckY = ((int)player.Hip.position.y / chunckSize) * chunckSize;

                chunckX += x * chunckSize;
                chunckY += y * chunckSize;

                Vector2Int pos = new Vector2Int(chunckX, chunckY);
                if (!dict.ContainsKey(pos))
                {
                    var chunck = CreateChunck(chunckX, chunckY);
                    dict.Add(pos, chunck);
                    return;
                }
            }
        }
    }

    private void Update()
    {
        //DynamicCreateChunck();

        //PerfomanceMagic();
    }

    void PerfomanceMagic()
    {
        if (!useOptimization)
            return;

        foreach (var item in dict)
        {
            var visible = item.Value.Distance(player.Hip.position) < 380;

            item.Value.Tilemap.gameObject.SetActive(visible);
        }
    }

    [System.Serializable]
    public class BlockData
    {
        public string name;
        public Sprite sprite;
    }
}

[System.Serializable]
public class BuildData
{
    public TextAsset tilesData;
    public int leftPos;
}
