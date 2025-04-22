using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Tao.Sdl;



namespace MyGame
{
    class Program
    {       
        static void Main(string[] args)
        {
            Engine.Initialize(); // Initialize the game engine

            Time.Initialize(); // Initialize the Time class

            GameManager.Instance.Initialize(); // Initialize the GameManager

            while (true)
            {
                Time.Update(); // Update the time

                GameManager.Instance.Update(); // Update the game manager
                GameManager.Instance.Render(); // Render the game manager
            }
        }
    }
}