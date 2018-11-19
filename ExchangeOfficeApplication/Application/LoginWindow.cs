﻿using Gtk;
using System;

namespace ExchangeOfficeApplication.GUI
{
    public class LoginWindow
    {
        [Builder.Object] private Entry LoginEntry;
        [Builder.Object] private Entry PasswordEntry;
        [Builder.Object] private Window loginWindow;

        private bool adminFlag;
        
        private Builder GuiBuilder;
        
        public LoginWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile(
                    "./GUI/LoginWindow.glade");
                GuiBuilder.Autoconnect(this);
                loginWindow.Visible = true;
                Application.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        protected void OkButtonClicked(object sender, EventArgs a)
        {
            loginWindow.Visible = false;
            if (adminFlag)
            {
                new AdminWindow();
            }
            else
            {
                new CashierWindow();
            }
            // TODO
        }
        
        protected void ExitButtonClicked(object sender, EventArgs a)
        {
            Console.WriteLine("Exit");
            Application.Quit();
            // TODO
        }
        
        protected void  AdministratorSwitchActivate(object sender, ButtonReleaseEventArgs a)
        {
            adminFlag = !adminFlag;
            Console.WriteLine($"Admin : {adminFlag}");
        }
        
        protected void  ExitButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
    }
}