﻿using Gtk;
using System;
using DataSourceAccess;
using Action = System.Action;

namespace GraphicalUserInterface
{
    /// <summary>
    /// Class Login
    /// 
    /// </summary>
    public class CashierWindow : ICashierWindow
    {
        [Builder.Object] private TextBuffer TodayCourse;
        [Builder.Object] private TextBuffer ExchangeResult;
        [Builder.Object] private Entry NameEntry;
        [Builder.Object] private ComboBoxText ContributedСurrencyComboBoxText;
        [Builder.Object] private ComboBoxText TargetCurrencyComboBoxText;
        [Builder.Object] private Entry ContributedAmountEntry;
        [Builder.Object] private Window _window;
     /*   [Builder.Object] private Dialog HistoryDialog;
        [Builder.Object] private Entry Client;
        [Builder.Object] private Window CustumerHistory;
        [Builder.Object] private TextBuffer History;*/
        private Builder GuiBuilder;
        
        public void Show() =>  _window.Visible = true;
        public void Close() => _window.Visible = false;
        public string Name => NameEntry.Text;
        public Currency ContributedCurrency => 
            (Currency) Enum.Parse(typeof(Currency),ContributedСurrencyComboBoxText.ActiveText);
        public Currency TargetCurrency => 
            (Currency) Enum.Parse(typeof(Currency),TargetCurrencyComboBoxText.ActiveText);
        public decimal ContributedAmount => decimal.Parse(ContributedAmountEntry.Text);
        public void ShowError(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowExchangeResult(string message)
        {
            ExchangeResult.Text = message;
        }

        public event Action Exchange;

        public CashierWindow()
        {
            Gtk.Application.Init();
            GuiBuilder = new Builder();
            try
            {
                GuiBuilder.AddFromFile("./BSUTPApplication/GuiGlade/CashierWindow.glade");
                GuiBuilder.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            InitCurrency();
        }
        
        protected void ClickedApplyButton(object sender, EventArgs a)
        {
            Exchange?.Invoke();   
        }
        
        protected void ClickedClearButton(object sender, EventArgs a)
        {
            //TODO
        }
        
        protected void ClickedRefreshButton(object sender, EventArgs a)
        {
            //TODO
        }
        
        protected void ClickedCloseButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
        
        protected void ClickedAboutButton(object sender, EventArgs a)
        {
            
        }
        
        protected void ExitButton(object sender, EventArgs a)
        {
            Application.Quit();
        }
        
        protected void ClickedQuitButton(object sender, EventArgs a)
        {
            //TODO
        }
        
        protected void ActivatePurchaseButton(object sender, EventArgs a)
        {
            //TODO
        }
        
        protected void ClickedCloseHistoryButton(object sender, EventArgs a)
        {
        }
        
        protected void ClickedHistoryButton(object sender, EventArgs a)
        {
           
        }
        
        protected void ClickedSearchButton(object sender, EventArgs a)
        {
        }
        
        protected void CloseHistoryButton(object sender, EventArgs a)
        {
            GuiBuilder.AddFromFile(
                "./GUI/CashierWindow.glade");
            GuiBuilder.Autoconnect(this);
        }
        
        protected void CloseHistory(object sender, EventArgs a)
        {
            GuiBuilder.AddFromFile(
                "./GUI/CashierWindow.glade");
            GuiBuilder.Autoconnect(this);
        }

        private void InitCurrency()
        {
            for (var i = 0; i < Enum.GetNames(typeof(Currency)).Length; i++)
            {
                ContributedСurrencyComboBoxText.InsertText(i,Enum.GetName(typeof(Currency),i+1));
                TargetCurrencyComboBoxText.InsertText(i,Enum.GetName(typeof(Currency),i+1));
            }
        }
    }
}