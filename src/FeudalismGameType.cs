using System;
using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Landsknecht.src
{
    /**
    Providing GameType information and handle initialisation of the game type itself
    Adding Strings and Models here for loading to the CurrentGame

    Mandatory for correct mod loading by the engine
    */
    public class FeudalismGameType : GameType
    {
        public static FeudalismGameType Current => Game.Current.GameType as FeudalismGameType;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Game currentGame = this.CurrentGame;
            currentGame.FirstInitialize();
            IGameStarter gameStarter = new BasicGameStarter();
            this.GameManager.OnGameStart(this.CurrentGame, gameStarter);
            currentGame.SecondInitialize(gameStarter.Models);
            currentGame.CreateGameManager();
            this.GameManager.BeginGameStart(this.CurrentGame);
            this.CurrentGame.RegisterBasicTypes();
            this.CurrentGame.ThirdInitialize();
            currentGame.CreateObjects();
            currentGame.InitializeDefaultGameObjects();
            currentGame.LoadBasicFiles(false);
            this.ObjectManager.ClearEmptyObjects();
            currentGame.SetDefaultEquipments((IReadOnlyDictionary<string, Equipment>)new Dictionary<string, Equipment>());
            currentGame.CreateLists();
            this.ObjectManager.ClearEmptyObjects();
            this.GameManager.OnCampaignStart(this.CurrentGame, (object)null);
            this.GameManager.OnAfterCampaignStart(this.CurrentGame);
            this.GameManager.OnGameInitializationFinished(this.CurrentGame);
        }

        public override void OnDestroy()
        {

        }

        protected override void DoLoadingForGameType(GameTypeLoadingStates gameTypeLoadingState, out GameTypeLoadingStates nextState)
        {
            nextState = GameTypeLoadingStates.None;
            switch (gameTypeLoadingState)
            {
                case GameTypeLoadingStates.InitializeFirstStep:
                    nextState = GameTypeLoadingStates.WaitSecondStep;
                    break;
                case GameTypeLoadingStates.WaitSecondStep:
                    nextState = GameTypeLoadingStates.LoadVisualsThirdState;
                    break;
                case GameTypeLoadingStates.LoadVisualsThirdState:
                    nextState = GameTypeLoadingStates.PostInitializeFourthState;
                    break;
                default:
                    //?
                    break;
            }

        }
    }
}
