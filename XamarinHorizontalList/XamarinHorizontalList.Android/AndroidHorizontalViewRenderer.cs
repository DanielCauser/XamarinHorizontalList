using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
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
			base.OnElementPropertyChanged(sender, e);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<HorizontalViewNative> e)
		{
			base.OnElementChanged(e);

			var recyclerView = new RecyclerView(Context);
			SetNativeControl(recyclerView);
			_horizontalLayoutManager = new LinearLayoutManager(Context, OrientationHelper.Horizontal, false);
			recyclerView.SetLayoutManager(_horizontalLayoutManager);

			if (e.OldElement != null)
			{
				//var itemsSource = e.OldElement.ItemsSource as INotifyCollectionChanged;
				//if (itemsSource != null)
				//{
				//	itemsSource.CollectionChanged -= ItemsSourceOnCollectionChanged;
				//}
			}

			if (e.NewElement != null)
			{
				Control.SetAdapter(new RecycleViewAdapter(Forms.Context as Android.App.Activity, e.NewElement));
			}

			var itemsSource = e.NewElement.ItemsSource as INotifyCollectionChanged;
			if (itemsSource != null)
			{
				//itemsSource.CollectionChanged += ItemsSourceOnCollectionChanged;
			}
		}

		//private void ItemsSourceOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		//{
		//	var adapter = Control.GetAdapter();
		//	switch (e.Action)
		//	{
		//		case NotifyCollectionChangedAction.Add:
		//			RefreshAdapter();
		//			adapter.NotifyItemRangeInserted(
		//				positionStart: e.NewStartingIndex,
		//				itemCount: e.NewItems.Count
		//			);
		//			break;
		//		case NotifyCollectionChangedAction.Remove:
		//			if (Element.ItemsSource.Count() == 0)
		//			{
		//				RefreshAdapter();
		//				adapter.NotifyDataSetChanged();
		//				return;
		//			}

		//			RefreshAdapter();
		//			adapter.NotifyItemRangeRemoved(
		//				positionStart: e.OldStartingIndex,
		//				itemCount: e.OldItems.Count
		//			);
		//			break;
		//		case NotifyCollectionChangedAction.Replace:
		//			RefreshAdapter();
		//			adapter.NotifyItemRangeChanged(
		//				positionStart: e.OldStartingIndex,
		//				itemCount: e.OldItems.Count
		//			);
		//			break;
		//		case NotifyCollectionChangedAction.Move:
		//			RefreshAdapter();
		//			for (var i = 0; i < e.NewItems.Count; i++)
		//				adapter.NotifyItemMoved(
		//					fromPosition: e.OldStartingIndex + i,
		//					toPosition: e.NewStartingIndex + i
		//				);
		//			break;
		//		case NotifyCollectionChangedAction.Reset:
		//			RefreshAdapter();
		//			adapter.NotifyDataSetChanged();
		//			break;
		//		default:
		//			throw new ArgumentOutOfRangeException();
		//	}
		//}

		//private void RefreshAdapter()
		//{
		//	var sourceList = new List<object>();
			
		//	var dataSource = Element.ItemsSource.Cast<object>().ToList();
		//	sourceList.AddRange(dataSource);

		//	var newAdapter = new RecycleViewAdapter(Element, Element);
		//	_gridLayoutManager?.SetSpanSizeLookup(new SpanSizeLookup(_gridLayoutManager, newAdapter));
		//	Control.SwapAdapter(newAdapter, false);
		//}
	}

	public class RecycleViewAdapter : RecyclerView.Adapter
	{
		private readonly Activity Context;

		private readonly IList _dataSource;

		public override int ItemCount => (_dataSource != null ? _dataSource.Count : 0);

		public RecycleViewAdapter(Activity context, HorizontalViewNative view)
		{
			Context = context;
			_dataSource = view.ItemsSource?.Cast<object>()?.ToList();
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{

		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{

			return null;
		}
	}

	public class RecycleViewHolder : RecyclerView.ViewHolder
	{
		public RecycleViewHolder(Android.Views.View itemView) : base(itemView)
		{

		}
	}
}