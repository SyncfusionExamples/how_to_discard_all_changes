#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.IO;
using System;
using Syncfusion.UI.Xaml.Grid.Utility;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpreadsheetDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ribbon.Loaded += Ribbon_Loaded;
        }

        private void Ribbon_Loaded(object sender, RoutedEventArgs e)
        {
            var ribbon1 = GridUtil.GetVisualChild<Ribbon>(sender as FrameworkElement);

            // To add the ribbon button in View tab,

            if (ribbon1 != null)
            {
                var ribbonTab = ribbon1.Items[0] as RibbonTab;
                StackPanel panel = new StackPanel();
                Button Button1 = new Button();
                Button1.Content = "Undo All";
                Button Button2 = new Button();
                Button2.Content = "Redo All";
                Button1.Background = Brushes.White;
                Button2.Background = Brushes.White;
                Button1.BorderBrush = Brushes.Transparent;
                Button2.BorderBrush = Brushes.Transparent;
                Button1.Margin = new Thickness(5, 10, 5, 5);
                Button2.Margin = new Thickness(5, 0, 5, 15);
                Button1.Padding = new Thickness(2);
                Button2.Padding = new Thickness(2);
                Button1.FontFamily = new FontFamily("Segoe UI");
                Button1.Click += button_Click;
                Button2.Click += button1_Click;
                panel.Children.Add(Button1);
                panel.Children.Add(Button2);
               
                ribbonTab.Items.Add(panel);
            }
        }

        /// <summary>
        /// Provide support for Excel like closing operation when press the close button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.spreadsheetControl.Commands.FileClose.Execute(null);
            if (Application.Current.ShutdownMode != ShutdownMode.OnExplicitShutdown)
                e.Cancel = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Undo All
            while (this.spreadsheetControl.HistoryManager.UndoStack.Count > 0)
            {
                var undoStack = this.spreadsheetControl.HistoryManager.UndoStack.Pop();
                if (undoStack != null)
                {
                    undoStack.Execute(Syncfusion.UI.Xaml.Spreadsheet.History.CommandMode.Undo);
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Redo All
            if (this.spreadsheetControl.HistoryManager.RedoStack.Count > 0)
            {
                while (this.spreadsheetControl.HistoryManager.RedoStack.Count > 0)
                {
                    var redo = this.spreadsheetControl.HistoryManager.RedoStack.Pop();
                    if (redo != null)
                        redo.Execute(Syncfusion.UI.Xaml.Spreadsheet.History.CommandMode.Redo);
                }
            }
        }
    }
}
