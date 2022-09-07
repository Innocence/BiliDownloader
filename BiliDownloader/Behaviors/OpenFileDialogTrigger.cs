﻿using Microsoft.Win32;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BiliDownloader.Behaviors
{
    public class OpenFileDialogTriggerAction : TriggerAction<Button>
    {
        // Using a DependencyProperty as the backing store for AttachedTextBox.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttachedTextBoxProperty =
            DependencyProperty.Register("AttachedTextBox", typeof(TextBox), typeof(OpenFileDialogTriggerAction));

        // Using a DependencyProperty as the backing store for FilterString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterStringProperty =
            DependencyProperty.Register("FilterString", typeof(string), typeof(OpenFileDialogTriggerAction));

        // Using a DependencyProperty as the backing store for IsFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFileProperty =
            DependencyProperty.Register("IsFile", typeof(bool), typeof(OpenFileDialogTriggerAction));


        public bool IsFile
        {
            get { return (bool)GetValue(IsFileProperty); }
            set { SetValue(IsFileProperty, value); }
        }


        public TextBox AttachedTextBox
        {
            get { return (TextBox)GetValue(AttachedTextBoxProperty); }
            set { SetValue(AttachedTextBoxProperty, value); }
        }


        public string FilterString
        {
            get { return (string)GetValue(FilterStringProperty); }
            set { SetValue(FilterStringProperty, value); }
        }


        private void OnOpenFileDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = FilterString
            };
            var ret = dlg.ShowDialog();
            if (ret != null && ret.Value)
            {
                AttachedTextBox.Text = dlg.FileName;
                BindingExpression bindingExpression = AttachedTextBox.GetBindingExpression(TextBox.TextProperty);
                bindingExpression.UpdateSource();
            }
        }

        private void OnBrowerFolderDialog()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AttachedTextBox.Text = dialog.SelectedPath;
                BindingExpression bindingExpression = AttachedTextBox.GetBindingExpression(TextBox.TextProperty);
                bindingExpression.UpdateSource();
            }
        }

        protected override void Invoke(object parameter)
        {
            if (IsFile)
            {
                OnOpenFileDialog();
            }
            else
            {
                OnBrowerFolderDialog();
            }
        }
    }
}
