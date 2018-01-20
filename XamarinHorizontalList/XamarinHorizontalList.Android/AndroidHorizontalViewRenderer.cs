using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinHorizontalList.Controls;
using XamarinHorizontalList.Droid;

[assembly: ExportRenderer(typeof(HorizontalViewNative), typeof(AndroidHorizontalViewRenderer))]
namespace XamarinHorizontalList.Droid
{
    public class AndroidHorizontalViewRenderer : ViewRenderer<HorizontalViewNative, RecyclerView>
    {
        private LinearLayoutManager _horizontalLayoutManager;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Element.ItemsSource))
            {
                UpdateAdapter();
            }
        }

        private void UpdateAdapter()
        {
            var dataSource = Element.ItemsSource.Cast<object>().ToList();
            var adapter = new RecycleViewAdapter(Forms.Context as Android.App.Activity, Element) { HasStableIds = true };

            Control.SetAdapter(adapter);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<HorizontalViewNative> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var recyclerView = new RecyclerView(Context);
                SetNativeControl(recyclerView);

                _horizontalLayoutManager = new LinearLayoutManager(Context, OrientationHelper.Horizontal, false);
                recyclerView.SetLayoutManager(_horizontalLayoutManager);

                Control.SetAdapter(new RecycleViewAdapter(Forms.Context as Android.App.Activity, e.NewElement));
            }
        }
    }

    public class RecycleViewAdapter : RecyclerView.Adapter
    {
        private readonly Activity Context;

        private readonly HorizontalViewNative _view;

        private readonly IList _dataSource;

        public override int ItemCount => (_dataSource != null ? _dataSource.Count : 0);

        public RecycleViewAdapter(Activity context, HorizontalViewNative view)
        {
            Context = context;
            _view = view;
            _dataSource = view.ItemsSource?.Cast<object>()?.ToList();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = (RecycleViewHolder)holder;
            var dataContext = _dataSource[position];
            if (dataContext != null)
            {
                var dataTemplate = _view.ItemTemplate;
                ViewCell viewCell;
                var selector = dataTemplate as DataTemplateSelector;
                if (selector != null)
                {
                    var template = selector.SelectTemplate(_dataSource[position], _view.Parent);
                    viewCell = template.CreateContent() as ViewCell;
                }
                else
                {
                    viewCell = dataTemplate?.CreateContent() as ViewCell;
                }

                item.UpdateUi(viewCell, dataContext, _view);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var contentFrame = new FrameLayout(parent.Context)
            {
                LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent)
                {
                    Height = (int)(100),
                    Width = (int)(100)
                }
            };
            
            contentFrame.DescendantFocusability = DescendantFocusability.AfterDescendants;
            var viewHolder = new RecycleViewHolder(contentFrame);
            return viewHolder;
        }
    }

    public class RecycleViewHolder : RecyclerView.ViewHolder
    {
        public RecycleViewHolder(Android.Views.View itemView) : base(itemView)
        {
            ItemView = itemView;
        }

        public void UpdateUi(ViewCell viewCell, object dataContext, HorizontalViewNative view)
        {
            var contentLayout = (FrameLayout)ItemView;

            viewCell.BindingContext = dataContext;
            viewCell.Parent = view;

            var metrics = Resources.System.DisplayMetrics;
            // Layout and Measure Xamarin Forms View
            var elementSizeRequest = viewCell.View.Measure(double.PositiveInfinity, double.PositiveInfinity, MeasureFlags.IncludeMargins);

            var height = (int)((100 + viewCell.View.Margin.Top + viewCell.View.Margin.Bottom) * metrics.Density);
            var width = (int)((100 + viewCell.View.Margin.Left + viewCell.View.Margin.Right) * metrics.Density);

            viewCell.View.Layout(new Rectangle(0, 0, 100, 100));

            // Layout Android View
            var layoutParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            {
                Height = height,
                Width = width
            };

            if (Platform.GetRenderer(viewCell.View) == null)
            {
                Platform.SetRenderer(viewCell.View, Platform.CreateRenderer(viewCell.View));
            }
            var renderer = Platform.GetRenderer(viewCell.View);


            var viewGroup = renderer.View;
            viewGroup.LayoutParameters = layoutParams;
            viewGroup.Layout(0, 0, 100, 100);

            contentLayout.RemoveAllViews();
            contentLayout.AddView(viewGroup);
        }
    }
}