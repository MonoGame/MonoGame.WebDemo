using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Threading.Tasks;

namespace Platformer2D
{
    static class GameContent
    {
        public static bool IsBaseLoaded { get; set; }
        public static bool IsLoaded { get; set; }
        public static int Counter;

        public static async Task Init(ContentManager content, GraphicsDevice graphics)
        {
            Counter = 0;
            Texture.Pixel = await Texture2D.FromURL(graphics, "Content/Pixel.png");
            Font.hudFont = content.Load<SpriteFont>("Fonts/Hud");
            IsBaseLoaded = true;

            Texture.winOverlay = await Texture2D.FromURL(graphics, "Content/Overlays/you_win.png"); Counter++;
            Texture.loseOverlay = await Texture2D.FromURL(graphics, "Content/Overlays/you_lose.png"); Counter++;
            Texture.diedOverlay = await Texture2D.FromURL(graphics, "Content/Overlays/you_died.png"); Counter++;
            Texture.VirtualControlArrow = await Texture2D.FromURL(graphics, "Content/Sprites/VirtualControlArrow.png"); Counter++;
            Texture.Idle = await Texture2D.FromURL(graphics, "Content/Sprites/Player/Idle.png"); Counter++;
            Texture.Run = await Texture2D.FromURL(graphics, "Content/Sprites/Player/Run.png"); Counter++;
            Texture.Jump = await Texture2D.FromURL(graphics, "Content/Sprites/Player/Jump.png"); Counter++;
            Texture.Celebrate = await Texture2D.FromURL(graphics, "Content/Sprites/Player/Celebrate.png"); Counter++;
            Texture.Die = await Texture2D.FromURL(graphics, "Content/Sprites/Player/Die.png"); Counter++;
            Texture.Gem = await Texture2D.FromURL(graphics, "Content/Sprites/Gem.png"); Counter++;

            Texture.BackgroundLayer = new Texture2D[3,3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Texture.BackgroundLayer[x, y] = await Texture2D.FromURL(graphics, "Content/Backgrounds/Layer" + x + "_" + y + ".png");
                    Counter++;
                }
            }

            Texture.MonsterIdle = new Texture2D[4];
            Texture.MonsterRun = new Texture2D[4];
            for (int i = 0; i < 4; i++)
            {
                Texture.MonsterIdle[i] = await Texture2D.FromURL(graphics, "Content/Sprites/Monster" + i + "/Idle.png"); Counter++;
                Texture.MonsterRun[i] = await Texture2D.FromURL(graphics, "Content/Sprites/Monster" + i + "/Run.png"); Counter++;
            }

            Texture.Tiles = new Dictionary<string, Texture2D>();
            Texture.Tiles["BlockA0"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockA0.png"); Counter++;
            Texture.Tiles["BlockA1"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockA1.png"); Counter++;
            Texture.Tiles["BlockA2"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockA2.png"); Counter++;
            Texture.Tiles["BlockA3"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockA3.png"); Counter++;
            Texture.Tiles["BlockA4"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockA4.png"); Counter++;
            Texture.Tiles["BlockA5"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockA5.png"); Counter++;
            Texture.Tiles["BlockA6"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockA6.png"); Counter++;
            Texture.Tiles["BlockB0"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockB0.png"); Counter++;
            Texture.Tiles["BlockB1"] = await Texture2D.FromURL(graphics, "Content/Tiles/BlockB1.png"); Counter++;
            Texture.Tiles["Exit"] = await Texture2D.FromURL(graphics, "Content/Tiles/Exit.png"); Counter++;
            Texture.Tiles["Platform"] = await Texture2D.FromURL(graphics, "Content/Tiles/Platform.png"); Counter++;

            Songs.Music = await Song.FromURL("Content/Sounds/Music.ogg"); Counter++;

            SoundEffects.killedSound = await SoundEffect.FromURL("Content/Sounds/PlayerKilled.wav"); Counter++;
            SoundEffects.jumpSound = await SoundEffect.FromURL("Content/Sounds/PlayerJump.wav"); Counter++;
            SoundEffects.fallSound = await SoundEffect.FromURL("Content/Sounds/PlayerFall.wav"); Counter++;
            SoundEffects.exitReachedSound = await SoundEffect.FromURL("Content/Sounds/ExitReached.wav"); Counter++;
            SoundEffects.collectedSound = await SoundEffect.FromURL("Content/Sounds/GemCollected.wav"); Counter++;

            Levels = new List<string[]>();
            for (int i = 0; i < 3; i++)
            {
                Levels.Add(System.IO.File.ReadAllLines("Content/Levels/" + i + ".txt"));
                Counter++;
            }

            IsLoaded = true;
        }

        public static class Texture
        {
            public static Texture2D winOverlay;
            public static Texture2D loseOverlay;
            public static Texture2D diedOverlay;
            public static Texture2D Pixel;

            public static Texture2D VirtualControlArrow;
            public static Texture2D Idle;
            public static Texture2D Run;
            public static Texture2D Jump;
            public static Texture2D Celebrate;
            public static Texture2D Die;
            public static Texture2D Gem;

            public static Texture2D[,] BackgroundLayer;
            public static Texture2D[] MonsterRun;
            public static Texture2D[] MonsterIdle;

            public static Dictionary<string, Texture2D> Tiles;
        }

        public static class Songs
        {
            public static Song Music;
        }

        public static class SoundEffects
        {
            public static SoundEffect killedSound;
            public static SoundEffect jumpSound;
            public static SoundEffect fallSound;

            public static SoundEffect exitReachedSound;
            public static SoundEffect collectedSound;
        }

        public static class Font
        {
            public static SpriteFont hudFont;
        }

        public static List<string[]> Levels;
    }
}
