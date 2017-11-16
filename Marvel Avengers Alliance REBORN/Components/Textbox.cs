using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Marvel_Avengers_Alliance_REBORN.Models;
using Marvel_Avengers_Alliance_REBORN;

namespace MarvMarvel_Avengers_Alliance_REBORN.Models
{
    class Textbox
    {
        #region Field
        protected Texture2D textboxTexture;
        protected Texture2D cursor;
        protected SpriteFont Calibri;
        protected SpriteBatch spriteBatch;
        protected string text;
        protected Keys[] keysToCheck = new Keys[] { Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I,
            Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V,
            Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.Back, Keys.Space };
        protected Vector2 cursorPosition;
        protected Vector2 textPosition;
        protected Vector2 textboxPosition;
        protected TimeSpan blinkTime; bool blink;
        protected KeyboardState currentKeyboardState;
        protected KeyboardState lastKeyboardState;
        #endregion

        public Textbox(ContentManager content, string component_name)
        {
            Calibri = content.Load<SpriteFont>("Fonts/BigConso");
            textboxTexture = content.Load<Texture2D>("Component/textbox");
            cursor = content.Load<Texture2D>("Component/text_cursor");
            textboxPosition = new Vector2((MAAGame.SCREEN_WIDTH / 2) - (textboxTexture.Width / 2), 20);
            cursorPosition = new Vector2(textboxPosition.X + 50, textboxPosition.Y + 49);
            textPosition = new Vector2(textboxPosition.X + 50, textboxPosition.Y + 45);
            blink = false;
            text = "";
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public Vector2 Position
        {
            get { return textboxPosition; }
            set { textboxPosition = value; SetTextPosition(); }
        }

        private void SetTextPosition()
        {
            cursorPosition = new Vector2(textboxPosition.X + 5, textboxPosition.Y + 5);
            textPosition = new Vector2(textboxPosition.X + 5, textboxPosition.Y + 5);
        }

        public int Height
        {
            get { return textboxTexture.Height; }
        }

        public int Width
        {
            get { return textboxTexture.Width; }
        }

        public void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();
            blinkTime += gameTime.ElapsedGameTime;
            if (blinkTime > TimeSpan.FromMilliseconds(500))
            {
                blink = !blink;
                blinkTime -= TimeSpan.FromMilliseconds(500);
            }
            foreach (Keys key in keysToCheck)
            {
                if (CheckKey(key))
                {
                    AddKeyToText(key);
                    break;
                }
            }
            Vector2 textSize = Calibri.MeasureString(text);
            cursorPosition.X = textPosition.X + textSize.X - 10;
            lastKeyboardState = currentKeyboardState;
        }

        private void AddKeyToText(Keys key)
        {
            string newChar = ""; if (text.Length >= 12 && key != Keys.Back) return; switch (key)
            {
                case Keys.A: newChar += "a"; break;
                case Keys.B: newChar += "b"; break;
                case Keys.C: newChar += "c"; break;
                case Keys.D: newChar += "d"; break;
                case Keys.E: newChar += "e"; break;
                case Keys.F: newChar += "f"; break;
                case Keys.G: newChar += "g"; break;
                case Keys.H: newChar += "h"; break;
                case Keys.I: newChar += "i"; break;
                case Keys.J: newChar += "j"; break;
                case Keys.K: newChar += "k"; break;
                case Keys.L: newChar += "l"; break;
                case Keys.M: newChar += "m"; break;
                case Keys.N: newChar += "n"; break;
                case Keys.O: newChar += "o"; break;
                case Keys.P: newChar += "p"; break;
                case Keys.Q: newChar += "q"; break;
                case Keys.R: newChar += "r"; break;
                case Keys.S: newChar += "s"; break;
                case Keys.T: newChar += "t"; break;
                case Keys.U: newChar += "u"; break;
                case Keys.V: newChar += "v"; break;
                case Keys.W: newChar += "w"; break;
                case Keys.X: newChar += "x"; break;
                case Keys.Y: newChar += "y"; break;
                case Keys.Z: newChar += "z"; break;
                case Keys.Space: newChar += " "; break;
                case Keys.Back: if (text.Length != 0) text = text.Remove(text.Length - 1); return;
            }
            if (currentKeyboardState.IsKeyDown(Keys.RightShift) || currentKeyboardState.IsKeyDown(Keys.LeftShift))
            {
                newChar = newChar.ToUpper();
            }
            text += newChar;
        }

        private bool CheckKey(Keys theKey)
        {
            return lastKeyboardState.IsKeyDown(theKey) && currentKeyboardState.IsKeyUp(theKey);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textboxTexture, textboxPosition, Color.White);
            if (!blink) spriteBatch.Draw(cursor, cursorPosition, Color.White);
            spriteBatch.DrawString(Calibri, text, textPosition, Color.White);
        }

        public void LoadContent(ContentManager content, string asset)
        {
            throw new NotImplementedException();
        }
    }
}
