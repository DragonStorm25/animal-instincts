using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class displayLimitedTimeObject : MonoBehaviour
{
    public ParticleSystem spawnEffect;
    public ParticleSystem despawnEffect;
    [SerializeField] private float _duration = 10;
    [SerializeField] private GameObject _objectToDisplay;

    // Start is called before the first frame update

    private bool isActive = false;
    private float timeLeft;
    void Start()
    {
        //hide object
        if(_objectToDisplay != null)
        {
            _objectToDisplay.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0)
            {
                isActive = false;
                _objectToDisplay.SetActive(false);
                DoParticleEffect(despawnEffect);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player" && !isActive)
        {
            isActive = true;
            timeLeft = _duration;
            _objectToDisplay.SetActive(true);
            DoParticleEffect(spawnEffect);
        }
    }

    private void DoParticleEffect(ParticleSystem particle) {
        Tilemap tilemap = _objectToDisplay.GetComponent<Tilemap>();
        if(tilemap != null) {
            BoundsInt bounds = tilemap.cellBounds;
            TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

            for (int x = 0; x < bounds.size.x; x++) {
                for (int y = 0; y < bounds.size.y; y++) {
                    TileBase tile = allTiles[x + y * bounds.size.x];
                    Vector3Int localPlace = (new Vector3Int(x, y, (int) tilemap.transform.position.y));
                    Vector3 place = tilemap.GetCellCenterWorld(localPlace) + bounds.position;
                    if (tile != null) {
                        // Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name + " place: " + place);
                        Instantiate(particle, place, new Quaternion(1, 0, 0, 0));
                    }
                }
            } 
        }
    }

    public IEnumerator DisplaySequence()
    {
        //display 
        _objectToDisplay.SetActive(true);
        //wait for some amount of time 
        yield return new WaitForSeconds(_duration);
        //disappear 
        _objectToDisplay.SetActive(false);
    }
}