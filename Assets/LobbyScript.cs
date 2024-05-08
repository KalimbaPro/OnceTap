using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public Lobby hostLobby;
    public Lobby joinedLobby;

    public string playerName;

    private float lobbyUpdateTimer;

    private static LobbyScript _instance;

    public static LobbyScript Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        StartCoroutine(HandleLobbyHeartbeatCoroutine());
    }

    private void Update()
    {
        HandleLobbyPollForUpdates();
    }

    private IEnumerator HandleLobbyHeartbeatCoroutine()
    {
        if (hostLobby != null)
        {
            LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
        }
        yield return new WaitForSeconds(15);
        StartCoroutine(HandleLobbyHeartbeatCoroutine());
    }

    private async void HandleLobbyPollForUpdates()
    {
        if (joinedLobby != null)
        {
            lobbyUpdateTimer -= Time.deltaTime;
            if (lobbyUpdateTimer < 0)
            {
                float lobbyUpdateTimerMax = 1.1f;
                lobbyUpdateTimer = lobbyUpdateTimerMax;

                joinedLobby = await LobbyService.Instance.GetLobbyAsync(joinedLobby.Id);

                string relayCode = joinedLobby.Data["StartGameCode"].Value;
                if (relayCode != "0")
                {
                    RelayScript.Instance.JoinRelay(relayCode);
                }
            }
        }
    }

    public async void CreateLobby(string playerName, bool isPrivate = false, string lobbyName = "Lobby")
    {
        try
        {
            if (lobbyName == "")
                lobbyName = "Lobby" + Random.Range(1, 10000);
            if (playerName == "")
                playerName = "Player" + Random.Range(1, 10000);

            this.playerName = playerName;
            CreateLobbyOptions options = new CreateLobbyOptions
            {
                IsPrivate = isPrivate,
                Player = GetNewPlayer(playerName),
                Data = new Dictionary<string, DataObject>
                {
                    {"GameMode", new(DataObject.VisibilityOptions.Public, "Deathmatch") },
                    {"Map", new(DataObject.VisibilityOptions.Public, "Playground") },
                    {"StartGameCode", new(DataObject.VisibilityOptions.Member, "0") }
                }
            };
            hostLobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, RelayScript.Instance.maxPlayers, options);
            joinedLobby = hostLobby;

            Debug.Log("Lobby created " + hostLobby.LobbyCode);
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    private async void ListLobbies()
    {
        try
        {
            QueryLobbiesOptions options = new QueryLobbiesOptions
            {
                Count = 10,
                Filters = new List<QueryFilter>
                {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT)
                },
                Order = new List<QueryOrder>
                {
                    new QueryOrder(false, QueryOrder.FieldOptions.Created),
                }
            };

            QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(options);
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    public async void JoinLobbyByCode(string code, string playerName)
    {
        try
        {
            if (playerName == "")
                playerName = "Player" + Random.Range(1, 10000);

            this.playerName = playerName;
            JoinLobbyByCodeOptions options = new JoinLobbyByCodeOptions
            {
                Player = GetNewPlayer(playerName),
            };
            joinedLobby = await Lobbies.Instance.JoinLobbyByCodeAsync(code, options);

            Debug.Log("Lobby joined");
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    private Player GetNewPlayer(string playerName)
    {
        return new Player
        {
            Data = new Dictionary<string, PlayerDataObject>
                    {
                        {"PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) }
                    }
        };
    }

    private void PrintPlayers(Lobby lobby)
    {
        foreach (Player player in lobby.Players) {
            Debug.Log(player.Id + " " + player.Data["PlayerName"]);
        }
    }

    private async void UpdateLobbyGamemode(string gamemode)
    {
        try
        {
            hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
            {
                Data = new Dictionary<string, DataObject>
                {
                    {"GameMode", new DataObject(DataObject.VisibilityOptions.Public, gamemode)},
                }
            });
            joinedLobby = hostLobby;
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    private async void UpdateLobbyMap(string map)
    {
        try
        {
            hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
            {
                Data = new Dictionary<string, DataObject>
                {
                    {"Map", new DataObject(DataObject.VisibilityOptions.Public, map)},
                }
            });
            joinedLobby = hostLobby;
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    private async void UpdatePlayerName(string playerName)
    {
        try
        {
            this.playerName = playerName;
            await LobbyService.Instance.UpdatePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId, new UpdatePlayerOptions
            {
                Data = new Dictionary<string, PlayerDataObject>
                {
                    {"PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, name)},
                }
            });
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    public async void LeaveLobby()
    {
        try
        {
            await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId);
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    public async void KickPlayer(string playerId)
    {
        try
        {
            await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, playerId);
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    public async void SetNewHost(string playerId)
    {
        try
        {
            hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
            {
                HostId = playerId
            });
            joinedLobby = hostLobby;
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    public async void StartGame()
    {
        try
        {
            string relayCode = await RelayScript.Instance.CreateRelay();

            joinedLobby = await Lobbies.Instance.UpdateLobbyAsync(joinedLobby.Id, new UpdateLobbyOptions
            {
                Data = new Dictionary<string, DataObject>
                {
                    {"StartGameCode", new(DataObject.VisibilityOptions.Member, relayCode) }
                }
            });
        }
        catch (LobbyServiceException ex)
        {
            Debug.Log(ex);
        }
    }
}
