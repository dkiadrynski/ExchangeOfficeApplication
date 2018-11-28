using Gtk;
using System;

namespace GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class AboutWindow
    {
        [Builder.Object] private AboutDialog _window;
        
        private Builder GuiBuilder;
        
        public AboutWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile("./GraphicalUserInterface/GuiGlade/AboutWindow.glade");
                GuiBuilder.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        internal void OpenWindow()
        {
            _window.Visible = true;
        }
        
        protected void CloseAboutWindow(object sender, EventArgs a)
        {
            GuiBuilder.AddFromFile("./GraphicalUserInterface/GuiGlade/AboutWindow.glade");
            GuiBuilder.Autoconnect(this);
        }
        
        protected void CloseAboutWindow(object sender, ResponseArgs a)
        {
            _window.Visible = false;
        }
    }
}