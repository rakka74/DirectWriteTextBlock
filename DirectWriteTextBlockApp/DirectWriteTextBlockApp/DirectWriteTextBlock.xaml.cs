﻿using DirectWriteTextBlockLibNS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DirectWriteTextBlockApp
{
    /// <summary>
    /// DirectWriteTextBlock.xaml の相互作用ロジック
    /// </summary>
    public partial class DirectWriteTextBlock : UserControl
    {
        #region 依存関係プロパティ
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text", // プロパティ名を指定
                typeof(String), // プロパティの型を指定
                typeof(DirectWriteTextBlock), // プロパティを所有する型を指定
                new PropertyMetadata(
                    "", // デフォルト値の設定
                    new PropertyChangedCallback(OnTextChanged))); // プロパティの変更時に呼ばれるコールバックの設定

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = d as DirectWriteTextBlock;
            self.textPropertyChanged(e.NewValue as string);
        }

        public String Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion

        DirectWriteTextBlockLib _dwTextBlockLib;

        public DirectWriteTextBlock()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _dwTextBlockLib = new DirectWriteTextBlockLib();

            string fontFamilyName;
            this.FontFamily.FamilyNames.TryGetValue(XmlLanguage.GetLanguage("en-us"), out fontFamilyName);
            _dwTextBlockLib.setFontFamilyName(fontFamilyName);
            _dwTextBlockLib.setFontSize((float)this.FontSize);

            this.textPropertyChanged(this.Text);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _dwTextBlockLib.Dispose();
            _dwTextBlockLib = null;
        }

        void textPropertyChanged(string newText)
        {
            this.textBlock.Text = newText;
            //Debug.WriteLine(newText);
        }

    }
}
