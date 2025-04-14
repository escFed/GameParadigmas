using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Tao.Sdl;



namespace MyGame
{

    class Program
    {
        static Image fondo = Engine.LoadImage("assets/fondo.png");
        static Image player = Engine.LoadImage("assets/player.png");


        
        static void Main(string[] args)
        {
            Engine.Initialize();

            while (true)
            {
                Input();
                Update();
                Render();
            }
        }

        static void Input()
        {

        }

        static void Update()
        {
   

        }

        static void Render()
        {
            Engine.Clear();
            Engine.Draw(fondo, 0, 0);
            Engine.Draw(player, posX, 0);
            Engine.Show();
            
        }
    }
}