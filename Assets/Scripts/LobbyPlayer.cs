using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyPlayer : MonoBehaviour
{
    //[SerializeField] private InputActionReference skinSelectLeft;
    //[SerializeField] private InputActionReference skinSelectRight;
    [SerializeField] private List<Material> mtlBodyList = new List<Material>();
    [SerializeField] private List<Material> mtlArmsList = new List<Material>();
    [SerializeField] private List<Material> mtlLegsList = new List<Material>();
    [SerializeField] private List<string> skinNames = new List<string>();
    public int mtlSelectedId = 0;

    private StarterAssetsInputs _input;

    [SerializeField] private SkinnedMeshRenderer armature;

    //private void Awake()
    //{
    //    GetComponent<CharacterController>().enabled = false;
    //}

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        GetComponent<ThirdPersonController>().InLobbyMode = true;

        // Assign initial materials
        AssignUniqueSkin();

        //StartCoroutine(TPToLobby());
        var lobby = GameObject.FindGameObjectWithTag("Lobby").GetComponent<LobbyData>();
        Vector3 spawnPoint = new(
            Random.Range(lobby.SpawnPointCorner1.position.x, lobby.SpawnPointCorner2.position.x),
            Random.Range(lobby.SpawnPointCorner1.position.y, lobby.SpawnPointCorner2.position.y),
            Random.Range(lobby.SpawnPointCorner1.position.z, lobby.SpawnPointCorner2.position.z)
        );

        GetComponent<CharacterController>().transform.position = spawnPoint;
        //GetComponent<ThirdPersonController>().enabled = true;

        // Bind input actions
        //skinSelectLeft.action.performed += ctx => PreviousSkin();
        //skinSelectRight.action.performed += ctx => NextSkin();
    }

    private IEnumerator TPToLobby()
    {
        yield return new WaitForSeconds(1);

        var lobby = GameObject.FindGameObjectWithTag("Lobby").GetComponent<LobbyData>();
        Vector3 spawnPoint = new(
            Random.Range(lobby.SpawnPointCorner1.position.x, lobby.SpawnPointCorner2.position.x),
            Random.Range(lobby.SpawnPointCorner1.position.y, lobby.SpawnPointCorner2.position.y),
            Random.Range(lobby.SpawnPointCorner1.position.z, lobby.SpawnPointCorner2.position.z)
        );

        GetComponent<CharacterController>().transform.position = spawnPoint;
        GetComponent<CharacterController>().enabled = true;
    }

    public string GetSkinName()
    {
        return skinNames.ElementAt(mtlSelectedId);
    }

    private void UpdateSkin()
    {
        if (mtlLegsList.Count == mtlBodyList.Count && mtlLegsList.Count == mtlArmsList.Count)
        {
            // Set the materials for the armature
            armature.materials = new Material[]
            {
                mtlBodyList[mtlSelectedId],
                mtlArmsList[mtlSelectedId],
                mtlLegsList[mtlSelectedId]
            };
            GetComponent<PlayerStats>().Username = skinNames.ElementAt(mtlSelectedId);
        }
        else
        {
            Debug.LogError("Error while updating skin: Not the same amount of materials in all lists");
        }
    }

    private void NextSkin()
    {
        mtlSelectedId = (mtlSelectedId + 1) % mtlLegsList.Count;
        CheckAndSetSkin();
    }

    private void PreviousSkin()
    {
        mtlSelectedId = (mtlSelectedId - 1 + mtlLegsList.Count) % mtlLegsList.Count;
        CheckAndSetSkin();
    }

    private void CheckAndSetSkin()
    {
        var allPlayers = GameObject.FindGameObjectsWithTag("Player");
        if (allPlayers != null)
        {
            bool foundSkin = false;
            while (!foundSkin)
            {
                foundSkin = true;
                foreach (var player in allPlayers)
                {
                    if (player != this.gameObject)
                    {
                        var otherLobbyPlayer = player.GetComponent<LobbyPlayer>();
                        if (otherLobbyPlayer != null && otherLobbyPlayer.mtlSelectedId == this.mtlSelectedId)
                        {
                            foundSkin = false;
                            mtlSelectedId = (mtlSelectedId + 1) % mtlLegsList.Count;
                            break;
                        }
                    }
                }
            }
        }

        UpdateSkin();
    }

    private void AssignUniqueSkin()
    {
        var allPlayers = GameObject.FindGameObjectsWithTag("Player");
        if (allPlayers != null)
        {
            var usedSkins = new HashSet<int>();
            foreach (var player in allPlayers)
            {
                var otherLobbyPlayer = player.GetComponent<LobbyPlayer>();
                if (otherLobbyPlayer != null)
                {
                    usedSkins.Add(otherLobbyPlayer.mtlSelectedId);
                }
            }

            // Find the first available skin ID
            for (int i = 0; i < mtlLegsList.Count; i++)
            {
                if (!usedSkins.Contains(i))
                {
                    mtlSelectedId = i;
                    break;
                }
            }
        }

        UpdateSkin();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.prev)
        {
            _input.prev = false;
            PreviousSkin();
        }
        if (_input.next)
        {
            _input.next = false;
            NextSkin();
        }
    }
}
