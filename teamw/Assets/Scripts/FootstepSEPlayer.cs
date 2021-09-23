using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class FootstepSEPlayer : MonoBehaviour
{
  [System.Serializable]
  public class AudioClips
  {
    public string groundTypeTag;
    public AudioClip[] audioClips;
  }
  // 足音の種類毎にタグ名とオーディオクリップを登録する
  [SerializeField] List<AudioClips> listAudioClips = new List<AudioClips>();
  // Terrain Layersと足音判定用タグの対応関係を記入する
  [SerializeField] string[] terrainLayerToTag;
  [SerializeField] bool randomizePitch = true;
  [SerializeField] float pitchRange = 0.1f;

  private Dictionary<string, int> tagToIndex = new Dictionary<string, int>();
  private int groundIndex = 0;
  private Terrain t;
  private TerrainData tData;

  protected AudioSource source;

  private void Awake()
  {
    // アタッチしたオーディオソースのうち1番目を使用する
    source = GetComponents<AudioSource>()[0];

    for(int i=0; i<listAudioClips.Count(); ++i)
      tagToIndex.Add(listAudioClips[i].groundTypeTag, i);
  }

  private void Start()
  {
    // Scene内のTerrainからデータを取得
    t = Terrain.activeTerrain;
    tData = t.terrainData;
  }

  public void RelayedTrigger(Collider other)
  {
    // あらかじめGameObjectに付けておいた足音判定用のタグを取得する
    if(tagToIndex.ContainsKey(other.gameObject.tag))
      groundIndex = tagToIndex[other.gameObject.tag];

    if(other.gameObject.GetInstanceID() == t.gameObject.GetInstanceID())
    {
      // Terrainから現在地のAlphamapを取得する
      Vector3 position = transform.position - t.transform.position;
      int offsetX = (int)(tData.alphamapWidth * position.x / tData.size.x);
      int offsetZ = (int)(tData.alphamapHeight * position.z / tData.size.z);
      float[,,] alphamaps = tData.GetAlphamaps(offsetX, offsetZ, 1, 1);

      // Alphamap中で成分が最大のTerrainLayerを探す
      float[] weights = alphamaps.Cast<float>().ToArray();
      int terrainLayer = System.Array.IndexOf(weights, weights.Max());
      groundIndex = tagToIndex[terrainLayerToTag[terrainLayer]];
    }
    // Debug.Log(groundIndex);
  }

  public void PlayFootstepSE()
  {
    // groundIndexで呼び出すオーディオクリップを変える
    AudioClip[] clips = listAudioClips[groundIndex].audioClips;

    if (randomizePitch)
      source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

    source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
  }

}