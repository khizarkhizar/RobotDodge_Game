using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window gameWindow = new Window("Game", 800, 600);
        Robotdodge robotDodge = new Robotdodge(gameWindow);


        do
        {

            SplashKit.ProcessEvents();
            robotDodge.HandleInput();
            robotDodge.Draw();
            robotDodge.Update();




        } while (!gameWindow.CloseRequested);

        gameWindow.Close();

    }
}



