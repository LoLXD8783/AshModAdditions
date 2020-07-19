using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions.Tiles.Warped
{
    public class WarpedSky : CustomSky
    {
        bool isactive;
        public override void Activate(Vector2 position, params object[] args)
        {
            isactive = true;
        }

        public override void Deactivate(params object[] args)
        {
            isactive = false;
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (!(minDepth > 0 && maxDepth < 0)) return;
            //spriteBatch.End();
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.AnisotropicWrap, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.EffectMatrix);
            spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Red);
            //spriteBatch.End();
            //spriteBatch.Begin();
        }

        public override bool IsActive()
        {
            return isactive;
        }

        public override void Reset()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
