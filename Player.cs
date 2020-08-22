using SplashKitSDK;
using System;
public class Player
{

    private Bitmap _PlayerBitmap;//  image file format used to store digital images.
    private Window _gameWindow;


    public double X { get; private set; }// Width cooedinate
    public double Y { get; private set; }//Height cooedinate
    public Boolean Quit { get; private set; }//Existing game window



    public int Width
    {
        get { return _PlayerBitmap.Width; }
    }

    public int Height
    {
        get { return _PlayerBitmap.Height; }
    }


    public Player(Window gameWindow)//constructor
    {
        _gameWindow = gameWindow;

        Bitmap playerBitmap = new Bitmap("Player", "Player.png");
        _PlayerBitmap = playerBitmap;

        //sets auto properties value
        X = (gameWindow.Width - Width) / 2;

        Y = (gameWindow.Height - Height) / 2;
        // Console.WriteLine(System.Convert.ToString(X) + "khizar" + System.Convert.ToString(Height) + "khizar" + System.Convert.ToString(Width) + "khizar" + System.Convert.ToString(gameWindow.Width) + "khizar" + System.Convert.ToString(gameWindow.Height) + "khizar");
        //SplashKit class DrawBitmap Method to draw the bitmap to the screen
        //gets auto properties value

    }
    public void Draw()
    {
        _PlayerBitmap.Draw(X, Y);
    }

    public void HandleInput()
    {
        int speed = 5;
        Quit = false;


        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            _gameWindow.Clear(Color.White);
            //by clicking 
            Y += -speed;
            _PlayerBitmap.Draw(X, Y);// Draw character at the place after calculation 

            StayOnWindow();

        }

        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            _gameWindow.Clear(Color.Black);
            Y += speed;
            _PlayerBitmap.Draw(X, Y);
            StayOnWindow();
        }

        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            _gameWindow.Clear(Color.White);
            X += -speed;
            _PlayerBitmap.Draw(X, Y);
            StayOnWindow();
        }

        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            _gameWindow.Clear(Color.White);
            X += speed;
            _PlayerBitmap.Draw(X, Y);
            StayOnWindow();
        }

        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            Quit = true;
            _gameWindow.Close();

        }

        // SplashKit.ProcessEvents();
    }

    public void StayOnWindow()
    {
        //will not change no matter what value is assigned to it in the other statements?
        const int GAP = 10;

        //Left Side Buffer
        //if X is less than 10, make X 10. wont go below that
        //so that the left side(starting point) of the bitmap will never reach 0, always a min of 10
        if (X < GAP)
        {
            X = GAP;
        }
        if (Y < GAP)
        {
            Y = GAP;
        }
        //Right Side Buffer
        //problem is the right side of the bitmap is not the starting point of it at location
        //if X is greater than the Window Width(dont go past window width) - Width of the BITMAP(so that it counts the right side of it not the left) - GAP(10 to add a small buffer)
        //if width is not subtracted the left side(starting) point will be on the buffer of 10px so the BItmap will be 10px inside, the rest out of window
        //no GAP here makes it bounce since it checks if the  window is at the edge, it allows the BITMAP to reach the edge
        //then changes the X to have a 10px buffer. Picture would vibrate at the edge
        if (X > _gameWindow.Width - Width - GAP)
        {
            X = _gameWindow.Width - Width - GAP;
        }
        if (Y > _gameWindow.Height - Height - GAP)
        {
            Y = _gameWindow.Height - Height - GAP;
        }
    }
    public bool CollidedWith(Robot other)
    {
        return _PlayerBitmap.CircleCollision(X, Y, other.CollissionCircle);

    }
}

