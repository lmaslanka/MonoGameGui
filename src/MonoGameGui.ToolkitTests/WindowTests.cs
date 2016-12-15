namespace MonoGameGui.ToolkitTests
{
    using System;
    using Microsoft.Xna.Framework.Graphics;
    using Toolkit;
    using Xunit;

    public class WindowTests
    {
        [Fact]
        public void CreateNewWindow_NewWindowIsCreatedWithMinimumSize()
        {
            Window window = new Window(this.graphics);

            Assert.Equal(Window.MinimumWindowWidth, window.Width);
            Assert.Equal(Window.MinimumWindowHeight, window.Height);

            Assert.Equal(Window.DefaultWindowPositionX, window.Position.X);
            Assert.Equal(Window.DefaultWindowPositionY, window.Position.Y);
        }

        [Fact]
        public void CreateNewWindow_NewWindowIsCreatedWithInvalidSize_ThrowsException()
        {
            Exception ex = Assert.Throws<WindowInvalidMinimumSizeException>(() => new Window(this.graphics, 20, 20));
        }

        [Fact]
        public void SetWidth_SetWindowWidthToInvalidWidth_ThrowsException()
        {
            Window window = new Window(this.graphics);

            Exception ex = Assert.Throws<WindowInvalidMinimumSizeException>(() => window.SetWidth(10));
        }

        [Fact]
        public void SetHeight_SetWindowHeightToInvalidHeight_ThrowsException()
        {
            Window window = new Window(this.graphics);

            Exception ex = Assert.Throws<WindowInvalidMinimumSizeException>(() => window.SetHeight(10));
        }

        public WindowTests()
        {
            GraphicsAdapter adapter = GraphicsAdapter.DefaultAdapter;
            PresentationParameters presentationParameters = new PresentationParameters();

            this.graphics = new GraphicsDevice(adapter, GraphicsProfile.Reach, presentationParameters);
        }

        private readonly GraphicsDevice graphics;
    }
}
