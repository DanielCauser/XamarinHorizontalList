
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinHorizontalList.Controls;
using XamarinHorizontalList.iOS;

[assembly: ExportRenderer(typeof(HorizontalViewNative), typeof(iOSHorizontalVIewRenderer))]
namespace XamarinHorizontalList.iOS
{
    public class iOSHorizontalVIewRenderer : ViewRenderer<HorizontalViewNative, UICollectionView>
    {
        UICollectionView collectionView;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HorizontalViewNative.ItemsSource))
                Control.Source = new iOSViewSource(Element as HorizontalViewNative);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<HorizontalViewNative> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var rect = new CGRect(0, 0, 100, 100);
                var layout = new UICollectionViewLayout();
                collectionView = new UICollectionView(rect, layout);
                SetNativeControl(collectionView);
            }
        }
    }

    public class iOSViewSource : UICollectionViewSource
    {
        private readonly HorizontalViewNative _view;

        private readonly IList _dataSource;

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return _dataSource != null ? _dataSource.Count : 0;
        }

        public iOSViewSource(HorizontalViewNative view)
        {
            _view = view;
            _dataSource = view.ItemsSource?.Cast<object>()?.ToList();
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell((NSString)nameof(iOSViewCell), indexPath) as iOSViewCell;
            var dataContext = _dataSource[indexPath.Row];
            if (dataContext != null)
            {
                var dataTemplate = _view.ItemTemplate;
                ViewCell viewCell;
                var selector = dataTemplate as DataTemplateSelector;
                if (selector != null)
                {
                    var template = selector.SelectTemplate(_dataSource[indexPath.Row], _view.Parent);
                    viewCell = template.CreateContent() as ViewCell;
                }
                else
                {
                    viewCell = dataTemplate?.CreateContent() as ViewCell;
                }

                cell.UpdateUi(viewCell, dataContext, _view);
            }
            return cell;
        }
    }

    public class iOSViewCell : UICollectionViewCell
    {
        internal void UpdateUi(ViewCell viewCell, object dataContext, HorizontalViewNative view)
        {
            viewCell.BindingContext = dataContext;
            viewCell.Parent = view;

            var height = (int)((view.ItemHeight + viewCell.View.Margin.Top + viewCell.View.Margin.Bottom));
            var width = (int)((view.ItemWidth + viewCell.View.Margin.Left + viewCell.View.Margin.Right));

            viewCell.View.Layout(new Rectangle(0, 0, view.ItemWidth, view.ItemHeight));
        }
    }
}