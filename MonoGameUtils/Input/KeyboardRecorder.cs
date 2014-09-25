using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameUtils.Input
{

    /* TODO So what I want is:
     * * The ability to, when a certain condition happens (focus gained, etc), start
     *   recording any keypresses into a string.
     * * I also need to be able to stop this recording.
     */
    /// <summary>
    /// Records input from the Keyboard.
    /// </summary>
    public class KeyboardRecorder
        : GameComponent
    {
        /// <summary>
        /// Whether or not this <c>KeyboardRecorder</c> is currently recording keyboard input.
        /// </summary>
        private bool Recording;

        private string RecordedText;

        private List<Keys> previouslyPressedKeys;

        public KeyboardRecorder(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            this.Recording = false;
            this.previouslyPressedKeys = new List<Keys>();
 	        base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (this.Recording)
            {
                foreach (Keys key in Keyboard.GetState().GetPressedKeys())
                {
                    if (!this.previouslyPressedKeys.Contains(key))
                    {
                        // TODO Would be interesting to bundle this functionality into a Keys.ToHumanFriendlyString()
                        //      extension method in MonoGameUtils.
                        switch (key)
                        {
                            case Keys.D0: this.RecordedText += "0"; break;
                            case Keys.D1: this.RecordedText += "1"; break;
                            case Keys.D2: this.RecordedText += "2"; break;
                            case Keys.D3: this.RecordedText += "3"; break;
                            case Keys.D4: this.RecordedText += "4"; break;
                            case Keys.D5: this.RecordedText += "5"; break;
                            case Keys.D6: this.RecordedText += "6"; break;
                            case Keys.D7: this.RecordedText += "7"; break;
                            case Keys.D8: this.RecordedText += "8"; break;
                            case Keys.D9: this.RecordedText += "9"; break;
                            default: this.RecordedText += key.ToString(); break;
                        }
                    }
                }

                this.previouslyPressedKeys = Keyboard.GetState().GetPressedKeys().ToList<Keys>();
            }

            base.Update(gameTime);
        }

        public void StartRecording()
        {
            this.Recording = true;
        }

        public void StopRecording()
        {
            this.Recording = false;
        }

        public string GetRecordedText()
        {
            return this.RecordedText;
        }

        public void ClearRecordedText()
        {
            this.RecordedText = String.Empty;
        }
    }
}
