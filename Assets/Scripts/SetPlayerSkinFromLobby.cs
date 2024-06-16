//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.UI;

//public class SetPlayerSkinFromLobby : MonoBehaviour
//{
//    public GameObject PlayerSkinShowcase;

//    // Start is called before the first frame update
//    void Start()
//    {
//        foreach (var item in GetComponentsInChildren<Button>())
//        {
//            item.onClick.AddListener(() =>
//            {
//                var itemSkinPrefab = item.GetComponent<PlayerSkinSetter>().PrefabToApply;

//                PlayerSkinShowcase.GetComponent<MeshFilter>().sharedMesh = itemSkinPrefab.gameObject.GetComponent<MeshFilter>().sharedMesh;
//                //PlayerSkinShowcase.GetComponent<MeshRenderer>().SetMaterials(itemSkinPrefab.gameObject.GetComponent<MeshRenderer>().materials.ToList());
//                PlayerSkinShowcase.GetComponent<MeshRenderer>().SetSharedMaterials(itemSkinPrefab.gameObject.GetComponent<MeshRenderer>().sharedMaterials.ToList());
//                LobbyScript.Instance.UpdatePlayerSkin(itemSkinPrefab.GetComponent<SkinData>().SkinId);
//            });
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//    }
//}
