using System;
using System.Collections.Generic;

namespace TollTicketManagement.Common
{
    public class TrackChangeControlValues
    {

        #region Members.
        public List<string> LstControlChanged = new List<string>();
        #endregion Members.

        public TrackChangeControlValues(List<System.Windows.Controls.Control> pControls)
        {
            foreach (var ctl in pControls)
            {
                if (ctl is System.Windows.Controls.TextBox)
                {
                    (ctl as System.Windows.Controls.TextBox).TextChanged +=
                        new System.Windows.Controls.TextChangedEventHandler(ValueChanged);
                }
                else if (ctl is System.Windows.Controls.PasswordBox)
                {
                    (ctl as System.Windows.Controls.PasswordBox).PasswordChanged +=
                        new System.Windows.RoutedEventHandler(ValueChanged);
                }
                else if (ctl is System.Windows.Controls.ComboBox)
                {
                    (ctl as System.Windows.Controls.ComboBox).SelectionChanged +=
                        new System.Windows.Controls.SelectionChangedEventHandler(ValueChanged);
                    (ctl as System.Windows.Controls.ComboBox).AddHandler(
                        System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent,
                        new System.Windows.Controls.TextChangedEventHandler(ValueChanged));
                }
                else if (ctl is System.Windows.Controls.DatePicker)
                {
                    (ctl as System.Windows.Controls.DatePicker).SelectedDateChanged +=
                        new EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(ValueChanged);
                }
                else if (ctl is System.Windows.Controls.RadioButton)
                {
                    (ctl as System.Windows.Controls.RadioButton).Checked +=
                        new System.Windows.RoutedEventHandler(ValueChanged);
                }
                else if (ctl is System.Windows.Controls.CheckBox)
                {
                    (ctl as System.Windows.Controls.CheckBox).Checked +=
                        new System.Windows.RoutedEventHandler(ValueChanged);
                }
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            LstControlChanged.Add((sender as System.Windows.Controls.Control).Name);
        }
    }
}
