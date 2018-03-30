﻿using System;
using System.Collections.Generic;
using MineNET.Blocks.Data;
using MineNET.Entities.Data;
using MineNET.Events.PlayerEvents;
using MineNET.Inventories.Transactions;
using MineNET.Inventories.Transactions.Action;
using MineNET.Inventories.Transactions.Data;
using MineNET.Items;
using MineNET.Network.Packets;
using MineNET.Network.Packets.Data;
using MineNET.Utils;
using MineNET.Values;
using MineNET.Worlds;
using MineNET.Worlds.Data;

namespace MineNET.Entities.Players
{
    public partial class Player
    {
        internal void PacketHandle(DataPacket pk)
        {
            if (pk is LoginPacket)
            {
                this.LoginPacketHandle((LoginPacket) pk);
            }
            else if (pk is ResourcePackClientResponsePacket)
            {
                this.ResourcePackClientResponsePacketHandle((ResourcePackClientResponsePacket) pk);
            }
            else if (pk is RequestChunkRadiusPacket)
            {
                this.RequestChunkRadiusPacketHandle((RequestChunkRadiusPacket) pk);
            }
            else if (pk is MovePlayerPacket)
            {
                this.MovePlayerPacketHandle((MovePlayerPacket) pk);
            }
            else if (pk is TextPacket)
            {
                this.TextPacketHandle((TextPacket) pk);
            }
            else if (pk is CommandRequestPacket)
            {
                this.CommandRequestPacketHandle((CommandRequestPacket) pk);
            }
            else if (pk is InventoryTransactionPacket)
            {
                this.InventoryTransactionHandle((InventoryTransactionPacket) pk);
            }
        }

        private void LoginPacketHandle(LoginPacket pk)
        {
            if (this.IsPreLogined)
            {
                return;
            }

            if (pk.Protocol < ProtocolInfo.CLIENT_PROTOCOL)
            {
                this.SendPlayStatus(PlayStatusPacket.LOGIN_FAILED_CLIENT);
                this.Close("disconnectionScreen.outdatedClient");
                return;
            }
            else if (pk.Protocol > ProtocolInfo.CLIENT_PROTOCOL)
            {
                this.SendPlayStatus(PlayStatusPacket.LOGIN_FAILED_SERVER);
                this.Close("disconnectionScreen.outdatedServer");
                return;
            }

            this.LoginData = pk.LoginData;
            this.Name = pk.LoginData.DisplayName;
            this.DisplayName = this.Name;

            this.ClientData = pk.ClientData;
            this.Skin = this.ClientData.Skin;

            Player[] players = Server.Instance.GetPlayers();
            for (int i = 0; i < players.Length; ++i)
            {
                if (players[i].GetHashCode() != this.GetHashCode())
                {
                    if (players[i].Name == this.Name)
                    {
                        this.Close("disconnectionScreen.loggedinOtherLocation");
                    }
                }
            }

            PlayerPreLoginEventArgs playerPreLoginEvent = new PlayerPreLoginEventArgs(this, "");
            PlayerEvents.OnPlayerPreLogin(playerPreLoginEvent);
            if (playerPreLoginEvent.IsCancel)
            {
                this.Close(playerPreLoginEvent.KickMessage);
                return;
            }

            this.IsPreLogined = true;

            this.SendPlayStatus(PlayStatusPacket.LOGIN_SUCCESS);

            ResourcePacksInfoPacket resourcePacksInfoPacket = new ResourcePacksInfoPacket();
            this.SendPacket(resourcePacksInfoPacket);
        }

