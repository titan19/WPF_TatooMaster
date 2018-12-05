using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TatooMaster.Models;

namespace TatooMaster.UserControls
{
    public partial class EntriesView : UserControl
    {
        public ObservableCollection<Entry> TableContent { get; }
        public ObservableCollection<Master> Masters => Register.Instance.Get<Master>(); 
        
        public EntriesView()
        {
            TableContent = Register.Instance.Get<Entry>();
            InitializeComponent();
            DataContext = this;
            Table.ItemsSource = TableContent;
        }
    }
}
