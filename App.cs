using Bridge;
using System;
using System.IO;
using static Retyped.dom;
using Console = System.Console;
using Microsoft.Xna.Framework;

namespace Platformer2D
{
    public class App
    {
		private static Game game;
		
        public static void Main()
		{
            var button = new HTMLButtonElement();
            button.innerHTML = "Run Game";
			document.body.appendChild(button);

			var brelem = new HTMLBRElement();
			document.body.appendChild(brelem);

			var canvas = new HTMLCanvasElement();
			canvas.width = 800;
			canvas.height = 480;
			canvas.id = "monogamecanvas";
			document.body.appendChild(canvas);

            button.onclick = (ev) =>
            {
				game = new PlatformerGame();
				game.Run();

				document.body.removeChild(brelem);
				document.body.removeChild(button);
			};
        }
    }
}
