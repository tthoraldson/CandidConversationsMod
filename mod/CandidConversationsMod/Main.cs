using System;
using ContentPatcher;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace CandidConversationsMod
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        private IContentPatcherAPI contentPatcherAPI;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Monitor.Log("We're just getting started~");
            // this.textInput = this.Helper.Content.Load<TextInput>("assets/data.json").GetTextInputHelper();
            this.Helper.Events.GameLoop.GameLaunched += this.onGameLaunched;
            this.Helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            this.Helper.Events.World.NpcListChanged += this.npcStuff;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void onGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            contentPatcherAPI = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
            this.Monitor.Log("Patcher status: " + contentPatcherAPI.IsConditionsApiReady.ToString());

        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            this.Monitor.Log("Button Pressed!!");
            this.Monitor.Log("Patcher status: " +contentPatcherAPI.IsConditionsApiReady.ToString());
        }

        private void npcStuff(object sender, NpcListChangedEventArgs e)
        {
            this.Monitor.Log("Inside of npcStuff!!");
            this.Monitor.Log(e.GetType().ToString());
        }
    }
}

