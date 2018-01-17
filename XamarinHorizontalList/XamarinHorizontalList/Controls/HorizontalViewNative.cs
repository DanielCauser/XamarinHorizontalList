using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinHorizontalList.Controls
{
    public class HorizontalViewNative : View
	{
		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(HorizontalViewNative), default(IEnumerable<object>), BindingMode.TwoWay, propertyChanged: ItemsSourceChanged);

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var itemsLayout = (HorizontalViewNative)bindable;
			//itemsLayout.SetItems();
		}
	}
}
