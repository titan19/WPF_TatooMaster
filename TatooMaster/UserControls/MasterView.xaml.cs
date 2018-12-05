using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using TatooMaster.Models;

namespace TatooMaster.UserControls
{
    public partial class MasterView : UserControl
    {
        public ObservableCollection<Master> TableContent { get; }
        public MasterView()
        {
            TableContent = Register.Instance.Get<Master>();
            InitializeComponent();
            Table.ItemsSource = TableContent;
        }
    }
}
