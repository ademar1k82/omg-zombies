﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using OMG_Zombies.Scripts.Managers;

namespace OMG_Zombies.Scripts.Sprites
{
    /// <summary>
    /// Representa uma poção que é coletada durante o jogo
    /// </summary>
    public class Potion
    {
        #region Campos e propriedades

        // textura
        private Texture2D texture;

        // som
        private SoundEffect collectedSound;

        // nível atual
        private Level level;
        public Level Level
        {
            get => level;
        }

        // posição da poção
        private Vector2 position;

        // Gets the current position of this gem in world space
        // Position in world space of the bottom center of this gem
        // obtém o retângulo colisor da poção
        private Rectangle collider;
        public Rectangle Collider
        {
            set => collider = value;
            get
            {
                int left = collider.X;
                int top = collider.Y;
                int right = collider.Width;
                int bottom = collider.Height;

                return new Rectangle(left, top, right, bottom);
            }
        }

        #endregion


        #region Carregar

        /// <summary>
        /// Controis uma nova poção
        /// </summary>
        public Potion(Level level, Rectangle collider, string filename)
        {
            this.level = level;
            this.collider = collider;
            position = new Vector2(collider.X, collider.Y);

            LoadContent(filename);
        }

        /// <summary>
        /// Carrega o conteúdo para a poção
        /// </summary>
        public void LoadContent(string filename)
        {
            texture = Game1._content.Load<Texture2D>("Tiles/" + filename);
            collectedSound = Game1._content.Load<SoundEffect>("Sounds/collectpotion");
        }

        /// <summary>
        /// Toca o som, quando a poção é coletada
        /// </summary>
        public void OnPotionCollected()
        {
            collectedSound.Play();
        }

        #endregion


        #region Desenhar

        /// <summary>
        /// Desenhar a poção
        /// </summary>
        public void Draw()
        {
            Game1._spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        #endregion
    }
}