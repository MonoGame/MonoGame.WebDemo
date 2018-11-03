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
            Texture.Pixel = await content.LoadAsync<Texture2D>("Pixel");
            Font.hudFont = await content.LoadAsync<SpriteFont>("Fonts/Hud");
            IsBaseLoaded = true;

            Texture.winOverlay = await content.LoadAsync<Texture2D>("Overlays/you_win"); Counter++;
            Texture.loseOverlay = await content.LoadAsync<Texture2D>("Overlays/you_lose"); Counter++;
            Texture.diedOverlay = await content.LoadAsync<Texture2D>("Overlays/you_died"); Counter++;
            Texture.VirtualControlArrow = await content.LoadAsync<Texture2D>("Sprites/VirtualControlArrow"); Counter++;
            Texture.Idle = await content.LoadAsync<Texture2D>("Sprites/Player/Idle"); Counter++;
            Texture.Run = await content.LoadAsync<Texture2D>("Sprites/Player/Run"); Counter++;
            Texture.Jump = await content.LoadAsync<Texture2D>("Sprites/Player/Jump"); Counter++;
            Texture.Celebrate = await content.LoadAsync<Texture2D>("Sprites/Player/Celebrate"); Counter++;
            Texture.Die = await content.LoadAsync<Texture2D>("Sprites/Player/Die"); Counter++;
            Texture.Gem = await content.LoadAsync<Texture2D>("Sprites/Gem"); Counter++;

            Texture.BackgroundLayer = new Texture2D[3,3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Texture.BackgroundLayer[x, y] = await content.LoadAsync<Texture2D>("Backgrounds/Layer" + x + "_" + y);
                    Counter++;
                }
            }

            Texture.MonsterIdle = new Texture2D[4];
            Texture.MonsterRun = new Texture2D[4];
            for (int i = 0; i < 4; i++)
            {
                Texture.MonsterIdle[i] = await content.LoadAsync<Texture2D>("Sprites/Monster" + i + "/Idle"); Counter++;
                Texture.MonsterRun[i] = await content.LoadAsync<Texture2D>("Sprites/Monster" + i + "/Run"); Counter++;
            }

            Texture.Tiles = new Dictionary<string, Texture2D>();
            Texture.Tiles["BlockA0"] = await content.LoadAsync<Texture2D>("Tiles/BlockA0"); Counter++;
            Texture.Tiles["BlockA1"] = await content.LoadAsync<Texture2D>("Tiles/BlockA1"); Counter++;
            Texture.Tiles["BlockA2"] = await content.LoadAsync<Texture2D>("Tiles/BlockA2"); Counter++;
            Texture.Tiles["BlockA3"] = await content.LoadAsync<Texture2D>("Tiles/BlockA3"); Counter++;
            Texture.Tiles["BlockA4"] = await content.LoadAsync<Texture2D>("Tiles/BlockA4"); Counter++;
            Texture.Tiles["BlockA5"] = await content.LoadAsync<Texture2D>("Tiles/BlockA5"); Counter++;
            Texture.Tiles["BlockA6"] = await content.LoadAsync<Texture2D>("Tiles/BlockA6"); Counter++;
            Texture.Tiles["BlockB0"] = await content.LoadAsync<Texture2D>("Tiles/BlockB0"); Counter++;
            Texture.Tiles["BlockB1"] = await content.LoadAsync<Texture2D>("Tiles/BlockB1"); Counter++;
            Texture.Tiles["Exit"] = await content.LoadAsync<Texture2D>("Tiles/Exit"); Counter++;
            Texture.Tiles["Platform"] = await content.LoadAsync<Texture2D>("Tiles/Platform"); Counter++;

            Songs.Music = await content.LoadAsync<Song>("Sounds/Music"); Counter++;

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
