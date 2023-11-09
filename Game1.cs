using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DrumPad
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Game World
        SoundEffect kick;
        SoundEffect cymbolTing;
        SoundEffect snare;
        SoundEffect top;
        Song music;
        //SoundEffectInstance musicInstance = null;

        // Capture Gamepad states
        GamePadState pad1;          //holds current state of gamepad
        GamePadState oldpad1;       //holds the state of gamepad during previous update() call.

        GamePadState pad2;
        GamePadState oldpad2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load soundeffects into game
            kick = Content.Load<SoundEffect>("Bassdrum-03");
            cymbolTing = Content.Load<SoundEffect>("Hat Closed");
            snare = Content.Load<SoundEffect>("snaredrum");
            top = Content.Load<SoundEffect>("Crash");

            // Load bg music into game
            music = Content.Load<Song>("moss_boss_bgm");
            
            //musicInstance = music.CreateInstance();
        }

        protected override void Update(GameTime gameTime)
        {

            pad1 = GamePad.GetState(PlayerIndex.One);
            pad2 = GamePad.GetState(PlayerIndex.Two);


            if (pad1.IsConnected)
            {
                // Allow game to exit when the back is pressed.
                if (pad1.Buttons.Back == ButtonState.Pressed)
                {
                    Exit();
                }

                // Test if A has been pressed since the last update().
                if (oldpad1.Buttons.A == ButtonState.Released &&
                    pad1.Buttons.A == ButtonState.Pressed)
                {
                    snare.Play();
                }

                // Test if B has been pressed since the last update().
                if (oldpad1.Buttons.B == ButtonState.Released &&
                    pad1.Buttons.B == ButtonState.Pressed)
                {
                    cymbolTing.Play();
                }

                // Test if X has been pressed since the last update().
                if (oldpad1.Buttons.X == ButtonState.Released &&
                    pad1.Buttons.X == ButtonState.Pressed)
                {
                    kick.Play();
                }

                // Test if Y has been pressed since the last update().
                if (oldpad1.Buttons.Y == ButtonState.Released &&
                    pad1.Buttons.Y == ButtonState.Pressed)
                {
                    top.Play();
                }

                // Test if LeftShoulder has been pressed since the last update().
                if (oldpad1.Buttons.LeftShoulder == ButtonState.Released &&
                    pad1.Buttons.LeftShoulder == ButtonState.Pressed)
                {
                    // Start the music playing
                    if (MediaPlayer.State == MediaState.Paused)
                    {
                        MediaPlayer.Resume();

                    }
                    else
                    {
                        MediaPlayer.Play(music);
                    }
                }

                // Test if RightShoulder has been pressed since the last update().
                if (oldpad1.Buttons.RightShoulder == ButtonState.Released &&
                    pad1.Buttons.RightShoulder == ButtonState.Pressed)
                {
                    // Pause the music
                    if (MediaPlayer.State == MediaState.Playing)
                    {
                        MediaPlayer.Pause();
                    }

                }

                oldpad1 = pad1;     //record state of gamepad for next update() call.
            }


            if (pad2.IsConnected)
            {
                // Allow game to exit when the back is pressed.
                if (pad2.Buttons.Back == ButtonState.Pressed)
                {
                    Exit();
                }

                // Test if A has been pressed since the last update().
                if (oldpad2.Buttons.A == ButtonState.Released &&
                    pad2.Buttons.A == ButtonState.Pressed)
                {
                    snare.Play();
                }

                // Test if B has been pressed since the last update().
                if (oldpad2.Buttons.B == ButtonState.Released &&
                    pad2.Buttons.B == ButtonState.Pressed)
                {
                    cymbolTing.Play();
                }

                // Test if X has been pressed since the last update().
                if (oldpad2.Buttons.X == ButtonState.Released &&
                    pad2.Buttons.X == ButtonState.Pressed)
                {
                    kick.Play();
                }

                // Test if Y has been pressed since the last update().
                if (oldpad2.Buttons.Y == ButtonState.Released &&
                    pad2.Buttons.Y == ButtonState.Pressed)
                {
                    top.Play();
                }

                oldpad2 = pad2;     //record state of gamepad for next update() call.
            }

                    base.Update(gameTime);
              
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}