        private void ResourcePackClientResponsePacketHandle(ResourcePackClientResponsePacket pk)
        {
            if (this.PackSyncCompleted)
            {
                return;
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_REFUSED)
            {
                this.Close("disconnectionScreen.resourcePackn");
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_SEND_PACKS)
            {
                //TODO: ResourcePackDataInfoPacket
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_HAVE_ALL_PACKS)
            {
                ResourcePackStackPacket resourcePackStackPacket = new ResourcePackStackPacket();
                this.SendPacket(resourcePackStackPacket);

                this.HaveAllPacks = true;
            }
            else if (pk.ResponseStatus == ResourcePackClientResponsePacket.STATUS_COMPLETED && this.HaveAllPacks)
            {
                this.PackSyncCompleted = true;

                if (this.IsLogined)
                {
                    return;
                }
                PlayerLoginEventArgs playerLoginEvent = new PlayerLoginEventArgs(this, "");
                PlayerEvents.OnPlayerLogin(playerLoginEvent);
                if (playerLoginEvent.IsCancel)
                {
                    this.Close(playerLoginEvent.KickMessage);
                    return;
                }

                this.IsLogined = true;

                //if (World.Exists(worldName))
                //{
                //    this.World = World.GetWorld(worldName);
                //}
                //else
                //{
                this.World = World.GetMainWorld();
                //}

                this.LoadData();

                if (this.X == 0 && this.Y == 0 && this.Z == 0)
                {
                    this.X = this.World.SpawnPoint.FloorX;
                    this.Y = this.World.SpawnPoint.FloorY;
                    this.Z = this.World.SpawnPoint.FloorZ;
                }

                StartGamePacket startGamePacket = new StartGamePacket();
                startGamePacket.EntityUniqueId = this.EntityID;
                startGamePacket.EntityRuntimeId = this.EntityID;
                startGamePacket.PlayerGamemode = this.GameMode;
                startGamePacket.PlayerPosition = new Vector3(this.X, this.Y, this.Z);
                startGamePacket.Direction = new Vector2(this.Yaw, this.Pitch);
                startGamePacket.WorldGamemode = this.World.DefaultGameMode.GameModeToInt();
                startGamePacket.Difficulty = this.World.Difficulty;
                startGamePacket.SpawnX = this.World.SpawnPoint.FloorX;
                startGamePacket.SpawnY = this.World.SpawnPoint.FloorY;
                startGamePacket.SpawnZ = this.World.SpawnPoint.FloorZ;
                startGamePacket.WorldName = this.World.Name;
                this.SendPacket(startGamePacket);

                this.SendPlayerAttribute();

                AvailableCommandsPacket availableCommandsPacket = new AvailableCommandsPacket();
                availableCommandsPacket.commands = Server.Instance.CommandManager.CommandList;
                this.SendPacket(availableCommandsPacket);

                this.Inventory.SendContents();
                this.Inventory.ArmorInventory.SendContents();
                this.Inventory.SendCreativeItems();
                this.Inventory.SendMainHand(this);

                PlayerJoinEventArgs playerJoinEvent = new PlayerJoinEventArgs(this, $"§e{this.Name} が世界にやってきました", "");
                PlayerEvents.OnPlayerJoin(playerJoinEvent);
                if (playerJoinEvent.IsCancel)
                {
                    this.Close(playerJoinEvent.KickMessage);
                    return;
                }
                if (!string.IsNullOrEmpty(playerJoinEvent.JoinMessage))
                {
                    Server.Instance.BroadcastMessage(playerJoinEvent.JoinMessage);
                }
                Logger.Info($"§e{this.Name} join the game");

                this.SendPlayStatus(PlayStatusPacket.PLAYER_SPAWN);

                this.HasSpawned = true;

                GameRules rules = new GameRules();
                rules.Add(new GameRule<bool>("ShowCoordinates", true));

                GameRulesChangedPacket gameRulesChangedPacket = new GameRulesChangedPacket();
                gameRulesChangedPacket.GameRules = rules;
                this.SendPacket(gameRulesChangedPacket);

                PlayerListEntry entry = new PlayerListEntry(this.LoginData.ClientUUID, this.EntityID, this.Name, this.ClientData.DeviceOS, this.ClientData.Skin, this.LoginData.XUID);
                AdventureSettingsEntry adventureSettingsEntry = new AdventureSettingsEntry();
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.WORLD_IMMUTABLE, false);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.NO_PVP, false);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.AUTO_JUMP, false);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.ALLOW_FLIGHT, true);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.NO_CLIP, false);
                adventureSettingsEntry.SetFlag(AdventureSettingsPacket.FLYING, false);
                adventureSettingsEntry.EntityUniqueId = this.EntityID;
                Server.Instance.AddPlayer(this, entry, adventureSettingsEntry);

                this.SendDataProperties();
            }
        }

        private void RequestChunkRadiusPacketHandle(RequestChunkRadiusPacket pk)
        {
            int chunkSize = this.FixRadius(pk.Radius);
            ChunkRadiusUpdatedPacket chunkRadiusUpdatedPacket = new ChunkRadiusUpdatedPacket();
            chunkRadiusUpdatedPacket.Radius = chunkSize;
            this.RequestChunkRadius = chunkSize;
            //Logger.Info("%server_chunkRadius", pk.Radius, chunkRadiusUpdatedPacket.Radius);
            SendPacket(chunkRadiusUpdatedPacket);
        }

        private void MovePlayerPacketHandle(MovePlayerPacket pk)
        {
            //TODO: MoveCheck...
            Vector3 pos = pk.Pos;
            Vector3 direction = pk.Direction;
            this.X = pos.X;
            this.Y = pos.Y;
            this.Z = pos.Z;
            this.Pitch = direction.X;
            this.Yaw = direction.Y;
        }

        private void TextPacketHandle(TextPacket pk)
        {
            if (pk.Type == TextPacket.TYPE_CHAT)
            {
                string message = pk.Message.Trim();
                if (message != "" && message.Length < 256)
                {
                    PlayerChatEventArgs playerChatEvent = new PlayerChatEventArgs(this, message);
                    PlayerEvents.OnPlayerChat(playerChatEvent);
                    if (playerChatEvent.IsCancel)
                    {
                        return;
                    }
                    message = $"<{this.Name}§f> {playerChatEvent.Message}§f";
                    Server.Instance.BroadcastChat(message);
                }
            }
        }

        private void CommandRequestPacketHandle(CommandRequestPacket pk)
        {
            string command = pk.Command.Remove(0, 1);
            Server.Instance.CommandManager.HandlePlayerCommand(this, command);
        }

        private void InventoryTransactionHandle(InventoryTransactionPacket pk)
        {
            List<InventoryAction> actions = new List<InventoryAction>();
            for (int i = 0; i < pk.Actions.Length; ++i)
            {
                try
                {
                    InventoryAction action = pk.Actions[i].GetInventoryAction(this);
                    actions.Add(action);
                }
                catch (Exception e)
                {
                    Logger.Log($"Unhandled inventory action from {this.Name}: {e.Message}");
                    this.SendAllInventories();
                    return;
                }
            }

            if (pk.TransactionType == InventoryTransactionPacket.TYPE_NORMAL)
            {
                InventoryTransaction transaction = new InventoryTransaction(this, actions);
                if (this.IsSpectator)
                {
                    this.SendAllInventories();
                    return;
                }
                if (!transaction.Execute())
                {
                    Logger.Log($"Failed to execute inventory transaction from {this.Name} with actions");
                }
            }
            else if (pk.TransactionType == InventoryTransactionPacket.TYPE_MISMATCH)
            {
                this.SendAllInventories();
                return;
            }
            else if (pk.TransactionType == InventoryTransactionPacket.TYPE_USE_ITEM)
            {
                UseItemData data = (UseItemData) pk.TransactionData;
                Vector3 blockPos = data.BlockPos.Vector3;
                BlockFace face = data.Face;
                if (data.ActionType == InventoryTransactionPacket.USE_ITEM_ACTION_CLICK_BLOCK)
                {
                    this.SetFlag(Entity.DATA_FLAGS, Entity.DATA_FLAG_ACTION, false, true);
                    if (this.CanInteract(blockPos + new Vector3(0.5f, 0.5f, 0.5f), this.IsCreative ? 13 : 7))
                    {
                        Item item = this.Inventory.MainHandItem;
                        this.World.UseItem(blockPos, item, face, data.ClickPos, this);
                    }

                    //Send MainHand

                }
                else if (data.ActionType == InventoryTransactionPacket.USE_ITEM_ACTION_BREAK_BLOCK)
                {
                    Item item = this.Inventory.MainHandItem;
                    if (this.CanInteract(blockPos + new Vector3(0.5f, 0.5f, 0.5f), this.IsCreative ? 13 : 7))
                    {
                        this.World.UseBreak(data.BlockPos.Vector3, item, this);
                        if (this.IsSurvival)
                        {
                            //TODO : food
                            this.Inventory.SendMainHand();
                        }
                    }
                    else
                    {
                        this.World.SendBlocks(new Player[] { this }, new Vector3[] { data.BlockPos.Vector3 });
                    }
                }
            }
            else if (pk.TransactionType == InventoryTransactionPacket.TYPE_USE_ITEM_ON_ENTITY)
            {

            }
            else if (pk.TransactionType == InventoryTransactionPacket.TYPE_RELEASE_ITEM)
            {

            }
        }
    }
}
