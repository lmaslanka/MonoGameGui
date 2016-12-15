namespace MonoGameGui.Toolkit
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Window
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.window, this.Position, Color.White);
            spriteBatch.DrawString(this.font, this.Title, new Vector2(this.Position.X + 10, this.Position.Y + 12), Color.Black);
        }

        public void Update(GameTime gameTime, MouseState mouseState)
        {
            int x = mouseState.X;
            int y = mouseState.Y;

            // Button Single Click
            if (mouseState.LeftButton == ButtonState.Pressed && this.oldMouseState.LeftButton == ButtonState.Released)
            {
            }

            // Button Click and Hold
            if (mouseState.LeftButton == ButtonState.Pressed && this.oldMouseState.LeftButton == ButtonState.Pressed)
            {
                if (x >= this.Position.X && x <= (this.Position.X + this.Width) && y >= this.Position.Y && y <= (this.Position.Y + this.TitleBarHeight))
                {
                    SetPosition(new Vector2(this.Position.X + (mouseState.X - this.oldMouseState.X), this.Position.Y + (mouseState.Y - this.oldMouseState.Y)));
                }
            }

            this.oldMouseState = mouseState;
        }

        public void SetWidth(int width)
        {
            if (width < MinimumWindowWidth)
            {
                throw new WindowInvalidMinimumSizeException(this.MinimumWindowWidthExceptionMessage);
            }

            this.Width = width;
        }

        public void SetHeight(int height)
        {
            if (height < MinimumWindowHeight)
            {
                throw new WindowInvalidMinimumSizeException(this.MinimumWindowHeightExceptionMessage);
            }

            this.Height = height;
        }

        public void SetPosition(float x, float y)
        {
            this.Position = new Vector2(x, y);
        }

        public void SetPosition(Vector2 position)
        {
            this.Position = position;
        }

        private void InitializeWindow(GraphicsDevice graphicsDevice, SpriteFont font)
        {
            Color[] data = new Color[this.Width * this.Height];

            this.font = font;

            this.TitleBarColor = new Color(0, 120, 215);
            this.TitleBarHeight = 40;

            this.BackgroundColor = Color.White;

            this.BorderColor = new Color(0, 120, 215);
            this.BoarderWidth = 2;

            InitializeWindowBackground(data);
            InitializeBorder(data);
            InitializeTitleBar(data);

            this.window = new Texture2D(graphicsDevice, this.Width, this.Height);
            this.window.SetData(data);
        }

        private void InitializeTitleBar(Color[] data)
        {
            for (int i = 0; i < this.Width * this.TitleBarHeight; i++)
            {
                data[i] = this.BorderColor;
            }
        }

        private void InitializeWindowBackground(Color[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = this.BackgroundColor;
            }
        }

        private void InitializeBorder(Color[] data)
        {
            InitilizeBorderTop(data);
            InitializeBorderBottom(data);
            InitializeBorderLeft(data);
            InitializeBorderRight(data);
        }

        private void InitializeBorderRight(Color[] data)
        {
            for (int j = 1; j <= this.BoarderWidth; j++)
            {
                for (int i = this.Width - j; i < data.Length; i += this.Width)
                {
                    data[i] = this.BorderColor;
                }
            }
        }

        private void InitializeBorderLeft(Color[] data)
        {
            for (int j = 0; j < this.BoarderWidth; j++)
            {
                for (int i = j; i < data.Length; i += this.Width)
                {
                    data[i] = this.BorderColor;
                }
            }
        }

        private void InitializeBorderBottom(Color[] data)
        {
            for (int i = (this.Width * this.Height) - this.Width * this.BoarderWidth; i < this.Width * this.Height; ++i)
            {
                data[i] = this.BorderColor;
            }
        }

        private void InitilizeBorderTop(Color[] data)
        {
            for (int i = 0; i < this.Width * this.BoarderWidth; ++i)
            {
                data[i] = this.BorderColor;
            }
        }

        public Window(GraphicsDevice graphicsDevice, SpriteFont font, int width, int height, float x, float y)
        {
            SetWidth(width);
            SetHeight(height);
            SetPosition(x, y);
            InitializeWindow(graphicsDevice, font);
        }

        public Window(GraphicsDevice graphicsDevice, SpriteFont font, int width, int height, Vector2 position)
        {
            SetWidth(width);
            SetHeight(height);
            SetPosition(position);
            InitializeWindow(graphicsDevice, font);
        }

        public Window(GraphicsDevice graphicsDevice, SpriteFont font, int width, int height)
        {
            SetWidth(width);
            SetHeight(height);
            SetPosition(new Vector2(DefaultWindowPositionX, DefaultWindowPositionY));
            InitializeWindow(graphicsDevice, font);
        }

        public Window(GraphicsDevice graphicsDevice, SpriteFont font)
        {
            this.Width = 40;
            this.Height = 40;

            this.Position = new Vector2(DefaultWindowPositionX, DefaultWindowPositionY);

            InitializeWindow(graphicsDevice, font);
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public Vector2 Position { get; private set; }
        public Color TitleBarColor { get; set; }
        public int TitleBarHeight { get; set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public int BoarderWidth { get; set; }
        public string Title { get; set; }

        private SpriteFont font;
        private MouseState oldMouseState;
        private Texture2D window;

        public const int MinimumWindowWidth = 40;
        public const int MinimumWindowHeight = 40;

        public const float DefaultWindowPositionX = 0f;
        public const float DefaultWindowPositionY = 0f;

        public readonly string MinimumWindowWidthExceptionMessage = $"Window width cannot be less than the minimum width of {MinimumWindowWidth} pixels";
        public readonly string MinimumWindowHeightExceptionMessage = $"Window height cannot be less than the minimum height of {MinimumWindowHeight} pixels";
    }
}
